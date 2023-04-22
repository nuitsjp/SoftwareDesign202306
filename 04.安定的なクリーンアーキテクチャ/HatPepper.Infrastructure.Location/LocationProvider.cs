using System;
using System.Device.Location;
using HatPepper.UseCase;

namespace HatPepper.Infrastructure.Location;

/// <summary>
/// 位置情報プロバイダー
/// </summary>
public class LocationProvider : ILocationProvider
{
    /// <summary>
    /// 現在地を取得する。
    /// </summary>
    /// <returns></returns>
    public UseCase.Location Current
    {
        get
        {
            var location =
                new GeoCoordinateWatcher()
                    .GetCurrentLocation(TimeSpan.FromSeconds(10));
            return new UseCase.Location(location.Latitude, location.Longitude);
        }
    }
}