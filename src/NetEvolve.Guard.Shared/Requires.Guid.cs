namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if a value is <see cref="Guid.Empty"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
  [StackTraceHidden]
  public static void NotEmpty(Guid value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if a value is not <see langword="null"/> or <see cref="Guid.Empty"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A non-<see langword="null"/> <see cref="Guid"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
  [StackTraceHidden]
  [return: NotNull]
  public static Guid NotNullOrEmpty(Guid? value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }

    return value.Value;
  }
}
