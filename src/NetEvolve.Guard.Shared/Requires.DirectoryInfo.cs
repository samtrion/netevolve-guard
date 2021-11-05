namespace NetEvolve.Guard;

using System.Diagnostics;
using System.IO;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  [StackTraceHidden]
  public static void Exists(DirectoryInfo value)
  {
    if (!value.Exists)
    {
      throw new DirectoryNotFoundException();
    }
  }
}
