using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems {
   public class Problem14 : BaseProblem {
      public Problem14() {
         this.ProblemNumber = 14;
      }

      public override void ComputeResult() {
         long i = 1;
         long longest = 0;
         long longCol = 1;
         while (i < 1000000) {
            i++;
            long tmp = CollatzLength(i);
            if (tmp > longest) {
               longest = tmp;
               longCol = i;
            }
         }
         this.Result = longCol;
      }

      public long GetNextCollatz(long num) {
         if (num == 0) throw new ArgumentException();
         return Helpers.IsEven(num) ? num / 2 : (num * 3) + 1;
      }

      public long CollatzLength(long collatzNum) {

         int i = 1;
         while (collatzNum != 1) {
            i++;
            collatzNum = GetNextCollatz(collatzNum);
         }
         return i;
      }
   }
}
