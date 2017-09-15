using System;
using System.Collections.Generic;
using System.Text;

namespace Problems {
  class Problem7:BaseProblem {
    public override void ComputeResult() {
      List<int> primesList = new List<int>();
      int i = 2;
      int step = 5000;
      while (primesList.Count<=10001) {
        primesList.AddRange(Helpers.GetPrimes(i+step,i));
        i += step;
      }
      this.Result = primesList[10000];
    }
  }
}
