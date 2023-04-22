using FluentTextTable;
using HatPepper.UseCase;

namespace HatPepper.Presentation;

/// <summary>
/// 近隣のレストランを表示する。
/// </summary>
public class NearbyRestaurantsConsole
{
    /// <summary>
    /// ユースケース：近隣のレストランを閲覧する。
    /// </summary>
    private readonly IFindNearbyRestaurants _findNearbyRestaurants;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="findNearbyRestaurants">ユースケース：近隣のレストランを閲覧する。</param>
    public NearbyRestaurantsConsole(IFindNearbyRestaurants findNearbyRestaurants)
    {
        _findNearbyRestaurants = findNearbyRestaurants;
    }

    /// <summary>
    /// 近隣のレストランを表示する。
    /// </summary>
    /// <returns></returns>
    public async Task ShowRestaurantsAsync()
    {
        // レストランを検索する。
        var restaurants = 
            await _findNearbyRestaurants.FindRestaurantsAsync();

        // レストランを表示する。
        Build.TextTable<Restaurant>(builder =>
            {
                builder
                    .Columns.Add(x => x.Name).NameAs("店舗")
                    .Columns.Add(x => x.Genre).NameAs("ジャンル");
            })
            .WriteLine(restaurants);
    }
}