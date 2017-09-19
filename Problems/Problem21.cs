using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Problems {
  public class Problem21 : BaseProblem {
    public Problem21() { this.ProblemNumber = 21; }
    public override void ComputeResult() {
      var a = GetAmicableNumbers(1, 10000);
      int sum = 0;
      foreach (KeyValuePair<int, int> pair in a) {
        sum += pair.Key;
      }
      this.Result = sum;
    }


    public Dictionary<int, int> GetAmicableNumbers(int floor, int cell) {
      var result = new Dictionary<int, int>();
      var tempDict = new Dictionary<int, int>();
      for (int i = floor; i <= cell; i++) {
        tempDict.Add(i, Helpers.GetDividersSum(i)-i);
      }
      foreach (KeyValuePair<int, int> pair in tempDict) {
        if (pair.Key == pair.Value) continue;
        if (!tempDict.ContainsKey(pair.Value)) continue;
        if (tempDict[pair.Value] != pair.Key) continue;
        result.Add(pair.Key, pair.Value);

      }
      return result;
    }
  }
}
