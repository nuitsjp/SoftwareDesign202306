using System.Device.Location;

namespace HatPepper.UseCase;

/// <summary>
/// 位置情報プロバイダー
/// </summary>
public interface ILocationProvider
{
    /// <summary>
    /// 現在地を取得する。
    /// </summary>
    /// <returns></returns>
    GeoCoordinate GetCurrentLocation();
}