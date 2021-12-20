namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Common runtime checks that throw <see cref="ArgumentException"/> on failure.
/// </summary>
public static class Ensure
{
  /// <summary>
  /// Attempts to cast the <paramref name="value"/> to the requested <typeparamref name="TTarget"/> type. If this is not possible, an <see cref="ArgumentException"/> is generated.
  /// </summary>
  /// <typeparam name="T">Type of <paramref name="value"/>.</typeparam>
  /// <typeparam name="TTarget">The expected return type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns><typeparamref name="TTarget"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> couldn't be cast to <typeparamref name="TTarget"/>.</exception>
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

  /// <summary>
  /// Validates <paramref name="value"/> with the <paramref name="expression"/>. If <see langword="false"/>, an <see cref="ArgumentException"/> is raised.
  /// </summary>
  /// <typeparam name="T">Type to be checked.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="expression">Validation expression for checking the type.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <param name="conditionString">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentNullException">When <paramref name="expression"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="expression"/> returns <see langword="false"/>.</exception>
  [StackTraceHidden]
  public static void That<T>(
    T value,
    [NotNull] Func<T, bool> expression,
    [CallerArgumentExpression("value")] string? parameterName = default,
    [CallerArgumentExpression("expression")] string? conditionString = default)
  {
    if (expression is null)
    {
      throw new ArgumentNullException(nameof(expression));
    }

    if (!expression.Invoke(value))
    {
      throw new ArgumentException(string.IsNullOrWhiteSpace(conditionString) ? "Condition failed" : $"Condition failed: '{conditionString}'", parameterName);
    }
  }
}
