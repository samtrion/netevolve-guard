namespace NetEvolve.Guard;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

public static partial class Requires
{
  [StackTraceHidden]
  public static void Exists([NotNull] DirectoryInfo value)
  {
    if (!value.Exists)
    {
      throw new DirectoryNotFoundException();
    }
  }
}
