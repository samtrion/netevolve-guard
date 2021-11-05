namespace NetEvolve.Guard.Tests
{
  using NetEvolve.Guard;
  using System;
  using System.Diagnostics.CodeAnalysis;
  using Xunit;
  using CompareValue = System.Byte;

  [ExcludeFromCodeCoverage]
  public sealed class RequiresUInt8Tests
  {
    private static CompareValue BaseValue { get; } = 1;
    private static CompareValue MaxValue { get; } = CompareValue.MaxValue;
    private static CompareValue MinValue { get; } = CompareValue.MinValue;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, CompareValue value, CompareValue min, CompareValue max)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => Requires.InBetween(value, min, max));
      }
      else
      {
        Requires.InBetween(value, min, max);
      }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanData))]
    public void GreaterThan_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => Requires.GreaterThan(value, compareValue));
      }
      else
      {
        Requires.GreaterThan(value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanOrEqualData))]
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => Requires.GreaterThanOrEqual(value, compareValue));
      }
      else
      {
        Requires.GreaterThanOrEqual(value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetLessThanData))]
    public void LessThan_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => Requires.LessThan(value, compareValue));
      }
      else
      {
        Requires.LessThan(value, compareValue);
      }
    }

    [Theory]
    [MemberData(nameof(GetLessThanOrEqualData))]
    public void LessThanOrEqual_Theory_Expected(bool throwException, CompareValue value, CompareValue compareValue)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => Requires.LessThanOrEqual(value, compareValue));
      }
      else
      {
        Requires.LessThanOrEqual(value, compareValue);
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

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(GetNotPow2Data))]
    public void NotPow2_Theory_Expected(bool throwException, CompareValue value)
    {
      if (throwException)
      {
        _ = Assert.Throws<ArgumentException>(nameof(value), () => Requires.NotPow2(value));
      }
      else
      {
        Requires.NotPow2(value);
      }
    }

    public static TheoryData GetNotPow2Data => new TheoryData<bool, CompareValue>
    {
      { true, 63 },
      { false, 64 }
    };
#endif
  }
}
