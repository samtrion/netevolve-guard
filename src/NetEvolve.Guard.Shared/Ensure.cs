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
  public static void That<T>(
    T value,
    [NotNull] Expression<Predicate<T>> conditionExpression,
    [CallerArgumentExpression("value")] string? parameterName = default,
    [CallerArgumentExpression("conditionExpression")] string? conditionString = default)
  {
    if (conditionExpression is null)
    {
      throw new ArgumentNullException(nameof(conditionExpression));
    }

    var compiled = conditionExpression.Compile();
    if (!compiled.Invoke(value))
    {
      throw new ArgumentException(string.IsNullOrWhiteSpace(conditionString) ? "Condition failed" : $"Condition failed: '{conditionString}'", parameterName);
    }
  }
}
