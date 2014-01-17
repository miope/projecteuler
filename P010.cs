using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P010 : IProblem
    {
        public dynamic Solve()
        {
            return Extensions.Primes().TakeWhile(prime => prime < 2000000).Sum();
        }
    }
}
