using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems {
  class Problem10 : BaseProblem {
    public Problem10() { this.ProblemNumber = 10; }
    public override void ComputeResult() {
      List<int> primes = new List<int>();
      primes = Helpers.GetPrimes(2000000);
      Console.WriteLine($"Primes count: {primes.Count}. Max Prime: {primes.Last()}.");
      this.Result = (long)Helpers.SumOfList(primes);
    }
  }
}
