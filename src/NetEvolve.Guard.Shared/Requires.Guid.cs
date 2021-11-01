namespace NetEvolve.Guard;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void NotEmpty(Guid value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static Guid NotNullOrEmpty(Guid? value, [CallerArgumentExpression("value")] string? parameterName = null)
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }

    return value.Value;
  }
}
