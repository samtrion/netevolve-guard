#if !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> is in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="minValue">The minimal value for the comparison.</param>
  /// <param name="maxValue">The maximal value for the comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void InBetween(float value, float minValue, float maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="minValue">The minimal value for the comparison.</param>
  /// <param name="maxValue">The maximal value for the comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotBetween(float value, float minValue, float maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (minValue <= value == value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is greater than <paramref name="compareValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void GreaterThan(float value, float compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is greater than or equal to <paramref name="compareValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is less than <paramref name="compareValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void GreaterThanOrEqual(float value, float compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is less than <paramref name="compareValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than or equal to <paramref name="compareValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void LessThan(float value, float compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void LessThanOrEqual(float value, float compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is a number or not.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not a number.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotNaN(float value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (float.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not infinity.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is inifity.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotInfinity(float value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (float.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not negative inifity.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is negative infinity.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotNegativeInfinity(float value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (float.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not positive inifity.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is positive infinity.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotPositiveInfinity(float value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (float.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
