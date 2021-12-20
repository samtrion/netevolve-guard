namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Validates if the passed <paramref name="value"/> corresponds to a absolute uri. If not, an <see cref="ArgumentException"/> is thrown.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not an absolute <see cref="Uri"/>.</exception>
  [StackTraceHidden]
  public static void IsAbsolute([NotNull] Uri value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Validates if the passed <paramref name="value"/> corresponds to a relative uri. If not, an <see cref="ArgumentException"/> is thrown.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not a relative <see cref="Uri"/>.</exception>
  [StackTraceHidden]
  public static void IsRelative([NotNull] Uri value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
