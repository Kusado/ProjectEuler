using System;
using System.Collections.Generic;
using System.Text;

namespace Problems {
  public class Problem5 : BaseProblem {
    public Problem5() { this.ProblemNumber = 5; }
    public void ComputeResult(int num) {
      List<int> allDivs = Helpers.GetPrimeDividers(num);
      for (int i = num - 1; i > 1; i--) {
        allDivs = Helpers.GetCommonPrimeDividers(allDivs, Helpers.GetPrimeDividers(i));
      }
      int a = 1;
      allDivs.ForEach(x => a = a * x);
      this.Result = a;
    }
    public override void ComputeResult() {
      ComputeResult(20);
    }

    public bool IsEvenlyDivisible(long number, long divider) {
      return (number % divider) == 0;
    }

    public bool IsEvenlyDivisibleByArray(long number, long divider) {
      for (long i = 1; i <= divider; i++) {
        if (!IsEvenlyDivisible(number, i)) {
          return false;
        }
      }
      return true;
    }
  }
}
