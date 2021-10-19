namespace NetEvolve.Guard;
using System.IO;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void Exists(DirectoryInfo value)
  {
    if (!value.Exists)
    {
      throw new DirectoryNotFoundException($"Direc");
    }
  }
}
