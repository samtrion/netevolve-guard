namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  [return: NotNull]
  public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = null) where T : class
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value;
  }
}
