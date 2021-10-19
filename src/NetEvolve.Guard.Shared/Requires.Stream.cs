namespace NetEvolve.Guard;

using System;
using System.IO;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void IsReadable(string? parameterName, Stream value)
  {
    if (!value.CanRead)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void IsSeekable(string? parameterName, Stream value)
  {
    if (!value.CanSeek)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void IsWritable(string? parameterName, Stream value)
  {
    if (!value.CanWrite)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotEmpty(string? parameterName, Stream value)
  {
    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
