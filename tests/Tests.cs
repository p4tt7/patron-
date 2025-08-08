using Xunit;
using library;

namespace Tests
{

  public class MyTests
  {
    [Fact]
    public void TestAllTurnedOnWorksOnFullArray()
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

    [Fact]
    public void TestAllTurnedOnWorksOnNotOnArray()
    {
      bool[,] matrix = new bool[3, 3]
      {
          { true, true, true },
          { true, false, true },
          { true, true, true }
      };

      bool result = Solution.AllTurnedOn(matrix);
      Assert.False(result);
    }
  }
}