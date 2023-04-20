﻿using HatPepper.Infrastructure.Api;
using HatPepper.Infrastructure.Location;
using HatPepper.Infrastructure.Time;

namespace HatPepper.UseCase;

/// <summary>
/// ユースケース：近隣のレストランを閲覧する。
/// </summary>
public class FindNearbyRestaurants : IFindNearbyRestaurants
{
    /// <summary>
    /// 位置情報プロバイダー
    /// </summary>
    private readonly LocationProvider _locationProvider;
    /// <summary>
    /// タイムプロバイダー
    /// </summary>
    private readonly TimeProvider _timeProvider;
    /// <summary>
    /// グルメ検索API
    /// </summary>
    private readonly GourmetSearchApi _api;

    /// <summary>
    /// インスタンスを生成する。
    /// </summary>
    /// <param name="locationProvider">位置情報プロバイダー</param>
    /// <param name="timeProvider">時刻プロバイダー</param>
    /// <param name="api">グルメサービスAPI</param>
    public FindNearbyRestaurants(
        LocationProvider locationProvider, 
        TimeProvider timeProvider, 
        GourmetSearchApi api)
    {
        _locationProvider = locationProvider;
        _timeProvider = timeProvider;
        _api = api;
    }

    /// <summary>
    /// 近隣のレストランを閲覧する。
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Restaurant>> FindRestaurantsAsync()
    {
        // 現在地を取得する
        var location = _locationProvider.GetCurrentLocation();

        // ランチタイムかどうか判定する
        var now = _timeProvider.GetNow();
        var lunchOnly = now.Hour.Between(11, 14);

        // レストランを検索する。
        var result = await _api.FindRestaurantsAsync(location, lunchOnly);
        return result.Results.Shops
            .Select(x => new Restaurant(x.Name, x.Genre.Name));
    }
}