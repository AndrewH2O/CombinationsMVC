using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsLib
{
    public class Generator
    {

        int digitMax, cageLength;
        List<int[]> solutions;
        int[] digits;

        public int SolutionsCount()
        {
            return solutions.Count();
        }

        public List<int[]> Solutions
        {
            get
            {
                return solutions;
            }
        }

        public Generator(int digitMax)
        {
            this.digitMax = digitMax;
            initialise();
        }

        /// <summary>
        /// Calculate all solutions for sets of size 1 to digitMax
        /// 
        /// In efficient version but the output is easier to confirm
        /// </summary>
        public void CalcAllCageLengths()
        {
            initialise();
            for (int i = 1; i < digitMax + 1; i++)
            {
                cageLength = i;
                digits = new int[cageLength];
                AddDigit(1, 0);
            }
        }

        /// <summary>
        /// Calculate all solutions for sets of size 1 to digitMax
        /// 
        /// More efficient version
        /// </summary>
        public void CalcAllCageLengths2()
        {
            initialise();

            cageLength = digitMax;
            digits = new int[cageLength];
            AddDigit2(1, 0);

        }

        private void initialise()
        {
            solutions = new List<int[]>();
        }

        public void CalcForCageLengthOf(int cageLength)
        {
            this.cageLength = cageLength;
            digits = new int[cageLength];
            AddDigit(1, 0);
        }

        void AddDigit(int digitMin, int digitIndex)
        {
            for (int i = digitMin; i < digitMax + 1; i++)
            {
                if (digitIndex >= cageLength) return;

                digits[digitIndex] = i;
                if (digitIndex == cageLength - 1)
                {
                    saveSolution();
                }

                AddDigit(i + 1, digitIndex + 1);
            }
        }

        /// <summary>
        /// Cycle through only once, starting with the maximum cagelength
        /// Each 'partial solution' to maximum cagelength search will be a 
        /// full solution to each of the respective intermediate cagelengths
        /// 
        /// </summary>
        /// <param name="digitMin"></param>
        /// <param name="digitIndex"></param>
        void AddDigit2(int digitMin, int digitIndex)
        {
            for (int i = digitMin; i < digitMax + 1; i++)
            {
                if (digitIndex >= cageLength) return;

                digits[digitIndex] = i;
                //save each solution along the way to avoid repetition
                saveSolution(digitIndex + 1);
                AddDigit2(i + 1, digitIndex + 1);
            }
        }

        private void saveSolution()
        {
            int[] t = new int[cageLength];
            Array.Copy(digits, t, cageLength);
            solutions.Add(t);
        }

        private void saveSolution(int cageLength)
        {
            int[] t = new int[cageLength];
            Array.Copy(digits, t, cageLength);
            solutions.Add(t);
        }
    }
}
