using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P007 : IProblem
    {
        public dynamic Solve()
        {
            return Extensions.Primes().Skip(10000).First();
        }
    }
}
