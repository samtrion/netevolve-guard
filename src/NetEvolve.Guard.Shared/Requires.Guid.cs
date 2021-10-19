namespace NetEvolve.Guard;

using System;

/// <summary>
/// Common runtime checks that throw Exceptions on failure.
/// </summary>
public static partial class Requires
{
  public static void NotEmpty(string? parameterName, Guid value)
  {
    if (value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }
  }

  public static void NotNullOrEmpty(string? parameterName, Guid? value)
  {
    if (!value.HasValue)
    {
      throw new ArgumentNullException(parameterName);
    }

    if (value.Value == Guid.Empty)
    {
      throw new ArgumentException(null, parameterName);
    }
  }
}
