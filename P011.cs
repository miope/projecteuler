using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class P011 : IProblem
    {
        public dynamic Solve()
        {
            // this is a somewhat longer version
            // the problem can be solved with much less lines of code but then
            // we wouldn't know where i.e. which 4 consequent numbers are giving the biggest product

            var _grid = System.IO.File.ReadAllLines("problem_11.grid.txt")
                                      .SelectMany(l => l.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                                      .Select(s => int.Parse(s))
                                      .Select((a, i) =>
                                      {
                                          var _row = (i / 20) + 1;
                                          return new
                                          {
                                              Value = a,
                                              Row = _row,
                                              Col = i + 1 - (_row - 1) * 20
                                          };
                                      }).ToList();

            var _cells = _grid.Select(c => new
                {
                    Cell = c,
                    North = _grid.Where(p => p.Col == c.Col && p.Row < c.Row && p.Row > c.Row - 4),
                    East = _grid.Where(p => p.Row == c.Row && p.Col > c.Col && p.Col < c.Col + 4),
                    South = _grid.Where(p => p.Col == c.Col && p.Row > c.Row && p.Row < c.Row + 4),
                    West = _grid.Where(p => p.Row == c.Row && p.Col < c.Col && p.Col > c.Col - 4),
                    NorthEast = _grid.Where(p => p.Row - c.Row < 0 && c.Row - p.Row == p.Col - c.Col).Take(3),
                    SouthEast = _grid.Where(p => p.Row - c.Row > 0 && p.Row - c.Row == p.Col - c.Col).Take(3),
                    SouthWest = _grid.Where(p => p.Row - c.Row > 0 && p.Row - c.Row == c.Col - p.Col).Take(3),
                    NorthWest = _grid.Where(p => p.Row - c.Row < 0 && p.Row - c.Row == p.Col - c.Col).Take(3)
                })
                .Select(c => new { 
                    Cell = c,
                    Products = new [] {
                        c.North.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.NorthEast.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.East.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.SouthEast.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.South.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.SouthWest.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.West.Select(p => p.Value).Multiply() * c.Cell.Value,
                        c.NorthWest.Select(p => p.Value).Multiply() * c.Cell.Value
                    }
                }).ToList();

            // this is just so we know where exactly is it
            // we know exactly the cell where it all starts
            var _theCell = from c in _cells
                           let maxProd = (from cc in _cells select cc.Products.Max()).Max()
                           where c.Products.Max() == maxProd
                           select c;

            return _cells.Select(c => c.Products.Max()).Max();
        }
    }
}
