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
  public static void NotNaN<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : IFloatingPoint<T>
  {
    if (T.IsNaN(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : IFloatingPoint<T>
  {
    if (T.IsInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotNegativeInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : IFloatingPoint<T>
  {
    if (T.IsNegativeInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [RequiresPreviewFeatures]
  [StackTraceHidden]
  public static void NotPositiveInfinity<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : IFloatingPoint<T>
  {
    if (T.IsPositiveInfinity(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
#endif
