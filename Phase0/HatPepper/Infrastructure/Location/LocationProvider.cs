using System.Device.Location;

namespace HatPepper.Infrastructure.Location;

/// <summary>
/// 位置情報プロバイダー
/// </summary>
public class LocationProvider
{
    /// <summary>
    /// 現在地を取得する。
    /// </summary>
    /// <returns></returns>
    public GeoCoordinate GetCurrentLocation() =>
        new GeoCoordinateWatcher()
            .GetCurrentLocation(TimeSpan.FromSeconds(10));
}