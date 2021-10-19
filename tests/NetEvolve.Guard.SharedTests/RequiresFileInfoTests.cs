namespace NetEvolve.Guard.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresFileInfoTests
{
  [Theory]
  [MemberData(nameof(GetExistsData))]
  public void Exists_Theory_Expected(bool throwException, string filePath)
  {
    var file = new FileInfo(filePath);
    if (throwException)
    {
      _ = Assert.Throws<FileNotFoundException>(() => Requires.Exists(file));
    }
    else
    {
      Requires.Exists(file);
    }
  }

  public static TheoryData GetExistsData => new TheoryData<bool, string>
  {
    { true, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())},
#if NET5_0_OR_GREATER
    { false, typeof(RequiresFileInfoTests).Assembly.Location }
#else
    { false, new System.Uri(typeof(RequiresFileInfoTests).Assembly.CodeBase!).LocalPath }
#endif
  };
}
