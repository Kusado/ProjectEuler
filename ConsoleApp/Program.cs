using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp {
  internal class Program {
    private static void Main(string[] args) {
      ComputeResult();
      Console.WriteLine("...");
      Console.ReadKey();
    }

    public static void ComputeResult() {
      Stopwatch watch = new Stopwatch();
      const int Celling = 25000000;
      int rep = 99;
      var modTimes = new List<long>();
      var shiftTimes = new List<long>();
      int evenCount;
      for (int n = 0; n < rep; n++) {
        evenCount = 0;
        watch.Reset();
        watch.Start();
        for (int i = 0; i < Celling; i++) if (isEvenModulus(i)) evenCount++;
        watch.Stop();
        modTimes.Add(watch.ElapsedMilliseconds);
      }
      Console.WriteLine("Modulus avg time:" + modTimes.Average());

      for (int j = 0; j < rep; j++) {
        evenCount = 0;
        watch.Reset();
        watch.Start();
        for (int i = 0; i < Celling; i++) if (isEvenShift(i)) evenCount++;
        watch.Stop();
        shiftTimes.Add(watch.ElapsedMilliseconds);
      }
      Console.WriteLine("Shift avg time:" + shiftTimes.Average());

    }

    public static bool isEvenModulus(int n) { return n % 2 == 0; }

    public static bool isEvenShift(int n) { return (n & 1) == 0; }
  }
}