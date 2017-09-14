using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems {
  public class Problem4 : BaseProblem {
    public Problem4() {
      this.ProblemNumber = 4;
    }

    public override void ComputeResult() {
      List<int> palindromes = new List<int>();
      for (int i = 999; i > 100; i--) {
        for (int j = 999; j > 100; j--) {
          int p = i * j;
          if (IsPalindrome(p)) {
            palindromes.Add(p);
          }
        }
      }
      this.Result = palindromes.Max();
    }
    public bool IsPalindrome(long v) {
      string num = v.ToString();
      if (!IsEven(num.Length)) return false;
      string s1 = num.Substring(0, num.Length / 2);
      StringBuilder sb = new StringBuilder();
      for (int i = num.Length; i > num.Length / 2; i--) {
        sb.Append(num[i - 1]);
      }
      string s2 = sb.ToString();
      return string.Equals(s1, s2);
    }
  }
}
