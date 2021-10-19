namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresStringTests
{
  [Theory]
  [InlineData(true, false, null)]
  [InlineData(false, true, "")]
  [InlineData(false, false, " ")]
  [InlineData(false, false, "Hello World!")]
  public void NotNullOrEmpty_Theory_Expected(bool throwExceptionNull, bool throwException, string? value)
  {
    if (throwExceptionNull)
    {
      _ = Assert.Throws<ArgumentNullException>(nameof(value), () => Requires.NotNullOrEmpty(nameof(value), value));
    }
    else if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNullOrEmpty(nameof(value), value));
    }
    else
    {
      _ = Requires.NotNullOrEmpty(nameof(value), value);
    }
  }

  [Theory]
  [InlineData(true, false, null)]
  [InlineData(false, true, "")]
  [InlineData(false, true, " ")]
  [InlineData(false, false, "Hello World!")]
  public void NotNullOrWhiteSpace_Theory_Expected(bool throwExceptionNull, bool throwException, string? value)
  {
    if (throwExceptionNull)
    {
      _ = Assert.Throws<ArgumentNullException>(nameof(value), () => Requires.NotNullOrWhiteSpace(nameof(value), value));
    }
    else if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNullOrWhiteSpace(nameof(value), value));
    }
    else
    {
      _ = Requires.NotNullOrWhiteSpace(nameof(value), value);
    }
  }
}
