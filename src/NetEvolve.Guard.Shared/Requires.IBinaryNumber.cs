#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

public static partial class Requires
{
  /// <summary>
  /// Determines if a <paramref name="value"/> is a power of two.
  /// </summary>
  /// <typeparam name="T"><see cref="IBinaryNumber{TSelf}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not a power of two.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotPow2<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : IBinaryNumber<T>
  {
    if (!T.IsPow2(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
