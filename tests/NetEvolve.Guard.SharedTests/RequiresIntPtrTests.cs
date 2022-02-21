#if NET6_0_OR_GREATER && USE_GENERIC_MATH_FEATURE
namespace NetEvolve.Guard.Tests;

using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public sealed class RequiresIntPtrTests
{
  private static nint BaseValue { get; }
  private static nint MaxValue { get; } = nint.MaxValue;
  private static nint MinValue { get; } = nint.MinValue;

  [Theory]
  [MemberData(nameof(GetInBetweenData))]
  public void InBetween_Theory_Expected(bool throwException, nint value, nint min, nint max)
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
  public void NotBetween_Theory_Expected(bool throwException, nint value, nint min, nint max)
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
  public void GreaterThan_Theory_Expected(bool throwException, nint value, nint nint)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThan(value, nint));
    }
    else
    {
      Requires.GreaterThan(value, nint);
    }
  }

  [Theory]
  [MemberData(nameof(GetGreaterThanOrEqualData))]
  public void GreaterThanOrEqual_Theory_Expected(bool throwException, nint value, nint nint)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThanOrEqual(value, nint));
    }
    else
    {
      Requires.GreaterThanOrEqual(value, nint);
    }
  }

  [Theory]
  [MemberData(nameof(GetLessThanData))]
  public void LessThan_Theory_Expected(bool throwException, nint value, nint nint)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThan(value, nint));
    }
    else
    {
      Requires.LessThan(value, nint);
    }
  }

  [Theory]
  [MemberData(nameof(GetLessThanOrEqualData))]
  public void LessThanOrEqual_Theory_Expected(bool throwException, nint value, nint nint)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThanOrEqual(value, nint));
    }
    else
    {
      Requires.LessThanOrEqual(value, nint);
    }
  }

  public static TheoryData GetInBetweenData => new TheoryData<bool, nint, nint, nint>
    {
      { true, MinValue, BaseValue, MaxValue },
      { true, MaxValue, BaseValue, MinValue },
      { false, MinValue, MinValue, MaxValue },
      { false, MaxValue, MinValue, MaxValue },
      { false, BaseValue, MinValue, MaxValue },
      { false, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetNotBetweenData => new TheoryData<bool, nint, nint, nint>
    {
      { false, MinValue, BaseValue, MaxValue },
      { false, MaxValue, BaseValue, MinValue },
      { true, BaseValue, MinValue, MaxValue },
      { true, BaseValue, MaxValue, MinValue }
    };

  public static TheoryData GetGreaterThanData => new TheoryData<bool, nint, nint>
    {
      { true, BaseValue, MaxValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetGreaterThanOrEqualData => new TheoryData<bool, nint, nint>
    {
      { true, BaseValue, MaxValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

  public static TheoryData GetLessThanData => new TheoryData<bool, nint, nint>
    {
      { true, BaseValue, MinValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

  public static TheoryData GetLessThanOrEqualData => new TheoryData<bool, nint, nint>
    {
      { true, BaseValue, MinValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };
}

#endif
