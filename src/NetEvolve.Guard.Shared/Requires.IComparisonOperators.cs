#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> is in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="minValue">The minimal value for the comparison.</param>
  /// <param name="maxValue">The maximal value for the comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void InBetween<T>(T value, T minValue, T maxValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="minValue">The minimal value for the comparison.</param>
  /// <param name="maxValue">The maximal value for the comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void NotBetween<T>(T value, T minValue, T maxValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (minValue <= value == value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is greater than <paramref name="compareValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void GreaterThan<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is greater than or equal to <paramref name="compareValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is less than <paramref name="compareValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void GreaterThanOrEqual<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is less than <paramref name="compareValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than or equal to <paramref name="compareValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void LessThan<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.
  /// </summary>
  /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther}"/> compatible type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="compareValue">The value to be used for comparison.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void LessThanOrEqual<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = default) where T : IComparisonOperators<T, T>
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }
}
#endif
