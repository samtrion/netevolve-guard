#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

public static partial class Requires
{
  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void InBetween<T>(T value, T minValue, T maxValue, [CallerArgumentExpression("value")] string? parameterName = null) where T : IComparisonOperators<T, T>
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void GreaterThan<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = null) where T : IComparisonOperators<T, T>
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void GreaterThanOrEqual<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = null) where T : IComparisonOperators<T, T>
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void LessThan<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = null) where T : IComparisonOperators<T, T>
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void LessThanOrEqual<T>(T value, T compareValue, [CallerArgumentExpression("value")] string? parameterName = null) where T : IComparisonOperators<T, T>
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }
}
#endif
