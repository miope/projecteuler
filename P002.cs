using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P002 : IProblem
    {
        public dynamic Solve()
        {
            return Extensions.Fibonacci().Where(i => i % 2 == 0).TakeWhile(i => i < 4e6).Sum();
        }

       
    }
}
