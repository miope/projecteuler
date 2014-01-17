using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P012 : IProblem
    {
        public dynamic Solve()
        {
            return Extensions.TriangleNumbers().First(tn => tn.Factors().Count() > 500);
        }
    }
}
