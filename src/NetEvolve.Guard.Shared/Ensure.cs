namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

/// <summary>
/// Common runtime checks that throw <see cref="ArgumentException"/> on failure.
/// </summary>
public static class Ensure
{
  [StackTraceHidden]
  [return: NotNull]
  public static TTarget Cast<T, TTarget>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = default)
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

  [StackTraceHidden]
  public static void That<T>(T value, [NotNull] Expression<Predicate<T>> expression, [CallerArgumentExpression("value")] string? parameterName = default)
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
