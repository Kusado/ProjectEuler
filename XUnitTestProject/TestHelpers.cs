using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject {
  public class TestHelpers {
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(0, true)]
    [InlineData(-895, false)]
    public void ShouldBeEven(int num, bool res) {
      Assert.Equal(res, Helpers.IsEven(num));
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
    public void ShouldTellIfPrime(long number, bool result) {
      Assert.Equal(Helpers.IsPrime(number), result);
    }

    [Theory]
    [InlineData(18, 17)]
    [InlineData(16, 13)]
    [InlineData(7, 7)]
    [InlineData(2, 2)]
    [InlineData(5501, 5501)]
    [InlineData(6735, 6733)]
    public void ShouldReturnLastPrime(int Celling, int result) {
      var primes = Helpers.GetPrimes(Celling);
      Assert.Equal(result, primes.Last());
    }

    [Theory]
    [InlineData(18, 7)]
    [InlineData(16, 6)]
    [InlineData(7, 4)]
    [InlineData(2, 1)]
    public void ShouldReturnPrimesCount(int Celling, int result) {
      var primes = Helpers.GetPrimes(Celling);
      Assert.Equal(result, primes.Count);
    }
    [Theory]
    [InlineData(18, 7)]
    [InlineData(16, 6)]
    [InlineData(7, 4)]
    [InlineData(2, 1)]
    public void ShouldReturnPrimesCountFrom(int Celling, int result) {
      var primes = Helpers.GetPrimes(Celling);
      Assert.Equal(result, primes.Count);
    }

    [Theory]
    [MemberData("GetPrimeDividerData")]
    public void ShouldReturnPrimeDividers(List<int> divs, int number) {
      var res = new List<int>() { 2, 5 };
      var dividers = Helpers.GetPrimeDividers(number);
      Assert.True(dividers.SequenceEqual(divs));
    }
    public static IEnumerable<object[]> GetPrimeDividerData() {
      return new List<object[]>() {
        new object[]{ new List<int>() { 2, 2, 2 }, 8 },
        new object[]{ new List<int>() { 2, 5,}, 10 },
        new object[]{ new List<int>() { 3,3 }, 9 },
        new object[]{ new List<int>() { 7 }, 7 },
        new object[]{ new List<int>() { 2}, 2 },
      };
    }


  }
}