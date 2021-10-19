#if NET6_0_OR_GREATER && !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using CompareValue = System.DateOnly;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void InBetween(string? parameterName, CompareValue value, CompareValue minValue, CompareValue maxValue)
  {
    if (minValue <= value != value <= maxValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void GreaterThan(string? parameterName, CompareValue value, CompareValue compareValue)
  {
    if (value <= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void GreaterThanOrEqual(string? parameterName, CompareValue value, CompareValue compareValue)
  {
    if (value < compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void LessThan(string? parameterName, CompareValue value, CompareValue compareValue)
  {
    if (value >= compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }

  public static void LessThanOrEqual(string? parameterName, CompareValue value, CompareValue compareValue)
  {
    if (value > compareValue)
    {
      throw new ArgumentOutOfRangeException(parameterName, value, null);
    }
  }
}
#endif
