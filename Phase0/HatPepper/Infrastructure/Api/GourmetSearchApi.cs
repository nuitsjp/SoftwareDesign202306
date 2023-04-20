using System.Device.Location;
using System.Net.Http.Json;
using System.Text.Json;

namespace HatPepper.Infrastructure.Api;

/// <summary>
/// Hot Pepper Gourmet Search API
/// </summary>
public class GourmetSearchApi
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
    public async Task<Root> FindRestaurantsAsync(
        GeoCoordinate location,
        bool lunchOnly)
    {
        var url = "https://webservice.recruit.co.jp/hotpepper/gourmet/v1/?" +
                  $"&key={Secret.Value}" +
                  $"&lat={35.681236}" +
                  $"&lng={139.767125}" +
                  $"{(lunchOnly ? "&lunch=1" : string.Empty)}" +
                  "&format=json";
        var result = (await HttpClient.GetFromJsonAsync<Root>(url))!;
        // jsonでファイルに保存する
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(result, options);
        File.WriteAllText("restaurants.json", json);

        return result;
    }
}


public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public string Name { get; set; }
    public string Genre { get; set; }
}
