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
    public static void NotPow2<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : IBinaryNumber<T>
    {
        if (!T.IsPow2(value))
        {
            throw new ArgumentException(null, parameterName);
        }
    }
}
#endif
