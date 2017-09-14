using System;
using System.Collections.Generic;
using System.Text;

namespace Problems {
  public abstract class BaseProblem : IProblem {
    public long Result { get; set; }
    public int ProblemNumber { get; protected set; }
    public abstract void ComputeResult();
    public long GetResult() {
      ComputeResult();
      Console.WriteLine("Answer on problem " + ProblemNumber + " is " + this.Result);
      return this.Result;
    }
    public bool IsEven(long v) {
      return (v & 1) == 0;
    }
  }
}
