using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent9
    {
        List<string> inputData = new List<string>();
        List<dataDifferences> dataDiffs = new List<dataDifferences>();

        public void main ()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent9TEST.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            foreach(string data in inputData)
            {
                List<long> tempData = new List<long>();
                string[] tempSplit = data.Split(" ");
                foreach (string s in tempSplit)
                {
                    tempData.Add(long.Parse(s));
                }
                dataDiffs.Add(new dataDifferences(tempData));
            }

            for (int i = 0; i < dataDiffs.Count; i++)
            {
                Console.WriteLine("Line: " + i);
                dataDifferences tempDD = dataDiffs[i];
                while (tempDD.diffs != null)
                {
                    Console.WriteLine("Difference found");
                    /*Maybe need to add a property to the class here to store the next item.
                     Next item is the sum of the last difference and the last num.
                    This should then iterate up to the top level to get the difference.*/
                    tempDD = tempDD.diffs;
                }
            }
        }
    }

    internal class dataDifferences
    {
        public List<long> nums = new List<long>();
        public dataDifferences diffs;

        public dataDifferences(List<long> inputNums)
        {
            nums = inputNums;

            //If all of the differences aren't equal, recurse down. (I think)
            if (getDifferences(nums).Distinct().Count() != 1)
            {
                diffs = new dataDifferences(getDifferences(nums));
                diffs.diffs = new dataDifferences(getDifferences(diffs.nums));
            }
        }

        public List<long> getDifferences(List<long> inputNums)
        {
            List<long> tempDiffs = new List<long>();
            for (int i = 0; i < nums.Count - 1; i++)
            {
                tempDiffs.Add(Math.Abs(nums[i] - nums[i + 1]));
            }
            return tempDiffs;
        }
    }
}
