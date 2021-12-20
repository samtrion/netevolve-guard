namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if the <paramref name="value"/> is <see langword="default{T}"/>.
  /// </summary>
  /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see langword="default{T}"/>.</exception>
  [StackTraceHidden]
  public static void NotDefault<T>(T value, [CallerArgumentExpression("value")] string? parameterName = default) where T : struct
  {
    if (value.Equals(default(T)))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if the <paramref name="value"/> is <see langword="null"/>.
  /// </summary>
  /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A not-null <typeparamref name="T"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  [StackTraceHidden]
  [return: NotNull]
  public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = default) where T : struct
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value.Value;
  }

  /// <summary>
  /// Determines if the <paramref name="value"/> is <see langword="null"/> or <see langword="default{T}"/>.
  /// </summary>
  /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A not-null <typeparamref name="T"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see langword="default{T}"/>.</exception>
  [StackTraceHidden]
  [return: NotNull]
  public static T NotNullOrDefault<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = default) where T : struct
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
