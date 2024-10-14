namespace LearnTUnit.Tests;

public class ExampleTests
{
    [Before(Test)]
    public void BeforeHook(TestContext context)
    {
        Console.WriteLine($"Test {context.TestDetails.DisplayName} starting");
    }

    [After(Test)]
    public void AfterHook(TestContext context)
    {
        Console.WriteLine($"Test {context.TestDetails.DisplayName} ended");
    }

    [Test]
    [Retry(5)]
    public async Task FirstBasicTest()
    {
        var result = Add(2, 5);

        await Assert.That(result).IsEqualTo(7);

        Console.WriteLine($"Test retry attempt: {TestContext.Current?.CurrentRetryAttempt}");
    }

    [Test]
    [Arguments(1, 1, 2)]
    [Arguments(1, 2, 3)]
    [Arguments(2, 2, 4)]
    public async Task MyTest(int value1, int value2, int expectedResult)
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsEqualTo(expectedResult);
    }

    private static int Add(int x, int y)
    {
        return x + y;
    }
}