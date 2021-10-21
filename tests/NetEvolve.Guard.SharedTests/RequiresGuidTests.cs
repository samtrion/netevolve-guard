namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresGuidTests
{
  [Theory]
  [InlineData(true, "00000000-0000-0000-0000-000000000000")]
  [InlineData(false, "00000000-0000-0000-0000-000000000001")]
  public void NotEmpty_Theory_Expected(bool throwException, string valueString)
  {
    var value = Guid.Parse(valueString);
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>( () => Requires.NotEmpty( value));
    }
    else
    {
      Requires.NotEmpty( value);
    }
  }

  [Theory]
  [InlineData(true, false, null)]
  [InlineData(false, true, "00000000-0000-0000-0000-000000000000")]
  [InlineData(false, false, "00000000-0000-0000-0000-000000000001")]
  public void NotNullOrEmpty_Theory_Expected(bool throwExceptionNull, bool throwException, string? valueString)
  {
    Guid? value = valueString is not null ? Guid.Parse(valueString) : null;
    if (throwExceptionNull)
    {
      _ = Assert.Throws<ArgumentNullException>( () => Requires.NotNullOrEmpty( value));
    }
    else if (throwException)
    {
      _ = Assert.Throws<ArgumentException>( () => Requires.NotNullOrEmpty( value));
    }
    else
    {
      Requires.NotNullOrEmpty( value);
    }
  }
}
