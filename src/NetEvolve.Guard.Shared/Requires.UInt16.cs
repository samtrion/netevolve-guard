#if !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Runtime.CompilerServices;
using CompareValue = System.UInt16;

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

#if NET6_0_OR_GREATER
  public static void NotPow2(CompareValue value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!System.Numerics.BitOperations.IsPow2(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
#endif
}
#endif
