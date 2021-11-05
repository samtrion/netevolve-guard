namespace NetEvolve.Guard;

using System.IO;

public static partial class Requires
{
  public static void Exists(DirectoryInfo value)
  {
    if (!value.Exists)
    {
      throw new DirectoryNotFoundException();
    }
  }
}
