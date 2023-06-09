﻿using System.Device.Location;

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
    public GeoCoordinate Current =>
        new GeoCoordinateWatcher()
            .GetCurrentLocation(TimeSpan.FromSeconds(10));
}