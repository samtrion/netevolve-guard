#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> elements are not <see langword="null"/>.
  /// </summary>
  /// <typeparam name="T">Enumeration element type</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <param name="cancellationToken">Optional <see cref="CancellationToken"/>.</param>
  /// <returns><see cref="ValueTask"/>.</returns>
  /// <exception cref="ArgumentException">When an element is <see langword="null"/>.</exception>
  [StackTraceHidden]
  public static async ValueTask ItemsNotNullAsync<T>([NotNull] IAsyncEnumerable<T?> value, [CallerArgumentExpression("value")] string? parameterName = default, CancellationToken cancellationToken = default) where T : class
  {
    if (await value.InternalAnyAsync(ValueIsNull, cancellationToken).ConfigureAwait(false))
    {
      throw new ArgumentException(null, parameterName);
    }

    [StackTraceHidden]
    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  /// <summary>
  /// Determines if <paramref name="value"/> elements are not <see langword="null"/> or <see cref="string.Empty"/>.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <param name="cancellationToken">Optional <see cref="CancellationToken"/>.</param>
  /// <returns><see cref="ValueTask"/>.</returns>
  /// <exception cref="ArgumentException">When an element is <see langword="null"/> or <see cref="string.Empty"/>.</exception>
  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrEmptyAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = default, CancellationToken cancellationToken = default)
  {
    if (await value.InternalAnyAsync(string.IsNullOrEmpty, cancellationToken).ConfigureAwait(false))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> elements are not <see langword="null"/> or whitespace.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <param name="cancellationToken">Optional <see cref="CancellationToken"/>.</param>
  /// <returns><see cref="ValueTask"/>.</returns>
  /// <exception cref="ArgumentException">When an element is <see langword="null"/> or whitespace.</exception>
  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrWhiteSpaceAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = default, CancellationToken cancellationToken = default)
  {
    if (await value.InternalAnyAsync(string.IsNullOrWhiteSpace, cancellationToken).ConfigureAwait(false))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  /// <summary>
  /// Determines if <paramref name="value"/> is not <see langword="null"/> or <see cref="string.Empty"/>.
  /// </summary>
  /// <typeparam name="T">Enumeration element type</typeparam>
  /// <param name="value">Value to be verified.</param>
  /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
  /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">When <paramref name="value"/> has no elements.</exception>
  [StackTraceHidden]
  [return: NotNull]
  public static async ValueTask NotNullOrEmptyAsync<T>([NotNull] IAsyncEnumerable<T>? value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (value is null)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (!await value.InternalAnyAsync().ConfigureAwait(false))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  [SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "False positive")]
  private static async ValueTask<bool> InternalAnyAsync<T>(this IAsyncEnumerable<T> value)
  {
    await using (var enumerator = value.GetAsyncEnumerator())
    {
      return await enumerator.MoveNextAsync().ConfigureAwait(false);
    }
  }

  [StackTraceHidden]
  private static async ValueTask<bool> InternalAnyAsync<T>(this IAsyncEnumerable<T> value, Func<T, bool> predicate, CancellationToken cancellationToken)
  {
    await foreach (var item in value.WithCancellation(cancellationToken).ConfigureAwait(false))
    {
      if (predicate(item))
      {
        return true;
      }
    }

    return false;
  }
}
#endif
