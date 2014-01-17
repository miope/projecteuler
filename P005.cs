using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P005 : IProblem
    {
        public dynamic Solve()
        {
            return 1.UpTo(int.MaxValue)
                    .Select(n => n * 2520)
                    .First(n => {
                        return 11.UpTo(20).All(i => n % i == 0);
                    });
        }
    }
}
