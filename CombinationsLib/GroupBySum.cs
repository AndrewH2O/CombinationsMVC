using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsLib
{
    public class GroupBySum
    {
        public int Sum { get; set; }
        [Display(Name="Frequency")]
        public int SolutionFrequency { get; set; }
        [Display(Name="Solutions")]
        public IEnumerable<GroupBySolution> PossibleSolutions { get; set; }
    }
}
