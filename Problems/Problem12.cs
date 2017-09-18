using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problems {
  public class Problem12 : BaseProblem {
    public Problem12() { this.ProblemNumber = 12; }
    public override void ComputeResult() {
      this.Result = ComputeResult(500);
    }
    public int ComputeResult(int nDivCount) {
      int tNumber = 1;
      Console.WriteLine("ComputimgPrimes");
      var primes = Helpers.GetPrimes(12500);
      Console.WriteLine("Got lot's of primes.");
      for (int i = 2; tNumber < int.MaxValue; i++) {
        tNumber += i;
        int divCount = Helpers.GetDividersCount(tNumber, primes);
        if (divCount <= nDivCount) continue;
        Console.WriteLine($"Loop# {i}. TNumber {tNumber}. Dividers {divCount}");
        return tNumber;
      }
      throw new ArgumentException("Неверные входные данные", nameof(nDivCount));
    }
  }
}
