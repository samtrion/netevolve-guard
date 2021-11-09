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
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsReadable(stream));
    }
    else
    {
      Requires.IsReadable(stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void IsSeekable_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsSeekable(stream));
    }
    else
    {
      Requires.IsSeekable(stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void IsWritable_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.IsWritable(stream));
    }
    else
    {
      Requires.IsWritable(stream);
    }
  }

  [Theory]
  [MemberData(nameof(GetStreamData))]
  public void NotEmpty_Theory_Expected(bool throwException, Stream stream)
  {
    if (throwException)
    {
      _ = Assert.Throws<ArgumentException>(nameof(stream), () => Requires.NotEmpty(stream));
    }
    else
    {
      Requires.NotEmpty(stream);
    }
  }

  public static TheoryData GetStreamData => new TheoryData<bool, Stream>
  {
#pragma warning disable CA2000 // Dispose objects before losing scope
    { true, new TestStream() },
    { false, new MemoryStream(new byte[] { 1, 2, 3 }) }
#pragma warning restore CA2000 // Dispose objects before losing scope
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
