namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  public static void NotEmpty(Guid value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  [return: NotNull]
  public static Guid NotNullOrEmpty(Guid? value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }

    return value.Value;
  }
}
