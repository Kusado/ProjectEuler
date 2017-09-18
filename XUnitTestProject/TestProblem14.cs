using System;
using System.Collections.Generic;
using System.Text;
using Problems;
using Xunit;

namespace XUnitTestProject
{
   public class TestProblem14 {
      [Fact]
      public void Sholud_Multiply_Arrays() {
         var res = Helpers.MultIntArr(new int[] {1, 0}, new int[] { 1, 1 }, 1);
         
      }
   }
}