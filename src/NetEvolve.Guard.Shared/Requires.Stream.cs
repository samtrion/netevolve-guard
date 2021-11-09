namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  [StackTraceHidden]
  public static void IsReadable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanRead)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void IsSeekable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanSeek)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void IsWritable([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (!value.CanWrite)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  [StackTraceHidden]
  public static void NotEmpty([NotNull] Stream value, [CallerArgumentExpression("value")] string? parameterName = default)
  {
    if (0u == (uint)value.Length)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
