using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problems {
  public class Problem23 : BaseProblem {
    public Problem23() { this.ProblemNumber = 23; }
    public override void ComputeResult() {
      this.Result = 0;
      int limit = 28124;
      bool[] isAbnum = GetAbundantNumbersBool(limit);
      bool[] sumOfAbnum = Enumerable.Repeat(false, limit).ToArray();
      for (int i = 1; i < limit; i++) {
        for (int j = 0; j <= i / 2; j++) {
          if (!isAbnum[j] || !isAbnum[i - j]) continue;
          sumOfAbnum[i] = true;
        }
      }

      for (int i = 0; i < sumOfAbnum.Length; i++) {
        if (!sumOfAbnum[i]) {
          this.Result += i;
        }
      }
    }

    public bool[] GetAbundantNumbersBool(int cell) {
      var result = Enumerable.Repeat(true, cell).ToArray();
      for (int i = 0; i < cell; i++) {
        result[i] = IsAbudant(i);
      }
      return result;
    }

    public bool IsAbudant(int num) {
      if (num == 0 || num == 1 || num == 2) return false;
      int divSumm = Helpers.GetDividersSum(num);
      return divSumm > num+num;
    }
  }
}
