namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> is readable.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not readable.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void IsReadable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanRead)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is seekable.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not seekable.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void IsSeekable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanSeek)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is writable.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not writable.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void IsWritable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanWrite)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not empty.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is empty.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotEmpty([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
