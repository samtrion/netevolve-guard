namespace NetEvolve.Guard.Tests;

using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public sealed class RequiresTimeSpanTests
{
  private static TimeSpan BaseValue { get; } = TimeSpan.Zero;
  private static TimeSpan MaxValue { get; } = TimeSpan.MaxValue;
  private static TimeSpan MinValue { get; } = TimeSpan.MinValue;

  [Theory]
  [MemberData(nameof(GetInBetweenData))]
  public void InBetween_Theory_Expected(bool throwException, TimeSpan value, TimeSpan min, TimeSpan max)
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
  public void NotBetween_Theory_Expected(bool throwException, TimeSpan value, TimeSpan min, TimeSpan max)
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
  public void GreaterThan_Theory_Expected(bool throwException, TimeSpan value, TimeSpan compareValue)
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
  public void GreaterThanOrEqual_Theory_Expected(bool throwException, TimeSpan value, TimeSpan compareValue)
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
  public void LessThan_Theory_Expected(bool throwException, TimeSpan value, TimeSpan compareValue)
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
  public void LessThanOrEqual_Theory_Expected(bool throwException, TimeSpan value, TimeSpan compareValue)
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

  public static TheoryData GetInBetweenData => new TheoryData<bool, TimeSpan, TimeSpan, TimeSpan>
    {
      { true, MinValue, BaseValue, MaxValue },
      { true, MaxValue, BaseValue, MinValue },
      { false, MinValue, MinValue, MaxValue },
      { false, MaxValue, MinValue, MaxValue },
      { false, BaseValue, MinValue, MaxValue },
      { false, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetNotBetweenData => new TheoryData<bool, TimeSpan, TimeSpan, TimeSpan>
    {
      { false, MinValue, BaseValue, MaxValue },
      { false, MaxValue, BaseValue, MinValue },
      { true, BaseValue, MinValue, MaxValue },
      { true, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetGreaterThanData => new TheoryData<bool, TimeSpan, TimeSpan>
    {
      { true, BaseValue, MaxValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetGreaterThanOrEqualData => new TheoryData<bool, TimeSpan, TimeSpan>
    {
      { true, BaseValue, MaxValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetLessThanData => new TheoryData<bool, TimeSpan, TimeSpan>
    {
      { true, BaseValue, MinValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetLessThanOrEqualData => new TheoryData<bool, TimeSpan, TimeSpan>
    {
      { true, BaseValue, MinValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };
}
