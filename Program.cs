using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
       {
            DateTime _startTime;
            DateTime _endTime;
            TimeSpan _duration;

            var _problems = GetProblemsToSolve().OrderBy(t => t.GetType().Name);

            _problems.Each(p => {
                _startTime = DateTime.Now;
                Console.WriteLine(string.Format("{0} start: {1}", p.GetType().Name, _startTime.ToString("hh:mm:ss:fff")));
                Console.WriteLine(string.Format(" - solution: {0}", p.Solve()));
                _endTime = DateTime.Now;
                _duration = _endTime - _startTime;
                Console.WriteLine(string.Format("{0} end: {1}", p.GetType().Name, _endTime.ToString("hh:mm:ss:fff")));
                Console.WriteLine(string.Format("Duration: {0}s {1}ms", _duration.Seconds, _duration.Milliseconds ));
                Console.WriteLine();
            });

            Console.Write("Done...press <enter> to exit");
            Console.ReadLine();
        }

        private static IList<IProblem> GetProblemsToSolve()
        {
            return System.Reflection.Assembly.GetExecutingAssembly()
                                             .GetTypes()
                                             .Where(t => t.GetInterfaces()
                                                          .Where(iface => iface == typeof(IProblem))
                                                          .Any()
                                                    )
                                             .Select(t => (IProblem)Activator.CreateInstance(t))
                                             .ToList();
        }

    }
}
