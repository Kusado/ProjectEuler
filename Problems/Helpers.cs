using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problems {
  public static class Helpers {
    public static bool IsEven(long v) {
      return (v & 1) == 0;
    }

    public static bool IsPrime(long v) {
      for (long j = 2; j <= Math.Sqrt(v); j++)
        if (v % j == 0) {
          return false;
        }
      return true;
    }

    public static List<int> GetPrimes_old(int Celling = 100, int floor = 2) {
      if (floor < 2 || floor > Celling) { throw new ArgumentException(); }
      var result = new List<int>() { 2 };
      for (int i = 3; i <= Celling; i++) {
        if (IsEven(i)) continue;
        result.Add(i);
      }
      int index = 0;
      while (result[index] != result.Last()) {
        int j = result[index];
        result.RemoveAll(x => (x % j) == 0 & x != j);
        index++;
      }
      return result.Where(x => x >= floor).ToList();
    }
    public static List<int> GetPrimes(int Celling = 100, int floor = 2) {
      if (floor < 2 || floor > Celling) { throw new ArgumentException(); }
      //var result = Enumerable.Range(2, Celling).ToList();
      bool[] sieve = Enumerable.Repeat(false, Celling+1).ToArray();
      int crossLimit = (int)Math.Ceiling(Math.Sqrt(Celling));
      //������ ��� ������ �����
      for (int i = 4; i <= Celling; i += 2) {
        sieve[i] = true;
      }
      for (int n = 3; n <= crossLimit; n += 2) {
        if (!sieve[n]) {
          for (int m = n * n; m <= Celling; m += 2 * n) {
            sieve[m] = true;
          }
        }
      }
      var result = new List<int>();
      for (int i = 2; i <=Celling; i++) {
        if (!sieve[i]) result.Add(i);
      }

      return result.Where(x => x >= floor).ToList();
    }

    public static List<int> GetPrimeDividers(int v) {
      if (v == 1) return new List<int>() { 1 };
      var result = new List<int>();
      var primes = GetPrimes(v);
      int rd = v;
      while (rd != 1) {
        int a = primes.First(prime => rd % prime == 0);
        result.Add(a);
        rd = rd / a;
      }
      return result;
    }

    public static List<int> GetCommonPrimeDividers(int firstNumber, int secondNumber) {
      return GetCommonPrimeDividers(GetPrimeDividers(firstNumber), GetPrimeDividers(secondNumber));
    }

    public static List<int> GetCommonPrimeDividers(List<int> listA, int secondNumber) {
      return GetCommonPrimeDividers(listA, GetPrimeDividers(secondNumber));
    }

    public static List<int> GetCommonPrimeDividers(List<int> listA, List<int> listB) {
      List<int> result = new List<int>();
      result.AddRange(listA);

      foreach (IGrouping<int, int> groupB in listB.GroupBy(x => x)) {
        int num = groupB.First();
        int countB = groupB.Count();
        //var groupA = listA.GroupBy(x => x).Where(y => y.Key == num);
        var groupA = listA.Where(y => y == num);

        if (!groupA.Any()) {
          result.AddRange(groupB.ToArray());
          continue;
        }
        int countA = groupA.Count();
        if (countA >= countB) continue;
        result.AddRange(Enumerable.Repeat(num, countB - countA).Select(x => x));
      }
      result.Sort();
      return result;
    }

    public static bool IsEvenlyDivisible(long number, long divider) {
      return (number % divider) == 0;
    }

    public static bool IsEvenlyDivisibleByArray(long number, long divider) {
      for (long i = 1; i <= divider; i++) {
        if (!IsEvenlyDivisible(number, i)) {
          return false;
        }
      }
      return true;
    }

    public static ulong SumOfList<T>(List<T> li) {
      ulong result = 0;
      li.ForEach(x => result += ulong.Parse(x.ToString()));
      return result;
    }

  }
}