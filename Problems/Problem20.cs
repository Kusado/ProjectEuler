using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Problems {
  public class Problem20 : BaseProblem {
    public Problem20() { this.ProblemNumber = 20; }
    public override void ComputeResult() {
      string fact = "1";
      for (int i = 2; i <= 100; i++) {
        fact = Helpers.LongMult(fact, i.ToString());
      }

      //Console.WriteLine(fact+":"+fact.Length);
      int sum = 0;
      foreach (char c in fact) {
        sum += int.Parse(c.ToString());
      }
      this.Result = sum;
    }

  }
}
