using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public static class Extensions
    {
        public static IEnumerable<int> UpTo(this int start, int end)
        {
            while (start <= end)
            {
                yield return start;
                start++;
            }
        }

        public static IEnumerable<long> Fibonacci()
        {
            long prev = 0;  // previous number
            long curr = 1;  // current number
            long next;      // the next number of the fibonacci sequence

            while (true)
            {
                next = prev + curr;
                prev = curr;
                curr = next;

                yield return next;
            }
        }

        public static IEnumerable<long> Primes()
        {
            var odds = from n in Enumerable.Range(0, int.MaxValue) select 3 + (long)n * 2;

            return (new[] { 2L }).Concat(
                    from p in odds
                    where !odds.TakeWhile(o => o * o <= p).Any(o => p % o == 0)
                    select p
                );
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static bool IsPalindromic(this int number)
        {
            return number.ToString() == string.Join("", number.ToString().Reverse());
        }

        public static int Multiply(this IEnumerable<int> items)
        {
            return items.Count() == 0 ? 0 : items.Aggregate((accu, next) => accu * next);
        }

        public static IEnumerable<int> PrimeFactors(this int number)
        {
            int _num = number;
            int _prime = 2;

            while (_prime * _prime <= _num)
            {
                if (_num % _prime == 0)
                {
                    yield return _prime;
                    _num = _num / _prime;
                }
                else
                {
                    _prime++;
                }
            }

            if (_num != 1)
            {
                yield return _num;
            }
        }

        public static IEnumerable<int> Factors(this int number)
        {
            return 1.UpTo((int)Math.Sqrt(number))
                    .Where(f => number % f == 0)
                    .SelectMany(f => new[] { f, number / f });
        }

        public static IEnumerable<int> TriangleNumbers()
        {
            return 1.UpTo(int.MaxValue).Select(i => i * (i + 1) / 2);
        }

        public static bool IsPrime(this int num)
        {
            return !(from n in Enumerable.Range(0, int.MaxValue) select 1 + (long)n * 2)
                .TakeWhile(o => o * o < num)
                .Any(o => num % o == 0);
                   
        }
    }
}
