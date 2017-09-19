using System;
using System.Collections.Generic;
using System.Text;

namespace Problems {
  public class Problem16 : BaseProblem {
    public Problem16() { this.ProblemNumber = 16; }
    public override void ComputeResult() {

      string pow = "2";
      for (int i = 1; i < 1000; i++) {
        pow = Helpers.LongMult(pow, "2");
      }
      //Console.WriteLine(pow+":"+pow.Length);
      int sum = 0;
      foreach (char c in pow) {
        sum += int.Parse(c.ToString());
      }
      this.Result = sum;
    }
  }
}
