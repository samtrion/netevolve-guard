#if NET5_0_OR_GREATER && !USE_GENERIC_MATH_FEATURE
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
  public static void InBetween(Half value, Half minValue, Half maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void NotBetween(Half value, Half minValue, Half maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void GreaterThan(Half value, Half compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void GreaterThanOrEqual(Half value, Half compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void LessThan(Half value, Half compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void LessThanOrEqual(Half value, Half compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void NotNaN(Half value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (Half.IsNaN(value))
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
  public static void NotInfinity(Half value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (Half.IsInfinity(value))
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
  public static void NotNegativeInfinity(Half value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (Half.IsNegativeInfinity(value))
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
  public static void NotPositiveInfinity(Half value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (Half.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
