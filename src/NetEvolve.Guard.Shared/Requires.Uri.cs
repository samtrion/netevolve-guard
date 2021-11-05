namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  public static void IsAbsolute([NotNull] Uri value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void IsRelative([NotNull] Uri value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
