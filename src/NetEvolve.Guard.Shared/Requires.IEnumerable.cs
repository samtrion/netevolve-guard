namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void ItemsNotNull<T>(string? parameterName, [NotNull] IEnumerable<T?> value) where T : class
  {
    if (value.Any(ValueIsNull))
    {
      throw new ArgumentException(null, parameterName);
    }

    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  public static void ItemsNotNullOrEmpty(string? parameterName, [NotNull] IEnumerable<string?> value)
  {
    if (value.Any(string.IsNullOrEmpty))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void ItemsNotNullOrWhiteSpace(string? parameterName, [NotNull] IEnumerable<string?> value)
  {
    if (value.Any(string.IsNullOrWhiteSpace))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotNullOrEmpty<T>(string? parameterName, [NotNull] IEnumerable<T> value)
  {
    if ((value is ICollection<T> collection && 0u == (uint)collection.Count) || !value.Any())
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
