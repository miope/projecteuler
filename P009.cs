using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P009 : IProblem
    {
        public dynamic Solve()
        {
            return (from a in 1.UpTo(500)
                    from b in a.UpTo(500)
                    let c = 1000 - a - b
                    where a < b
                    where (a * a) + (b * b) == (c * c)
                    select a * b * c).Single();
        }
    }
}
