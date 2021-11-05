#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
namespace NetEvolve.Guard.Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresIAsyncEnumerableTests
{
  [Theory]
  [MemberData(nameof(GetItemsNotNullData))]
  public async ValueTask ItemsNotNull_Theory_Expected(bool throwException, IAsyncEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = await Assert.ThrowsAsync<ArgumentException>(nameof(values), async () => await Requires.ItemsNotNullAsync(values));
    }
    else
    {
      await Requires.ItemsNotNullAsync(values);
    }
  }

  [Theory]
  [MemberData(nameof(GetItemsNotNullOrEmptyData))]
  public async ValueTask ItemsNotNullOrEmpty_Theory_Expected(bool throwException, IAsyncEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = await Assert.ThrowsAsync<ArgumentException>(nameof(values), async () => await Requires.ItemsNotNullOrEmptyAsync(values));
    }
    else
    {
      await Requires.ItemsNotNullOrEmptyAsync(values);
    }
  }

  [Theory]
  [MemberData(nameof(GetItemsNotNullOrWhiteSpaceData))]
  public async ValueTask ItemsNotNullOrWhiteSpace_Theory_Expected(bool throwException, IAsyncEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = await Assert.ThrowsAsync<ArgumentException>(nameof(values), async () => await Requires.ItemsNotNullOrWhiteSpaceAsync(values));
    }
    else
    {
      await Requires.ItemsNotNullOrWhiteSpaceAsync(values);
    }
  }

  [Fact]
  public async ValueTask NotNullOrEmpty_Null_ArgumentNullException()
  {
    IAsyncEnumerable<string>? values = null;

    _ = await Assert.ThrowsAsync<ArgumentNullException>(nameof(values), async () => await Requires.NotNullOrEmptyAsync(values));
  }

  [Theory]
  [MemberData(nameof(GetNotNullOrEmptyData))]
  public async ValueTask NotNullOrEmpty_Theory_Expected(bool throwException, IAsyncEnumerable<string?> values)
  {
    if (throwException)
    {
      _ = await Assert.ThrowsAsync<ArgumentException>(nameof(values), async () => await Requires.NotNullOrEmptyAsync(values));
    }
    else
    {
      await Requires.NotNullOrEmptyAsync(values);
    }
  }

  public static TheoryData GetItemsNotNullData => new TheoryData<bool, IAsyncEnumerable<string?>>
  {
    { false, AsyncEnumerable.Empty<string?>() },
    { true,  new string?[] { "Hello", null, "World!" }.ToAsyncEnumerable() },
    { false, new string?[] { "Hello", string.Empty, "World!" }.ToAsyncEnumerable() },
    { false, new string?[] { "Hello", " ", "World!" }.ToAsyncEnumerable() },
  };

  public static TheoryData GetItemsNotNullOrEmptyData => new TheoryData<bool, IAsyncEnumerable<string?>>
  {
    { false, AsyncEnumerable.Empty<string?>() },
    { true, new string?[] { "Hello", null, "World!" }.ToAsyncEnumerable() },
    { true, new string?[] { "Hello", string.Empty, "World!" }.ToAsyncEnumerable() },
    { false, new string?[] { "Hello", " ", "World!" }.ToAsyncEnumerable() },
  };

  public static TheoryData GetItemsNotNullOrWhiteSpaceData => new TheoryData<bool, IAsyncEnumerable<string?>>
  {
    { false, AsyncEnumerable.Empty<string?>() },
    { true, new string?[] { "Hello", null, "World!" }.ToAsyncEnumerable() },
    { true, new string?[] { "Hello", string.Empty, "World!" }.ToAsyncEnumerable() },
    { true, new string?[] { "Hello", " ", "World!" }.ToAsyncEnumerable() },
  };

  public static TheoryData GetNotNullOrEmptyData => new TheoryData<bool, IAsyncEnumerable<string?>>
  {
    { true, AsyncEnumerable.Empty<string?>() },
    { false, new string?[] { "Hello", null, "World!" }.ToAsyncEnumerable() },
    { false, new string?[] { "Hello", string.Empty, "World!" }.ToAsyncEnumerable() },
    { false, new string?[] { "Hello", " ", "World!" }.ToAsyncEnumerable() },
  };
}
#endif
