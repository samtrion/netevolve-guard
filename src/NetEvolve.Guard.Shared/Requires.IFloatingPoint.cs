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
    public static void NotNaN<T>(string? parameterName, T value) where T : IFloatingPoint<T>
    {
        if (T.IsNaN(value))
        {
            throw new ArgumentException(null, parameterName);
        }
    }

    [RequiresPreviewFeatures]
    public static void NotInfinity<T>(string? parameterName, T value) where T : IFloatingPoint<T>
    {
        if (T.IsInfinity(value))
        {
            throw new ArgumentException(null, parameterName);
        }
    }

    [RequiresPreviewFeatures]
    public static void NotNegativeInfinity<T>(string? parameterName, T value) where T : IFloatingPoint<T>
    {
        if (T.IsNegativeInfinity(value))
        {
            throw new ArgumentException(null, parameterName);
        }
    }

    [RequiresPreviewFeatures]
    public static void NotPositiveInfinity<T>(string? parameterName, T value) where T : IFloatingPoint<T>
    {
        if (T.IsPositiveInfinity(value))
        {
            throw new ArgumentException(null, parameterName);
        }
    }
}
#endif
