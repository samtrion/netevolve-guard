#if NET5_0_OR_GREATER
namespace NetEvolve.Guard.Tests
{
  using NetEvolve.Guard;
  using System;
  using System.Diagnostics.CodeAnalysis;
  using Xunit;
  using CompareValue = System.Half;

  [ExcludeFromCodeCoverage]
  public sealed class RequiresHalfTests
  {
    private static CompareValue BaseValue { get; } = default;
    private static CompareValue MaxValue { get; } = CompareValue.MaxValue;
    private static CompareValue MinValue { get; } = CompareValue.MinValue;
    private static CompareValue NaN { get; } = CompareValue.NaN;
    private static CompareValue NegativeInfinity { get; } = CompareValue.NegativeInfinity;
    private static CompareValue PositiveInfinity { get; } = CompareValue.PositiveInfinity;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, CompareValue value, CompareValue min, CompareValue max)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.InBetween(nameof(value), value, min, max));
      }
      else
      {
        Requires.InBetween(nameof(value), value, min, max);
      }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanData))]
    public void GreaterThan_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThan(nameof(value), value, compareValue));
      }
      else
      {
        Requires.GreaterThan(nameof(value), value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanOrEqualData))]
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.GreaterThanOrEqual(nameof(value), value, compareValue));
      }
      else
      {
        Requires.GreaterThanOrEqual(nameof(value), value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetLessThanData))]
    public void LessThan_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThan(nameof(value), value, compareValue));
      }
      else
      {
        Requires.LessThan(nameof(value), value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetLessThanOrEqualData))]
    public void LessThanOrEqual_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () => Requires.LessThanOrEqual(nameof(value), value, compareValue));
      }
      else
      {
        Requires.LessThanOrEqual(nameof(value), value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetNotNaNData))]
    public void NotNaN_Theory_Expected(bool throwException, CompareValue value)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNaN(nameof(value), value));
      }
      else
      {
        Requires.NotNaN(nameof(value), value);
      }
    }

    [Theory]
    [MemberData(nameof(GetNotInfinityData))]
    public void NotInfinity_Theory_Expected(bool throwException, CompareValue value)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotInfinity(nameof(value), value));
      }
      else
      {
        Requires.NotInfinity(nameof(value), value);
      }
    }

    [Theory]
    [MemberData(nameof(GetNotNegativeInfinityData))]
    public void NotNegativeInfinity_Theory_Expected(bool throwException, CompareValue value)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotNegativeInfinity(nameof(value), value));
      }
      else
      {
        Requires.NotNegativeInfinity(nameof(value), value);
      }
    }

    [Theory]
    [MemberData(nameof(GetNotPositiveInfinityData))]
    public void NotPositiveInfinity_Theory_Expected(bool throwException, CompareValue value)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotPositiveInfinity(nameof(value), value));
      }
      else
      {
        Requires.NotPositiveInfinity(nameof(value), value);
      }
    }

    public static TheoryData GetInBetweenData => new TheoryData<bool, CompareValue, CompareValue, CompareValue>
    {
      { true, MinValue, BaseValue, MaxValue },
      { true, MaxValue, BaseValue, MinValue },
      { false, BaseValue, MinValue, MaxValue },
      { false, BaseValue, MaxValue, MinValue }
    };

    public static TheoryData GetGreaterThanData => new TheoryData<bool, CompareValue, CompareValue>
    {
      { true, BaseValue, MaxValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

    public static TheoryData GetGreaterThanOrEqualData => new TheoryData<bool, CompareValue, CompareValue>
    {
      { true, BaseValue, MaxValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MinValue }
    };

    public static TheoryData GetLessThanData => new TheoryData<bool, CompareValue, CompareValue>
    {
      { true, BaseValue, MinValue },
      { true, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

    public static TheoryData GetLessThanOrEqualData => new TheoryData<bool, CompareValue, CompareValue>
    {
      { true, BaseValue, MinValue },
      { false, BaseValue, BaseValue },
      { false, BaseValue, MaxValue }
    };

    public static TheoryData GetNotNaNData => new TheoryData<bool, CompareValue>
    {
      { true, NaN },
      { false, BaseValue },
      { false, MaxValue },
      { false, MinValue }
    };

    public static TheoryData GetNotInfinityData => new TheoryData<bool, CompareValue>
    {
      { true, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

    public static TheoryData GetNotNegativeInfinityData => new TheoryData<bool, CompareValue>
    {
      { false, PositiveInfinity },
      { true, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };

    public static TheoryData GetNotPositiveInfinityData => new TheoryData<bool, CompareValue>
    {
      { true, PositiveInfinity },
      { false, NegativeInfinity },
      { false, MaxValue },
      { false, MinValue }
    };
  }
}
#endif
