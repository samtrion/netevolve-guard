namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Checks if the enumeration items are not-<see langword="null"/>.
  /// </summary>
  /// <typeparam name="T">Item Type</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When one or more elements are <see langword="null"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ItemsNotNull<T>([NotNull] IEnumerable<T?> value, [CallerArgumentExpression("value")] string? parameterName = default) where T : class
  {
    if (value.Any(ValueIsNull))
    {
      throw new ArgumentException(null, parameterName);
    }

    [StackTraceHidden]
    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  /// <summary>
  /// Checks if the enumeration items are not-<see langword="null"/> or <see cref="string.Empty"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When one or more elements are <see langword="null"/> or <see cref="string.Empty"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ItemsNotNullOrEmpty([NotNull] IEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value.Any(string.IsNullOrEmpty))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Checks if the enumeration items are not-<see langword="null"/> or whitespace.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When one or more elements are <see langword="null"/> or whitespace.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ItemsNotNullOrWhiteSpace([NotNull] IEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value.Any(string.IsNullOrWhiteSpace))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Checks if the enumeration is non-<see langword="null"/> and contains elements.
  /// </summary>
  /// <typeparam name="T">Enumeration type.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A non-nullable enumeration of <typeparamref name="T"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> has no elements.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [return: NotNull]
  public static IEnumerable<T> NotNullOrEmpty<T>([NotNull] IEnumerable<T>? value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if ((value.TryGetNonEnumeratedCount(out var count) && 0u == (uint)count) || !value.Any())
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }
}
