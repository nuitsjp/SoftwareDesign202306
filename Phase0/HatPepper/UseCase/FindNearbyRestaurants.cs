using HatPepper.Infrastructure.Api;
using HatPepper.Infrastructure.Location;
using HatPepper.Infrastructure.Time;
// ReSharper disable MergeIntoPattern

namespace HatPepper.UseCase;

/// <summary>
/// ユースケース：近隣のレストランを閲覧する。
/// </summary>
public class FindNearbyRestaurants
{
    /// <summary>
    /// 位置情報プロバイダー
    /// </summary>
    private readonly LocationProvider _locationProvider = new();
    /// <summary>
    /// タイムプロバイダー
    /// </summary>
    private readonly TimeProvider _timeProvider = new();
    /// <summary>
    /// グルメ検索API
    /// </summary>
    private readonly GourmetSearchApi _api = new();

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
        var lunchOnly = 11 <= now.Hour && now.Hour <= 14;

        // レストランを検索する。
        var result = await _api.FindRestaurantsAsync(location, lunchOnly);
        return result.Shops
            .Select(x => new Restaurant(x.Name, x.Genre.Name));
    }
}