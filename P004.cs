using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P004 : IProblem
    {
        public dynamic Solve()
        {
            // Problem: find a largest palindrome made from the product of two 3-digit numbers

            return (from x in 100.UpTo(999)
                    from y in x.UpTo(999)
                    let n = x * y
                    where n.IsPalindromic()
                    orderby n descending
                    select n).First();
        }

    }
}
