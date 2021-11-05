namespace NetEvolve.Guard;

using System;
using System.IO;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  public static void IsReadable(Stream value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.CanRead)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void IsSeekable(Stream value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.CanSeek)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void IsWritable(Stream value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.CanWrite)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotEmpty(Stream value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
