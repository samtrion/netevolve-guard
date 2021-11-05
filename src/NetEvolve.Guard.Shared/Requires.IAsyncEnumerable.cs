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
  [StackTraceHidden]
  public static async ValueTask ItemsNotNullAsync<T>([NotNull] IAsyncEnumerable<T?> value, [CallerArgumentExpression("value")] string? parameterName = null, CancellationToken cancellationToken = default) where T : class
  {
    if (await value.InternalAnyAsync(ValueIsNull, cancellationToken))
    {
      throw new ArgumentException(null, parameterName);
    }

    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrEmptyAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null, CancellationToken cancellationToken = default)
  {
    if (await value.InternalAnyAsync(string.IsNullOrEmpty, cancellationToken))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrWhiteSpaceAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null, CancellationToken cancellationToken = default)
  {
    if (await value.InternalAnyAsync(string.IsNullOrWhiteSpace, cancellationToken))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  [return: NotNull]
  public static async ValueTask NotNullOrEmptyAsync<T>([NotNull] IAsyncEnumerable<T>? value, [CallerArgumentExpression("value")] string? parameterName = null)
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