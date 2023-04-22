using System.Device.Location;
using System.Net.Http.Json;

namespace HatPepper.Infrastructure.Api;

/// <summary>
/// Hot Pepper Gourmet Search API
/// </summary>
public class GourmetSearchApi : IGourmetSearchApi
{
    /// <summary>
    /// HttpClient
    /// </summary>
    private static readonly HttpClient HttpClient = new();

    /// <summary>
    /// レストランを検索する。
    /// </summary>
    /// <param name="location">位置情報</param>
    /// <param name="lunchOnly">ランチに限定する</param>
    /// <returns></returns>
    public async Task<GourmetSearchResults> FindRestaurantsAsync(
        GeoCoordinate location,
        bool lunchOnly)
    {
        var url = "https://nuitsjp.github.io/SoftwareDesign202306/restaurants.json?" +
                  $"&lat={location.Latitude}" +
                  $"&lng={location.Longitude}" +
                  $"{(lunchOnly ? "&lunch=1" : string.Empty)}";
        return (await HttpClient.GetFromJsonAsync<GourmetSearchResults>(url))!;
    }
}