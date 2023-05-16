using DotNetExamplesAndNotes.ConsoleApp.ForUnitTests;

namespace DotNetExamplesAndNotes.TestProject;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(4, AdderService.AddWithTweak(2, 2));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(2)]
    [InlineData(4)]
    public void TestString1(int times)
    {
        "exexex".AssertContainsXTimes("ex", times);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(2)]
    [InlineData(4)]
    public void TestString2(int times)
    {
        "exexex".AssertContainsAtLeastXTimes("ex", times);
    }
}

public static class TestUtils
{
    public static void AssertContainsXTimes(this string actual, string expectedSubstring, int times)
    {
        var actualRemovedLength = actual.Length - actual.Replace(expectedSubstring, string.Empty).Length;
        var expectedRemovedLength = expectedSubstring.Length * times;

        Assert.Equal(expectedRemovedLength, actualRemovedLength);
    }

    public static void AssertContainsAtLeastXTimes(this string actual, string expectedSubstring, int times)
    {
        var actualRemovedLength = actual.Length - actual.Replace(expectedSubstring, string.Empty).Length;
        var expectedRemovedLength = expectedSubstring.Length * times;

        Assert.True(actualRemovedLength >= expectedRemovedLength);
    }
}
