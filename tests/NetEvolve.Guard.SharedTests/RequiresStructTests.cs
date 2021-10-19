namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresStructTests
{
  [Theory]
  [InlineData(true, default(int))]
  [InlineData(false, 5)]
  public void NotDefault_Theory_Expected(bool throwException, int value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotDefault(nameof(value), value));
    }
    else
    {
      Requires.NotDefault(nameof(value), value);
    }
  }

  [Theory]
  [InlineData(true, null)]
  [InlineData(false, default(int))]
  [InlineData(false, 5)]
  public void NotNull_Theory_Expected(bool throwException, int? value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentNullException>(nameof(value), () => Requires.NotNull(nameof(value), value));
    }
    else
    {
      Requires.NotNull(nameof(value), value);
    }
  }

  [Theory]
  [InlineData(true, null)]
  [InlineData(true, default(int))]
  [InlineData(false, 5)]
  public void NotNullOrDefault_Theory_Expected(bool throwException, int? value)
  {
    if (throwException)
    {
      _ = Assert.Throws(value.HasValue ? typeof(ArgumentException) : typeof(ArgumentNullException), () => Requires.NotNullOrDefault(nameof(value), value));
    }
    else
    {
      Requires.NotNullOrDefault(nameof(value), value);
    }
  }
}
