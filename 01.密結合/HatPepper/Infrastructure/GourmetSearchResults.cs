namespace HatPepper.Infrastructure;

/// <summary>
/// グルメ検索結果
/// </summary>
/// <param name="Shops">店舗</param>
public record GourmetSearchResults(IReadOnlyList<Shop> Shops);