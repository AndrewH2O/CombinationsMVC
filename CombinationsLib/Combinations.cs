using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsLib
{
    public class Combinations
    {
        const int ERROR= -1;
        const int OK = 1;
        public const int MAX_DIGIT_ALLOWED = 9;
        
        IEnumerable<int[]> solutions;


        public Combinations(){}
        
        /// <summary>
        /// Generate solutions, maximum number of Digits must be 
        /// no larger than MAX_DIGIT_ALLOWED
        /// 
        /// Returns Error or OK
        /// </summary>
        /// <param name="maxNumberDigits"></param>
        /// <returns></returns>
        public int Generate(int maxNumberDigits)
        {
            if (maxNumberDigits > MAX_DIGIT_ALLOWED) return ERROR;
            Generator gen = new Generator(maxNumberDigits);
            solutions = null;
            solutions = new List<int[]>();
            gen.CalcAllCageLengths2();
            solutions = gen.Solutions;

            return OK;
        }

        /// <summary>
        /// Display list of solutions
        /// </summary>
        /// <param name="display"></param>
        public void DisplayRawSolutions(Action<int[]> display)
        {
            if (solutions == null) return;
            foreach (var solutions in solutions)
            {
                display(solutions);
            }

        }

        /// <summary>
        /// Shape solution data
        /// </summary>
        /// <param name="display"></param>
        public void DisplaySolutionSets(Action<GroupByDigitCount> display)
        {
            if (solutions == null) return;
            var result = solutions.GroupBy(s => s.Count())
                .Select(byDigitCount => new GroupByDigitCount()
                {
                    DigitCount = byDigitCount.First().Select(x => x).Count(),
                    SolutionsCount = byDigitCount.Count(),
                    GroupByDigits = byDigitCount.GroupBy(x => x.Sum())
                    .Select(bySumOfDigits => new GroupBySum()
                    {
                        Sum = bySumOfDigits.First().Sum(),
                        SolutionFrequency = bySumOfDigits.Count(),
                        PossibleSolutions = bySumOfDigits.Select(z => new GroupBySolution()
                        {
                            Solution = z,
                            Count = z.Count(),
                            Sum = z.Sum()
                        })
                    })

                });

            foreach (var groupByDigit in result)
            {
                display(groupByDigit);
            }

        }

    }
}
