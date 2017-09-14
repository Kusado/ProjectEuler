using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace XUnitTestProject {
  public class TestProblem3 {
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(7, true)]
    [InlineData(3943, true)]
    [InlineData(3744, false)]
    [InlineData(144577, true)]
    [InlineData(1445780, false)]
    [InlineData(13195,false)]
    public void ShouldTellIfPrime(long number, bool result) {
      var sut = new Problems.Problem3();
      Assert.Equal(Problems.Problem3.IsNumberPrime(number), result);
    }
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(7, true)]
    [InlineData(3943, true)]
    [InlineData(3744, false)]
    [InlineData(144577, true)]
    [InlineData(1445780, false)]
    [InlineData(13195, false)]
    public void ShouldTellIfParallelPrime(long number, bool result) {
      var sut = new Problems.Problem3();
      Assert.Equal(Problems.Problem3.IsNumberPrimeParallel(number), result);
    }

    [Fact]
    public void ShouldReturnMaxPrimeDev() {
      var sut = new Problems.Problem3();
      var result = sut.ComputeResult(13195);
      Assert.Equal(29,result);
    }
  }
}
