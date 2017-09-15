﻿using System;
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
      Console.WriteLine("Time elapsed: "+watch.ElapsedMilliseconds/1000.0);
      return this.Result;
    }
  }
}