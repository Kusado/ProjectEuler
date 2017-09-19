using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class Problem17:BaseProblem
    {
    public Problem17() { this.ProblemNumber = 17; }
      public override void ComputeResult() {
      int sum = 0;
        for (int i = 0; i <= 1000; i++) {
        sum += i;
        }
      this.Result = sum;
      }
    }
}
