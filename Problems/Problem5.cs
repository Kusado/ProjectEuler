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


  }
}
