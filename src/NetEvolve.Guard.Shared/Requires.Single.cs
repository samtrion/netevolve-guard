#if !USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using CompareValue = System.Single;

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

  public static void NotNaN(string? parameterName, CompareValue value)
  {
    if (CompareValue.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotInfinity(string? parameterName, CompareValue value)
  {
    if (CompareValue.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotNegativeInfinity(string? parameterName, CompareValue value)
  {
    if (CompareValue.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotPositiveInfinity(string? parameterName, CompareValue value)
  {
    if (CompareValue.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
