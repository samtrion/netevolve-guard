namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  [return: NotNull]
  public static string NotNullOrEmpty([NotNull] string? value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }

  [StackTraceHidden]
  [return: NotNull]
  public static string NotNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (IsWhiteSpace(value))
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }

  [DebuggerStepThrough]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [StackTraceHidden]
  private static bool IsWhiteSpace(string value)
  {
    for (var i = 0; i < value.Length; i++)
    {
      if (!char.IsWhiteSpace(value[i]))
      {
        return false;
      }
    }

    return true;
  }
}
