using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem8 {
    [Theory]
    [InlineData(13,23514624000)]
    [InlineData(4,5832)]
    public void ShouldReturn(int num, long res) {
      var sut = new Problems.Problem8();
      sut.ComputeResult(num);
      Assert.Equal(res, sut.Result);
    }

  }
}
