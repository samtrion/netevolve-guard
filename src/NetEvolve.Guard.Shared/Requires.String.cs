namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> is not <see langword="null"/> or <see cref="string.Empty"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A non-<see langword="null"/> <see cref="string"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="string.Empty"/>.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [return: NotNull]
  public static string NotNullOrEmpty([NotNull] string? value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not <see langword="null"/> or whitespace.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <returns>A non-<see langword="null"/> <see cref="string"/>.</returns>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="string.Empty"/> or whitespace.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [return: NotNull]
  public static string NotNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (IsWhiteSpace(value))
    {
      throw new ArgumentException(null, parameterName);
    }

    return value;
  }

  [DebuggerStepThrough]
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool IsWhiteSpace(string value)
  {
    for (var i = 0; i < value.Length; i++)
    {
      if (!char.IsWhiteSpace(value[i]))
      {
        return false;
      }
    }

    return true;
  }
}
