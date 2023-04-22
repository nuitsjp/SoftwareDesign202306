using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper.UseCase;

/// <summary>
/// ユースケース：近隣のレストランを閲覧する。
/// </summary>
public interface IFindNearbyRestaurants
{
    /// <summary>
    /// 近隣のレストランを閲覧する。
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> FindRestaurantsAsync();
}