namespace NetEvolve.Guard.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresDirectoryInfoTests
{
  [Theory]
  [MemberData(nameof(GetExistsData))]
  public void Exists_Theory_Expected(bool throwException, string directoryPath)
  {
    var directory = new DirectoryInfo(directoryPath);
    if (throwException)
    {
      _ = Assert.Throws<DirectoryNotFoundException>(() => Requires.Exists(directory));
    }
    else
    {
      Requires.Exists(directory);
    }
  }

  public static TheoryData GetExistsData => new TheoryData<bool, string>
  {
    { true, "/does.not.exists/" },
    { false, Path.GetTempPath() }
  };
}
