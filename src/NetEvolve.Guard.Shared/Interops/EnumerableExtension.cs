#if !NET6_0_OR_GREATER
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
internal static class EnumerableExtension
{
  /// <summary>
  ///   Attempts to determine the number of elements in a sequence without forcing an enumeration.
  /// </summary>
  /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
  /// <param name="source">A sequence that contains elements to be counted.</param>
  /// <param name="count">
  ///     When this method returns, contains the count of <paramref name="source" /> if successful,
  ///     or zero if the method failed to determine the count.</param>
  /// <returns>
  ///   <see langword="true" /> if the count of <paramref name="source"/> can be determined without enumeration;
  ///   otherwise, <see langword="false" />.
  /// </returns>
  /// <remarks>
  ///   The method performs a series of type tests, identifying common subtypes whose
  ///   count can be determined without enumerating; this includes <see cref="ICollection{T}"/>,
  ///   <see cref="ICollection"/> as well as internal types used in the LINQ implementation.
  ///
  ///   The method is typically a constant-time operation, but ultimately this depends on the complexity
  ///   characteristics of the underlying collection implementation.
  /// </remarks>
  public static bool TryGetNonEnumeratedCount<TSource>(this IEnumerable<TSource> source, out int count)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    if (source is ICollection<TSource> collectionoft)
    {
      count = collectionoft.Count;
      return true;
    }

    if (source is ICollection collection)
    {
      count = collection.Count;
      return true;
    }

    count = 0;
    return false;
  }
}
#endif
