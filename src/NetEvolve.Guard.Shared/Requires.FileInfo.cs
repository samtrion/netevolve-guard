namespace NetEvolve.Guard;

using System.IO;

public static partial class Requires
{
  public static void Exists(FileInfo value)
  {
    if (!value.Exists)
    {
      throw new FileNotFoundException(null, value.Name);
    }
  }
}
