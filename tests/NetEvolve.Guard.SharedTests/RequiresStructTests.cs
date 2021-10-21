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
      _ = Assert.Throws<ArgumentException>( () => Requires.NotDefault( value));
    }
    else
    {
      Requires.NotDefault( value);
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
      _ = Assert.Throws<ArgumentNullException>( () => Requires.NotNull( value));
    }
    else
    {
      Requires.NotNull( value);
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
      _ = Assert.Throws(value.HasValue ? typeof(ArgumentException) : typeof(ArgumentNullException), () => Requires.NotNullOrDefault( value));
    }
    else
    {
      Requires.NotNullOrDefault( value);
    }
  }
}
