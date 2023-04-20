using System.Text.Json.Serialization;

namespace HatPepper.Infrastructure.Api;

/// <summary>
/// グルメ検索結果
/// </summary>
/// <param name="Shops"></param>
public record Results(
    [property: JsonPropertyName("shop")] 
    IReadOnlyList<Shop> Shops);