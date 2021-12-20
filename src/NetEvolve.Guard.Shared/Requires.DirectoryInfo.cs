namespace NetEvolve.Guard;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

public static partial class Requires
{
  /// <summary>
  /// Determines if <paramref name="value"/> exists.
  /// </summary>
  /// <param name="value">Value to be verified.</param>
  /// <exception cref="DirectoryNotFoundException">When <paramref name="value"/> not exists.</exception>
  [StackTraceHidden]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Exists([NotNull] DirectoryInfo value)
  {
    if (!value.Exists)
    {
      throw new DirectoryNotFoundException();
    }
  }
}
