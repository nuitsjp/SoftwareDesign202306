using System.Device.Location;
using HatPepper.Infrastructure;

// ReSharper disable MergeIntoPattern

namespace HatPepper.UseCase;

/// <summary>
/// ユースケース：近隣のレストランを閲覧する。
/// </summary>
public class FindNearbyRestaurants
{
    /// <summary>
    /// 近隣のレストランを閲覧する。
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Restaurant>> FindRestaurantsAsync()
    {
        // 現在地を取得する
        var locationProvider = new GeoCoordinateWatcher();
        var location = locationProvider.GetCurrentLocation();

        // ランチタイムかどうか判定する
        var now = DateTime.Now;
        var lunchOnly = 11 <= now.Hour && now.Hour <= 14;

        // レストランを検索する。
        var gourmetSearchApi = new GourmetSearchApi();
        var result = await gourmetSearchApi.FindRestaurantsAsync(location, lunchOnly);
        return result.Shops
            .Select(x => new Restaurant(x.Name, x.Genre.Name));
    }
}