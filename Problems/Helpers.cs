using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
      bool[] sieve = Enumerable.Repeat(false, Celling + 1).ToArray();
      int crossLimit = (int)Math.Ceiling(Math.Sqrt(Celling));
      //отсеем все чётные числа
      for (int i = 4; i <= Celling; i += 2) {
        sieve[i] = true;
      }
      //Установим признак отсева для числа
      for (int n = 3; n <= crossLimit; n += 2) {
        if (!sieve[n]) {
          for (int m = n * n; m <= Celling; m += 2 * n) {
            sieve[m] = true;
          }
        }
      }
      var result = new List<int>();
      for (int i = 2; i <= Celling; i++) {
        if (!sieve[i]) result.Add(i);
      }

      return result.Where(x => x >= floor).ToList();
    }

    public static int GetTriangleNumber(int ind) {
      int result = 0;
      for (int i = 1; i <= ind; i++) {
        result += i;
      }
      return result;
    }

    public static int GetDividersCount(int val, List<int> primes) {
      int dividersCount = 1;
      GetPrimeDividers(val, primes).GroupBy(x => x).ToList().ForEach(x => dividersCount *= x.Count() + 1);
      return dividersCount;
    }
    public static int GetDividersCountNaive(int val) {
      if (val == 1) return 1;
      int result = 1;
      var limit = (val / 2) + 1;
      for (int i = 2; i <= limit; i++) {
        if (val % i == 0) {
          result++;
        }
      }
      return result + 1;
    }
    public static List<int> GetDividers(int val) {
      if (val == 1) return new List<int>() { 1 };
      List<int> result = new List<int>() { 1 };
      var limit = (val / 2) + 1;
      for (int i = 2; i <= limit; i++) {
        if (val % i == 0) {
          result.Add(i);
        }
      }
      result.Add(val);
      return result;
    }

    public static List<int> GetPrimeDividers(int v) {
      var primes = GetPrimes(v);
      return GetPrimeDividers(v, primes);
    }
    public static List<int> GetPrimeDividers(int v, List<int> primes) {
      if (v == 1) return new List<int>() { };
      if (v == 2) return new List<int>() { 2 };
      if (v == 3) return new List<int>() { 3 };
      if (v == 4) return new List<int>() { 2 };
      var result = new List<int>();
      int rd = v;
      while (rd != 1) {

        try {
          int a = primes.First(prime => rd % prime == 0);
          result.Add(a);
          rd = rd / a;
        }
        catch (InvalidOperationException) {
          throw new ArgumentException("В коллекции недостаточно простых чисел.");
        }
        catch (Exception e) {
          Console.WriteLine(e);
          throw;
        }
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

    public static string LongSum(string a, string b, int step = 8) {
      var aInts = GetIntsFromString(a, step);
      var bInts = GetIntsFromString(b, step);
      var result = SumIntArr(aInts, bInts, step);
      StringBuilder sb = new StringBuilder();
      foreach (int i in result) {
        sb.Append(i);
      }
      var sResult = sb.ToString().TrimStart('0');
      //Console.WriteLine(sResult+":"+sResult.Length);
      return sResult;
    }

    public static int[] GetIntsFromString(string str, int len = 8) {
      // 123 1234 1234
      if (string.IsNullOrEmpty(str)) {
        throw new ArgumentException();
      }
      int[] result = new int[(int)Math.Ceiling((double)str.Length / len)];
      int move = len == 1 ? 0 : len - (str.Length % len);
      if (move == len) move = 0;
      result[0] = int.Parse(str.Substring(0, len - move));
      for (int i = 1; i < result.Length; i++) {
        result[i] = int.Parse(str.Substring(i * len - move, len));
      }
      return result;
    }

    public static int[] SumIntArr(int[] a, int[] b, int step) {
      int[] result = new int[Math.Max(a.Length, b.Length) + 1];
      int add = 0;
      for (int i = result.Length - 1, j = 0; i >= 0; i--, j++) {
        int indX = a.Length - j - 1;
        int x = indX >= 0 ? a[indX] : 0;
        int indY = b.Length - j - 1;
        int y = indY >= 0 ? b[indY] : 0;
        int z = x + y + add;
        add = z.ToString().Length > step ? int.Parse(z.ToString()[0].ToString()) : 0;

        string temp = "1";
        for (int k = 0; k < step; k++) {
          temp += "0";
        }
        int razr = int.Parse(temp);
        z = z % razr;
        result[i] = z;
      }
      return result;
    }

    public static string ReverseString(string str) {
      char[] chars = str.ToCharArray();
      for (int i = 0, j = str.Length - 1; i < j; i++, j--) {
        chars[i] = str[j];
        chars[j] = str[i];
      }
      return new string(chars);
    }

  }
}