﻿using System.Device.Location;
using System.Net.Http.Json;

namespace HatPepper.Infrastructure;

/// <summary>
/// グルメ検索API
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
    public async Task<GourmetSearchResults> FindRestaurantsAsync(GeoCoordinate location, bool lunchOnly)
    {
        var uri = "https://nuitsjp.github.io/SoftwareDesign202306/restaurants.json?" +
                  $"&lat={location.Latitude}" +
                  $"&lng={location.Longitude}" +
                  $"{(lunchOnly ? "&lunch=1" : string.Empty)}";
        return (await HttpClient.GetFromJsonAsync<GourmetSearchResults>(uri))!;
    }
}