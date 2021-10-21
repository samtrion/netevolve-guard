#if NET5_0_OR_GREATER && !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Runtime.CompilerServices;
using CompareValue = System.Half;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void InBetween(CompareValue value, CompareValue minValue, CompareValue maxValue, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void GreaterThan(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void GreaterThanOrEqual(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void LessThan(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void LessThanOrEqual(CompareValue value, CompareValue compareValue, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void NotNaN(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (CompareValue.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (CompareValue.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotNegativeInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (CompareValue.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotPositiveInfinity(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (CompareValue.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
