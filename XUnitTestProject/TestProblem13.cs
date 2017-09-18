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
    [InlineData("0", "1000", "1000")]

    public void ShouldReturnSum(string x, string y, string res) {
      var result = Helpers.LongSum(x, y);
      Assert.Equal(res, result);
    }

     [Theory]
     [InlineData(10, 3, "010")]
     [InlineData(1, 3, "001")]
     [InlineData(100, 3, "100")]
     [InlineData(1000, 3, "000")]
     public void Should_Return_Formatted_String(int value, int charCount, string result) {
        string res = Helpers.IntToString(value, charCount);
         Assert.Equal(result,res);
     }
  }
}
