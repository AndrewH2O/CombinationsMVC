using CombinationsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CombinationsUI.Models
{
    public class CombinationsRepo
    {
        Combinations combinations = new Combinations();

        public IEnumerable<GroupByDigitCount> GetSolutionSets()
        {
            combinations.Generate(9);
            var results = new List<GroupByDigitCount>();
            combinations.DisplaySolutionSets((groupByDigit) =>
            {
                results.Add(groupByDigit);
            });
            return results;
        }

        
            
            
    }
}