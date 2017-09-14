using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems {
  public class Problem3 : BaseProblem {
    public Problem3() {
      this.ProblemNumber = 3;
    }
    public override void ComputeResult() {
      var watch = new Stopwatch();
      watch.Start();
      ComputeResult(600851475143);
      watch.Stop();
      Console.WriteLine("Elapsed: " + watch.ElapsedMilliseconds);
    }
    public long ComputeResult(long num) {
      for (long i = (long)Math.Sqrt(num) + 1; i > 0; i--) {
        if (IsNumberPrime(i)) {
          if (num % i == 0) {
            this.Result = (long)i;
            return this.Result;
          }
        }
      }
      return 1;
    }
    public static bool IsNumberPrime(long i) {
      for (long j = 2; j <= Math.Sqrt(i); j++)
        if (i % j == 0) {
          return false;
        }
      return true;
    }
    public static bool IsNumberPrimeParallel(long num) {
      bool test = true;
      Parallel.For((long)2, (long)Math.Sqrt(num) + 1, (j, state) => {
        if (num % j == 0) {
          test = false;
          state.Stop();
        }
      });
      return test;
    }
  }
}
