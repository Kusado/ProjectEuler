using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem {
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    public void ShouldBeEven(int num, bool res) {
      var sut = new Problems.Problem3();
      Assert.Equal(res, sut.IsEven(num));
    }
  }
}