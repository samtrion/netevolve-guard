namespace NetEvolve.Guard.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

[ExcludeFromCodeCoverage]
public class RequiresStreamTests
{

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void IsReadable_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsReadable(nameof(stream), stream));
    }
    else
    {
      Requires.IsReadable(nameof(stream), stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void IsSeekable_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsSeekable(nameof(stream), stream));
    }
    else
    {
      Requires.IsSeekable(nameof(stream), stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void IsWritable_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsWritable(nameof(stream), stream));
    }
    else
    {
      Requires.IsWritable(nameof(stream), stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void NotEmpty_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.NotEmpty(nameof(stream), stream));
    }
    else
    {
      Requires.NotEmpty(nameof(stream), stream);
    }
  }

  public static TheoryData GetStreamData => new TheoryData<bool, Stream>
  {
    { true, new TestStream() },
    { false, new MemoryStream(new byte[] { 1, 2, 3 }) }
  };

  private sealed class TestStream : Stream
  {
    public override bool CanRead => false;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => 0;

    public override long Position { get; set; }

    public override void Flush() { }
    public override int Read(byte[] buffer, int offset, int count) => -1;
    public override long Seek(long offset, SeekOrigin origin) => -1;
    public override void SetLength(long value) { }
    public override void Write(byte[] buffer, int offset, int count) { }
  }
}
