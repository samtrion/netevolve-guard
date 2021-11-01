namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresObjectTests
{
  [Theory]
  [InlineData(true, null)]
  [InlineData(false, "")]
  [InlineData(false, "Hello World!")]
  public void NotNull_Theory_Expected(bool throwException, string? value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentNullException>(() => Requires.NotNull(value));
    }
    else
    {
      _ = Requires.NotNull(value);
    }
  }
}
