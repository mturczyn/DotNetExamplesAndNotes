using DotNetExamplesAndNotes.ConsoleApp.ForUnitTests;

namespace DotNetExamplesAndNotes.TestProject;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(4, AdderService.AddWithTweak(2, 2));
    }
}
