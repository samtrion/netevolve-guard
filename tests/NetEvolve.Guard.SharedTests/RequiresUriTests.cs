namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresUriTests
{
  [Theory]
  [MemberData(nameof(GetUriData), parameters: true)]
  public void IsAbsolute_Theory_Expected(bool throwException, string url)
  {
    var uri = new Uri(url, UriKind.RelativeOrAbsolute);
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(() => Requires.IsAbsolute(uri));
    }
    else
    {
      Requires.IsAbsolute(uri);
    }
  }

  [Theory]
  [MemberData(nameof(GetUriData), parameters: false)]
  public void IsRelative_Theory_Expected(bool throwException, string url)
  {
    var uri = new Uri(url, UriKind.RelativeOrAbsolute);
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(() => Requires.IsRelative(uri));
    }
    else
    {
      Requires.IsRelative(uri);
    }
  }
  public static TheoryData GetUriData(bool invert) => new TheoryData<bool, string>
  {
    { true ^ invert, "https://www.google.de/" },
    { false ^ invert, "://www.google.de" },
    { false ^ invert, "/default.aspx" }
  };
}
