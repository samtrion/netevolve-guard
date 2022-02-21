#if NET5_0_OR_GREATER
namespace NetEvolve.Guard.Tests;

using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public sealed class RequiresHalfTests
{
  private static Half BaseValue { get; }
  private static Half MaxValue { get; } = Half.MaxValue;
  private static Half MinValue { get; } = Half.MinValue;
  private static Half NaN { get; } = Half.NaN;
  private static Half NegativeInfinity { get; } = Half.NegativeInfinity;
  private static Half PositiveInfinity { get; } = Half.PositiveInfinity;

  [Theory]
  [MemberData(nameof(GetInBetweenData))]
  public void InBetween_Theory_Expected(bool throwException, Half value, Half min, Half max)
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
  public void NotBetween_Theory_Expected(bool throwException, Half value, Half min, Half max)
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
  public void GreaterThan_Theory_Expected(bool throwException, Half value, Half compareValue)
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
  public void GreaterThanOrEqual_Theory_Expected(bool throwException, Half value, Half compareValue)
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
  public void LessThan_Theory_Expected(bool throwException, Half value, Half compareValue)
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
  public void LessThanOrEqual_Theory_Expected(bool throwException, Half value, Half compareValue)
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
  public void NotNaN_Theory_Expected(bool throwException, Half value)
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
  public void NotInfinity_Theory_Expected(bool throwException, Half value)
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
  public void NotNegativeInfinity_Theory_Expected(bool throwException, Half value)
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
  public void NotPositiveInfinity_Theory_Expected(bool throwException, Half value)
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

  public static TheoryData GetInBetweenData => new TheoryData<bool, Half, Half, Half>
    {
      { true, MinValue, BaseValue, MaxValue },
      { true, MaxValue, BaseValue, MinValue },
#if NET6_0_OR_GREATER
      // Known Issue for .NET 5 - https://github.com/dotnet/runtime/issues/49983
      { false, MinValue, MinValue, MaxValue },
#endif
      { false, MaxValue, MinValue, MaxValue },
      { false, BaseValue, MinValue, MaxValue },
      { false, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetNotBetweenData => new TheoryData<bool, Half, Half, Half>
    {
      { false, MinValue, BaseValue, MaxValue },
      { false, MaxValue, BaseValue, MinValue },
      { true, BaseValue, MinValue, MaxValue },
      { true, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetGreaterThanData => new TheoryData<bool, Half, Half>
    {
      { true, BaseValue, MaxValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetGreaterThanOrEqualData => new TheoryData<bool, Half, Half>
    {
      { true, BaseValue, MaxValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetLessThanData => new TheoryData<bool, Half, Half>
    {
      { true, BaseValue, MinValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetLessThanOrEqualData => new TheoryData<bool, Half, Half>
    {
      { true, BaseValue, MinValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetNotNaNData => new TheoryData<bool, Half>
    {
      { true, NaN },
      { false, BaseValue },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotInfinityData => new TheoryData<bool, Half>
    {
      { true, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotNegativeInfinityData => new TheoryData<bool, Half>
    {
      { false, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

  public static TheoryData GetNotPositiveInfinityData => new TheoryData<bool, Half>
    {
      { true, PositiveInfinity },
      { false, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };
}
#endif
