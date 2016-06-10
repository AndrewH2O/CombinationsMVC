using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsLib
{
    public class GroupByDigitCount
    {
        [Display(Name = "Digit Count")]
        public int DigitCount { get; set; }
        [Display(Name = "Solutions Count")]
        public int SolutionsCount { get; set; }
        public IEnumerable<GroupBySum> GroupByDigits { get; set; }
    }
}
