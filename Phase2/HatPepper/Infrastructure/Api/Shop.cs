namespace HatPepper.Infrastructure.Api;

/// <summary>
/// 店舗
/// </summary>
/// <param name="Name">名称</param>
/// <param name="Address">住所</param>
/// <param name="Phone">電話番号</param>
/// <param name="Budget">予算</param>
/// <param name="Rating">レート</param>
/// <param name="Menu">メニュー</param>
/// <param name="Genre">ジャンル</param>
public record Shop(
    string Name, 
    string Address, 
    string Phone, 
    string Budget, 
    float Rating, 
    Menu[] Menu, 
    Genre Genre);