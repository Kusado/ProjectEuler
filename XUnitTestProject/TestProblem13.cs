using System;
using System.Collections.Generic;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem13 {
    [Fact]
    public void ShouldReturnIntArray() {
      var result = Helpers.GetIntsFromString("12312341234", 3);
      Assert.Equal(4, result.Length);
    }
    [Theory]
    [InlineData("123123", "1", "123124")]
    [InlineData("123123", "2", "123125")]
    [InlineData("3", "123123", "123126")]
    public void ShouldReturnSum(string x, string y, string res) {
      var result = Helpers.LongSum(x, y);
      Assert.Equal(res, result);
    }
  }
}
