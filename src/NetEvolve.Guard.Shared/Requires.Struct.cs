namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void NotDefault<T>(string? parameterName, T value) where T : struct
  {
    if (value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotNull<T>(string? parameterName, [NotNull] T? value) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }
  }

  public static void NotNullOrDefault<T>(string? parameterName, [NotNull] T? value) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
