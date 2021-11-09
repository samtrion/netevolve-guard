namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  public static void IsReadable(Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanRead)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void IsSeekable(Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanSeek)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void IsWritable(Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanWrite)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void NotEmpty(Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
