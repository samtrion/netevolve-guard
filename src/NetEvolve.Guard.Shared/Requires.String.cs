namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static string NotNullOrEmpty(string? parameterName, [NotNull] string? value)
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

  public static string NotNullOrWhiteSpace(string? parameterName, [NotNull] string? value)
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
