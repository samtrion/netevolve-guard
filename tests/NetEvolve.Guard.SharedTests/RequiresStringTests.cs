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
      _ = Assert.Throws<ArgumentNullException>(() => Requires.NotNullOrEmpty(value));
    }
    else if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(() => Requires.NotNullOrEmpty(value));
    }
    else
    {
      _ = Requires.NotNullOrEmpty(value);
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
      _ = Assert.Throws<ArgumentNullException>(() => Requires.NotNullOrWhiteSpace(value));
    }
    else if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(() => Requires.NotNullOrWhiteSpace(value));
    }
    else
    {
      _ = Requires.NotNullOrWhiteSpace(value);
    }
  }
}
