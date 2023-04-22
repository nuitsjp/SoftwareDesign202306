namespace HatPepper.Infrastructure.Api;

/// <summary>
/// グルメ検索結果
/// </summary>
/// <param name="Shops">店舗</param>
public record Root(IReadOnlyList<Shop> Shops);