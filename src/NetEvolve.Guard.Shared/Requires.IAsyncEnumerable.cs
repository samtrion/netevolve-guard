#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public static partial class Requires
{
  [StackTraceHidden]
  public static async ValueTask ItemsNotNullAsync<T>([NotNull] IAsyncEnumerable<T?> value, [CallerArgumentExpression("value")] string? parameterName = null) where T : class
  {
    if (await value.InternalAnyAsync(ValueIsNull))
    {
      throw new ArgumentException(null, parameterName);
    }

    static bool ValueIsNull([NotNullWhen(false)] T? value) => value is null;
  }

  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrEmptyAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (await value.InternalAnyAsync(string.IsNullOrEmpty))
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static async ValueTask ItemsNotNullOrWhiteSpaceAsync([NotNull] IAsyncEnumerable<string?> value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (await value.InternalAnyAsync(string.IsNullOrWhiteSpace))
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

    if (!await value.InternalAnyAsync())
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  private static async ValueTask<bool> InternalAnyAsync<T>(this IAsyncEnumerable<T> value)
  {
    await using (var enumerator = value.GetAsyncEnumerator())
    {
      return await enumerator.MoveNextAsync();
    }
  }

  [StackTraceHidden]
  private static async ValueTask<bool> InternalAnyAsync<T>(this IAsyncEnumerable<T> value, Func<T, bool> predicate)
  {
    await foreach (var item in value.ConfigureAwait(false))
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
