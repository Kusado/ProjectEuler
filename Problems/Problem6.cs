using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems {
  class Problem6 : BaseProblem {
    public Problem6() { this.ProblemNumber = 6; }
    public override void ComputeResult() {
      int input = 100;
      int[] numbers = Enumerable.Range(1, input).ToArray();

      long SummOfSq = 0;
      foreach (int number in numbers) {
        SummOfSq += (long)Math.Pow(number,2);
      }
      long sqOfSumm = (long)Math.Pow(numbers.Sum(),2);
      this.Result = sqOfSumm - SummOfSq;
    }
  }
}
