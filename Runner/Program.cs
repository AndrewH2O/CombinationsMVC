using CombinationsLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Combinations c = new Combinations();
            c.Generate(9);
            c.DisplayRawSolutions((solutionSet) =>
            {
                foreach (var solution in solutionSet)
                {
                    Debug.Write(solution);
                }
                Debug.WriteLine("");
            });

            c.DisplaySolutionSets((groupByDigit) =>
            {
                Debug.WriteLine("Digit count {0}, solutions count {1} ", groupByDigit.DigitCount, groupByDigit.SolutionsCount);
                foreach (var groupBySum in groupByDigit.GroupByDigits)
                {
                    Debug.Write(string.Format("Sum: {0}, Count: {1}, ", groupBySum.Sum, groupBySum.SolutionFrequency));
                    foreach (var groupBySolution in groupBySum.PossibleSolutions)
                    {
                        foreach (var solution in groupBySolution.Solution)
                        {
                            Debug.Write(solution);
                        }
                        Debug.Write(", ");
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("");
            });

            Console.WriteLine("done..");
            Console.ReadLine();
        }
    }
}
