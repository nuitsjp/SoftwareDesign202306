namespace HatPepper.Infrastructure.Api;

/// <summary>
/// 店舗
/// </summary>
/// <param name="Name">名称</param>
/// <param name="Genre">ジャンル</param>
public record Shop(string Name, Genre Genre);