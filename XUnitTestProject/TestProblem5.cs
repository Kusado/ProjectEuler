using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject {
  public class TestProblem5 {
    [Fact]
    public void ShouldReturn2520() {
      var sut = new Problems.Problem5();
      sut.ComputeResult(10);
      Assert.Equal(2520, sut.Result);
    }
    [Theory]
    [InlineData(2520, 10, true)]
    [InlineData(2520, 9, true)]
    [InlineData(2520, 8, true)]
    [InlineData(2520, 7, true)]
    [InlineData(2520, 6, true)]
    [InlineData(2520, 11, false)]
    public void ShoildBeEvenlyDivisible(long number, long divider, bool result) {
      var sut = new Problems.Problem5();
      var res = sut.IsEvenlyDivisible(number, divider);
      Assert.Equal(result, res);
    }
    [Theory]
    [InlineData(2520, 10, true)]
    [InlineData(2520, 9, true)]
    [InlineData(2520, 8, true)]
    [InlineData(2520, 7, true)]
    [InlineData(2520, 13, false)]
    [InlineData(2520, 11, false)]
    public void ShoildBeEvenlyDivisibleByArray(long number, long divider, bool result) {
      var sut = new Problems.Problem5();
      var res = sut.IsEvenlyDivisibleByArray(number, divider);
      Assert.Equal(result, res);
    }

    [Fact]
    //[MemberData("GetCommonDividers")]
    public void Should_Return_Common_Prime_Dividers() {//List<int> commonDividers, int firstNumber, int secondNumber) {
      List<int> result = Helpers.GetCommonPrimeDividers(90, 8);
      Assert.True(result.SequenceEqual(new List<int>() { 2, 2, 2, 3, 3, 5 }));
    }

    public IEnumerable<object[]> GetCommonDividers() {
      return new List<object[]>() {
        new object[]{new List<int>(){ 2,2,2, 3, 3, 5 }, 90, 8 }
      };
    }
  }
}
