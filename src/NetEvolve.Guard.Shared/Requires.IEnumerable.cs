namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  public static void ItemsNotNull<T>([NotNull] IEnumerable<T?> value, [CallerArgumentExpression("value")] string? parameterName = null) where T : class
  {
    if (value.Any(ValueIsNull))
    {
      throw new ArgumentException(null, parameterName);
    }

    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  [StackTraceHidden]
  public static void ItemsNotNullOrEmpty([NotNull] IEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value.Any(string.IsNullOrEmpty))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void ItemsNotNullOrWhiteSpace([NotNull] IEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value.Any(string.IsNullOrWhiteSpace))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  [return: NotNull]
  public static IEnumerable<T> NotNullOrEmpty<T>([NotNull] IEnumerable<T>? value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if ((value.TryGetNonEnumeratedCount(out var count) && 0u == (uint)count) || !value.Any())
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }
}
