﻿namespace HatPepper.Infrastructure.Time;

/// <summary>
/// 時間を取り扱うプロバイダー
/// </summary>
public interface ITimeProvider
{
    /// <summary>
    /// 現在時刻を取得する。
    /// </summary>
    /// <returns></returns>
    DateTime GetNow();
}