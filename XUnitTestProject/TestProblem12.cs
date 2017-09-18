using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem12 {
    [Theory]
    [MemberData("GetTriangleDividers")]
    public void SouldReturnDividers(int triangleIndex, List<int> Dividers) {
      var result = Helpers.GetDividers(Helpers.GetTriangleNumber(triangleIndex));
      Assert.True(result.SequenceEqual(Dividers));
    }
    public static IEnumerable<object[]> GetTriangleDividers() {
      return new List<object[]>() {
        new object[]{1,new List<int>(){1}},
        new object[]{2,new List<int>(){1,3}},
        new object[]{3,new List<int>(){1,2,3,6}},
        new object[]{4,new List<int>(){1,2,5,10}},
      };
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 3)]
    [InlineData(3, 6)]
    [InlineData(4, 10)]
    public void SouldReturnTrianlgeNumber(int ind, long result) {
      var tNumber = Helpers.GetTriangleNumber(ind);
      Assert.Equal(result, tNumber);
    }

    [Fact]
    public void Should_Find_Triangle_number_with_5_dividers() {
      var sut = new Problem12();
      var result = sut.ComputeResult(5);
      Assert.Equal(28, result);
    }
  }
}
