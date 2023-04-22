using FluentTextTable;
using HatPepper.UseCase;

namespace HatPepper.Presentation;

/// <summary>
/// 近隣のレストランを表示する。
/// </summary>
public class NearbyRestaurantsConsole
{
    /// <summary>
    /// 近隣のレストランを表示する。
    /// </summary>
    /// <returns></returns>
    public async Task ShowRestaurantsAsync()
    {
        // レストランを検索する。
        var findNearbyRestaurants = new FindNearbyRestaurants();
        var restaurants = await findNearbyRestaurants.FindRestaurantsAsync();

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