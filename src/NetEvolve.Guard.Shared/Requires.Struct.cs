namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void NotDefault<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
  {
    if (value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value.Value;
  }

  public static T NotNullOrDefault<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }

    return value.Value;
  }
}
