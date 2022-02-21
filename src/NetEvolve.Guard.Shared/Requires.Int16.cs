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
  public static void InBetween(short value, short minValue, short maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void NotBetween(short value, short minValue, short maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void GreaterThan(short value, short compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void GreaterThanOrEqual(short value, short compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void LessThan(short value, short compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
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
  public static void LessThanOrEqual(short value, short compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

#if NET6_0_OR_GREATER
  /// <summary>
  /// Determines if <paramref name="value"/> is a power of two.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is not a power of two.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotPow2(short value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!System.Numerics.BitOperations.IsPow2(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
#endif
}
#endif
