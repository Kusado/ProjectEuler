using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problems {
  class Problem9 : BaseProblem {
    public Problem9() {
      this.ProblemNumber = 9;
    }
    public override void ComputeResult() {
      int mn = 450;
      for (int a = 1; a <= mn; a++) {
        for (int b = 1; b <= mn; b++) {
          for (int c = 1; c <= mn; c++) {
            if (a + b + c != 1000) continue;
            if (a * a + b * b != c * c) continue;
            this.Result = a * b * c;
            return;
          }
        }
      }
    }
  }
}
