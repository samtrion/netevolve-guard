namespace NetEvolve.Guard.Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

[ExcludeFromCodeCoverage]
public class EnsureTests
{
  [Fact]
  public void Cast_ValueNull_Exception()
  {
    List<string>? value = null;
    _ = Assert.Throws<ArgumentNullException>(() => Ensure.Cast<List<string>, IEnumerable<string>>(value));
  }

  [Fact]
  public void Cast_ValueInvalid_Exception()
  {
    var value = new List<string>();
    _ = Assert.Throws<ArgumentException>(() => Ensure.Cast<List<string>, IEnumerable<int?>>(value));
  }

  [Fact]
  public void Cast_ValueValid_Expected()
  {
    var value = new List<string>();
    _ = Ensure.Cast<List<string>, IEnumerable<string>>(value);
  }

  [Fact]
  public void That_ValueNull_Exception()
  {
    List<string>? value = null;
    _ = Assert.Throws<ArgumentNullException>("expression", () => Ensure.That(value, null!));
  }

  [Fact]
  public void That_ValueInvalid_Exception()
  {
    var value = new List<string>();
    _ = Assert.Throws<ArgumentException>(() => Ensure.That(value, x => x.Any()));
  }

  [Fact]
  public void That_ValueValue_Exception()
  {
    var value = new List<string> { "Hi" };
    Ensure.That(value, x => x.Any());
  }
}
