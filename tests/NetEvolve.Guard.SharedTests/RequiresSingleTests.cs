namespace NetEvolve.Guard.Tests;

using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public sealed class RequiresSingleTests
{
  private static float BaseValue { get; }
  private static float MaxValue { get; } = float.MaxValue;
  private static float MinValue { get; } = float.MinValue;
  private static float NaN { get; } = float.NaN;
  private static float NegativeInfinity { get; } = float.NegativeInfinity;
  private static float PositiveInfinity { get; } = float.PositiveInfinity;

  [Theory]
  [MemberData(nameof(GetInBetweenData))]
  public void InBetween_Theory_Expected(bool throwException, float value, float min, float max)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.InBetween(value, min, max));
    }
    else
    {
      Requires.InBetween(value, min, max);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotBetweenData))]
  public void NotBetween_Theory_Expected(bool throwException, float value, float min, float max)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.NotBetween(value, min, max));
    }
    else
    {
      Requires.NotBetween(value, min, max);
    }
  }

  [Theory]
  [MemberData(nameof(GetGreaterThanData))]
  public void GreaterThan_Theory_Expected(bool throwException, float value, float compareValue)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThan(value, compareValue));
    }
    else
    {
      Requires.GreaterThan(value, compareValue);
    }
  }

  [Theory]
  [MemberData(nameof(GetGreaterThanOrEqualData))]
  public void GreaterThanOrEqual_Theory_Expected(bool throwException, float value, float compareValue)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThanOrEqual(value, compareValue));
    }
    else
    {
      Requires.GreaterThanOrEqual(value, compareValue);
    }
  }

  [Theory]
  [MemberData(nameof(GetLessThanData))]
  public void LessThan_Theory_Expected(bool throwException, float value, float compareValue)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThan(value, compareValue));
    }
    else
    {
      Requires.LessThan(value, compareValue);
    }
  }

  [Theory]
  [MemberData(nameof(GetLessThanOrEqualData))]
  public void LessThanOrEqual_Theory_Expected(bool throwException, float value, float compareValue)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThanOrEqual(value, compareValue));
    }
    else
    {
      Requires.LessThanOrEqual(value, compareValue);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotNaNData))]
  public void NotNaN_Theory_Expected(bool throwException, float value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNaN(value));
    }
    else
    {
      Requires.NotNaN(value);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotInfinityData))]
  public void NotInfinity_Theory_Expected(bool throwException, float value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotInfinity(value));
    }
    else
    {
      Requires.NotInfinity(value);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotNegativeInfinityData))]
  public void NotNegativeInfinity_Theory_Expected(bool throwException, float value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNegativeInfinity(value));
    }
    else
    {
      Requires.NotNegativeInfinity(value);
    }
  }

  [Theory]
  [MemberData(nameof(GetNotPositiveInfinityData))]
  public void NotPositiveInfinity_Theory_Expected(bool throwException, float value)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotPositiveInfinity(value));
    }
    else
    {
      Requires.NotPositiveInfinity(value);
    }
  }

  public static TheoryData GetInBetweenData => new TheoryData<bool, float, float, float>
    {
      { true, MinValue, BaseValue, MaxValue },
      { true, MaxValue, BaseValue, MinValue },
      { false, MinValue, MinValue, MaxValue },
      { false, MaxValue, MinValue, MaxValue },
      { false, BaseValue, MinValue, MaxValue },
      { false, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetNotBetweenData => new TheoryData<bool, float, float, float>
    {
      { false, MinValue, BaseValue, MaxValue },
      { false, MaxValue, BaseValue, MinValue },
      { true, BaseValue, MinValue, MaxValue },
      { true, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetGreaterThanData => new TheoryData<bool, float, float>
    {
      { true, BaseValue, MaxValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetGreaterThanOrEqualData => new TheoryData<bool, float, float>
    {
      { true, BaseValue, MaxValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetLessThanData => new TheoryData<bool, float, float>
    {
      { true, BaseValue, MinValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetLessThanOrEqualData => new TheoryData<bool, float, float>
    {
      { true, BaseValue, MinValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetNotNaNData => new TheoryData<bool, float>
    {
      { true, NaN },
      { false, BaseValue },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotInfinityData => new TheoryData<bool, float>
    {
      { true, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotNegativeInfinityData => new TheoryData<bool, float>
    {
      { false, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotPositiveInfinityData => new TheoryData<bool, float>
    {
      { true, PositiveInfinity },
      { false, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };
}
