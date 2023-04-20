namespace HatPepper;

/// <summary>
/// int拡張メソッド
/// </summary>
public static class IntExtensions
{
    /// <summary>
    /// 指定した値が範囲内かどうかを判定する。
    /// </summary>
    /// <param name="value">判定対象</param>
    /// <param name="start">開始</param>
    /// <param name="end">終了</param>
    /// <returns></returns>
    public static bool Between(this int value, int start, int end) =>
        start <= value && value <= end;
}