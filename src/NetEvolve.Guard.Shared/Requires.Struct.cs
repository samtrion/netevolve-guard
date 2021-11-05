namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  public static void NotDefault<T>(T value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
  {
    if (value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [return: NotNull]
  public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = null) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value.Value;
  }

  [return: NotNull]
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
