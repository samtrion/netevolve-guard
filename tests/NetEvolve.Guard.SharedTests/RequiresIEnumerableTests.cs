namespace NetEvolve.Guard.Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresIEnumerableTests
{
  [Theory]
  [MemberData(nameof(GetItemsNotNullData))]
  public void ItemsNotNull_Theory_Expected(bool throwException, IEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(values), () => Requires.ItemsNotNull(nameof(values), values));
    }
    else
    {
      Requires.ItemsNotNull(nameof(values), values);
    }
  }

  [Theory]
  [MemberData(nameof(GetItemsNotNullOrEmptyData))]
  public void ItemsNotNullOrEmpty_Theory_Expected(bool throwException, IEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(values), () => Requires.ItemsNotNullOrEmpty(nameof(values), values));
    }
    else
    {
      Requires.ItemsNotNullOrEmpty(nameof(values), values);
    }
  }

  [Theory]
  [MemberData(nameof(GetItemsNotNullOrWhiteSpaceData))]
  public void ItemsNotNullOrWhiteSpace_Theory_Expected(bool throwException, IEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(values), () => Requires.ItemsNotNullOrWhiteSpace(nameof(values), values));
    }
    else
    {
      Requires.ItemsNotNullOrWhiteSpace(nameof(values), values);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotNullOrEmptyData))]
  public void NotNullOrEmpty_Theory_Expected(bool throwException, IEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(values), () => Requires.NotNullOrEmpty(nameof(values), values));
    }
    else
    {
      Requires.NotNullOrEmpty(nameof(values), values);
    }
  }

  public static TheoryData GetItemsNotNullData => new TheoryData<bool, IEnumerable<string?>>
  {
    { false, Array.Empty<string?>() },
    { false, Enumerable.Empty<string?>() },
    { true, new string?[] { "Hello", null, "World!" } },
    { false, new string?[] { "Hello", string.Empty, "World!" } },
    { false, new string?[] { "Hello", " ", "World!" } },
  };

  public static TheoryData GetItemsNotNullOrEmptyData => new TheoryData<bool, IEnumerable<string?>>
  {
    { false, Array.Empty<string?>() },
    { false, Enumerable.Empty<string?>() },
    { true, new string?[] { "Hello", null, "World!" } },
    { true, new string?[] { "Hello", string.Empty, "World!" } },
    { false, new string?[] { "Hello", " ", "World!" } },
  };

  public static TheoryData GetItemsNotNullOrWhiteSpaceData => new TheoryData<bool, IEnumerable<string?>>
  {
    { false, Array.Empty<string?>() },
    { false, Enumerable.Empty<string?>() },
    { true, new string?[] { "Hello", null, "World!" } },
    { true, new string?[] { "Hello", string.Empty, "World!" } },
    { true, new string?[] { "Hello", " ", "World!" } },
  };

  public static TheoryData GetNotNullOrEmptyData => new TheoryData<bool, IEnumerable<string?>>
  {
    { true, Array.Empty<string?>() },
    { true, Enumerable.Empty<string?>() },
    { false, new string?[] { "Hello", null, "World!" } },
    { false, new string?[] { "Hello", string.Empty, "World!" } },
    { false, new string?[] { "Hello", " ", "World!" } },
  };
}
