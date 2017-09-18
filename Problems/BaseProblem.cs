using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problems {
  public abstract class BaseProblem : IProblem {
    public long Result { get; set; }
    public int ProblemNumber { get; protected set; }
    public abstract void ComputeResult();
    public long GetResult() {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      ComputeResult();
      watch.Stop();
      Console.WriteLine("Answer on problem " + ProblemNumber + " is " + this.Result);
      if (watch.ElapsedMilliseconds > 5000) {
        Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds / 1000.0 + "s");
      }
      else {
        Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
      }
      return this.Result;
    }
  }
}
