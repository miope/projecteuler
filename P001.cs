using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P001 : IProblem
    {
        public dynamic Solve()
        {
            return 1.UpTo(999).Where(i => i % 3 == 0 | i % 5 == 0).Sum();
        }

    }
}
