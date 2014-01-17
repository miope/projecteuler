using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P006 : IProblem
    {
        public dynamic Solve()
        {
            var nums = 1.UpTo(100);
            return Math.Pow(nums.Sum(), 2.0) - nums.Select(n => n * n).Sum();
        }
    }
}
