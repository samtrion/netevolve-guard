#if !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CompareValue = System.Double;

public static partial class Requires
{
  [StackTraceHidden]
  public static void InBetween(CompareValue value, CompareValue minValue, CompareValue maxValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [StackTraceHidden]
  public static void GreaterThan(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [StackTraceHidden]
  public static void GreaterThanOrEqual(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [StackTraceHidden]
  public static void LessThan(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [StackTraceHidden]
  public static void LessThanOrEqual(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  [StackTraceHidden]
  public static void NotNaN(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (CompareValue.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void NotInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (CompareValue.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void NotNegativeInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (CompareValue.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void NotPositiveInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (CompareValue.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
