#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard;

using System;
using System.Runtime.Versioning;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
    [RequiresPreviewFeatures]
    public static void InBetween<T>(string? parameterName, T value, T minValue, T maxValue) where T : IComparisonOperators<T, T>
    {
        if (minValue <= value != value <= maxValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, null);
        }
    }

    [RequiresPreviewFeatures]
    public static void GreaterThan<T>(string? parameterName, T value, T compareValue) where T : IComparisonOperators<T, T>
    {
        if (value <= compareValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, null);
        }
    }

    [RequiresPreviewFeatures]
    public static void GreaterThanOrEqual<T>(string? parameterName, T value, T compareValue) where T : IComparisonOperators<T, T>
    {
        if (value < compareValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, null);
        }
    }

    [RequiresPreviewFeatures]
    public static void LessThan<T>(string? parameterName, T value, T compareValue) where T : IComparisonOperators<T, T>
    {
        if (value >= compareValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, null);
        }
    }

    [RequiresPreviewFeatures]
    public static void LessThanOrEqual<T>(string? parameterName, T value, T compareValue) where T : IComparisonOperators<T, T>
    {
        if (value > compareValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, null);
        }
    }
}
#endif
