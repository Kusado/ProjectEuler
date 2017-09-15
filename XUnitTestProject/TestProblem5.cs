using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem5 {
    [Theory]
    [InlineData(10, 2520)]
    [InlineData(20, 232792560)]
    public void ShouldReturn2520(int num, long answer) {
      var sut = new Problem5();
      sut.ComputeResult(num);
      Assert.Equal(answer, sut.Result);
    }

    [Fact]
    public void Should_Return_Common_Prime_Dividers() {
      List<int> result = Helpers.GetCommonPrimeDividers(90, 8);
      Assert.True(result.SequenceEqual(new List<int>() { 2, 2, 2, 3, 3, 5 }));
    }

  }
}
