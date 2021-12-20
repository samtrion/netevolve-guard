#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

public static partial class Requires
{
  /// <summary>
  /// Determines if the <paramref name="value"/> is not a number or not.
  /// </summary>
  /// <typeparam name="T"><see cref="IFloatingPoint{TSelf}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not a number, then a <see cref="ArgumentException"/> is raised.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotNaN<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : IFloatingPoint<T>
  {
    if (T.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if the <paramref name="value"/> corresponds to infinity or not.
  /// </summary>
  /// <typeparam name="T"><see cref="IFloatingPoint{TSelf}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is infinity, then a <see cref="ArgumentException"/> is raised.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : IFloatingPoint<T>
  {
    if (T.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if the <paramref name="value"/> corresponds to negative infinity or not.
  /// </summary>
  /// <typeparam name="T"><see cref="IFloatingPoint{TSelf}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is negative infinity, then a <see cref="ArgumentException"/> is raised.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotNegativeInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : IFloatingPoint<T>
  {
    if (T.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if the <paramref name="value"/> corresponds to positive infinity or not.
  /// </summary>
  /// <typeparam name="T"><see cref="IFloatingPoint{TSelf}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is positive infinity, then a <see cref="ArgumentException"/> is raised.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotPositiveInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : IFloatingPoint<T>
  {
    if (T.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
