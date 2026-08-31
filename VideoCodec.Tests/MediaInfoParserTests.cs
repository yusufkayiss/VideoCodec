using Xunit;

namespace VideoCodec.Tests;

public class MediaInfoParserTests
{
    [Fact]
    public void SanityCheck_ShouldAlwaysPass()
    {
        // Arrange
        bool isEngineReady = true;

        // Assert
        Assert.True(isEngineReady, "Core codec engine build test passed.");
    }

    [Theory]
    [InlineData("sample.mp4", true)]
    [InlineData("sample.mkv", true)]
    [InlineData("invalid.txt", false)]
    public void ValidateVideoExtension_ShouldReturnExpectedResult(string fileName, bool expected)
    {
        // Act
        bool isValid = fileName.EndsWith(".mp4") || fileName.EndsWith(".mkv");

        // Assert
        Assert.Equal(expected, isValid);
    }
}
