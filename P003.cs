using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    public class P003 : IProblem
    {
        public dynamic Solve()
        {
            var num = 600851475143;
            return Extensions.Primes()
                             .TakeWhile(p => p * p <= num)
                             .Where(p => num % p == 0)
                             .Last();
        }

    }
}
