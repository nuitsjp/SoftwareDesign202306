namespace HatPepper.Infrastructure.Api;

/// <summary>
/// グルメ検索結果
/// </summary>
/// <param name="Shops"></param>
public record Results(IReadOnlyList<Shop> Shops);