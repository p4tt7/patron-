using Xunit;

namespace Tests;

public class MyTests
{
  [Fact]
  public void TestAllTurnedOn()
  {
    bool[,] matrix = new bool[3, 3]
    {
          { true, true, true },
          { true, true, true },
          { true, true, true }
    };

    bool result = Solution.AllTurnedOn(matrix);
    Assert.True(result);
  }
}