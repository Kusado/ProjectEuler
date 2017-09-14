using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem4 {
    [Fact]
    public void ShouldNumberBe4() {
      var sut = new Problems.Problem4();
      Assert.Equal(4, sut.ProblemNumber);
    }
    [Theory]
    [InlineData(9009, true)]
    [InlineData(1111, true)]
    [InlineData(90091, false)]
    [InlineData(9090, false)]

    public void ShouldBePalindrome(int v,bool res) {
      var sut = new Problems.Problem4();
      Assert.Equal(res,sut.IsPalindrome(v));
    }


  }
}
