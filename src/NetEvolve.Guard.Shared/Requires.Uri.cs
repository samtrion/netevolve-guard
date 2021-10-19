namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void IsAbsolute(string? parameterName, [NotNull] Uri value)
  {
    if (!value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
  public static void IsRelative(string? parameterName, [NotNull] Uri value)
  {
    if (value.IsAbsoluteUri)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
