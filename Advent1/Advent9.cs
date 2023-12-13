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
                dataDiffs.Add(new dataDifferences(data));
            }

            foreach (dataDifferences diff in dataDiffs)
            {
                Console.WriteLine(diff.diffs.nums[0]);
            }
        }
    }

    internal class dataDifferences
    {
        public List<long> nums = new List<long>();
        public dataDifferences diffs;

        public dataDifferences(string inputNums)
        {
            string[] tempSplit = inputNums.Split(" ");
            foreach (string s in tempSplit)
            {
                nums.Add(long.Parse(s));
            }

            List<long> tempDiffs = new List<long>();
            for (int i = 0; i < nums.Count-1; i++)
            {
                tempDiffs.Add(Math.Abs(nums[i] - nums[i + 1]));
            }
            diffs = new dataDifferences(tempDiffs);

            //If all of the differences aren't equal.
            if (diffs.nums.Distinct().Count() != 1)
            {
                //Need to recurse here but not sure how.
            }
        }

        private dataDifferences(List<long> inputNums)
        {
            nums = inputNums;
        }
    }
}
