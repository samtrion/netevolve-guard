namespace NetEvolve.Guard;

using System.Diagnostics;
using System.IO;

public static partial class Requires
{
  [StackTraceHidden]
  public static void Exists(FileInfo value)
  {
    if (!value.Exists)
    {
      throw new FileNotFoundException(null, value.Name);
    }
  }
}
