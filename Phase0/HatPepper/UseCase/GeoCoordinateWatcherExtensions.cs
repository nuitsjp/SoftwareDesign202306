using System.Device.Location;

namespace HatPepper.UseCase;

/// <summary>
/// GeoCoordinateWatcherの拡張メソッド
/// </summary>
public static class GeoCoordinateWatcherExtensions
{
    /// <summary>
    /// 現在位置を取得する。
    /// </summary>
    /// <param name="watcher"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static GeoCoordinate GetCurrentLocation(this GeoCoordinateWatcher watcher)
    {
        GeoCoordinate result = GeoCoordinate.Unknown;
        // PositionChangedイベントを監視し、イベント発生時に待機中のスレッドを再開する
        watcher.PositionChanged += (_, eventArgs) =>
        {
            if (eventArgs.Position.Location.IsUnknown)
            {
                return;
            }

            result = eventArgs.Position.Location;
            Monitor.Enter(watcher);
            try
            {
                Monitor.PulseAll(watcher);
            }
            finally
            {
                Monitor.Exit(watcher);
            }
        };

        Monitor.Enter(watcher);
        try
        {
            // GeoCoordinateWatcherを起動し、PositionChangedイベントが発生するか
            // タイムアウトまで待機する
            watcher.Start();
            Monitor.Wait(watcher, TimeSpan.FromSeconds(10));
        }
        finally
        {
            Monitor.Exit(watcher);
        }
        watcher.Stop();

        if (result != GeoCoordinate.Unknown)
        {
            return result;
        }

        throw new InvalidOperationException("位置情報が取得できませんでした。");
    }
}