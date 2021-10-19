namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static T NotNull<T>(string? parameterName, [NotNull] T? value) where T : class
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value;
  }
}
