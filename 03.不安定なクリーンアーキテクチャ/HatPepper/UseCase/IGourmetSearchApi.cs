namespace HatPepper.UseCase;

public interface IGourmetSearchApi
{
    /// <summary>
    /// レストランを検索する。
    /// </summary>
    /// <param name="location">位置情報</param>
    /// <param name="lunchOnly">ランチに限定する</param>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> FindRestaurantsAsync(Location location, bool lunchOnly);
}