namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> is <see langword="null"/>.
  /// </summary>
  /// <typeparam name="T">Type of <see langword="object"/>.</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A non-<see langword="null"/> <typeparamref name="T"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  [StackTraceHidden]
  [return: NotNull]
  public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? parameterName = default) where T : class
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    return value;
  }
}
