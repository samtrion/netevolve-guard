namespace NetEvolve.Guard;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static class Ensure
{
  public static TTarget Cast<T, TTarget>(string? parameterName, [NotNull] T? value)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value is not TTarget target)
    {
      throw new ArgumentException(null, parameterName);
    }

    return target;
  }

  public static void That<T>(string? parameterName, T value, [NotNull] Expression<Predicate<T>> expression)
  {
    if (expression is null)
    {
      throw new ArgumentNullException(nameof(expression));
    }

    var compiled = expression.Compile();
    if (!compiled.Invoke(value))
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
