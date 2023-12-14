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
            StreamReader sr = new StreamReader("..\\advent9.txt");
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
                //Console.WriteLine("Line: " + i);
                dataDifferences tempDD = dataDiffs[i];
                while (tempDD.diffs != null)
                {
                    tempDD = tempDD.diffs;
                }
            }

            long task1Total = 0;
            long task2Total = 0;
            foreach (dataDifferences dd in dataDiffs)
            {
                //Console.WriteLine("Previous num: " + dd.nums.First());
                task1Total += dd.nums.Last();
                task2Total += dd.nums.First();
            }

            Console.WriteLine("Day 9 Task 1: " + task1Total);
            Console.WriteLine("Day 9 Task 2: " + task2Total);
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
            if (diffs != null)
            {
                nums.Add(nums.Last() + diffs.nums.Last());
                nums.Insert(0, nums[0] - diffs.nums[0]);
            }
            else
            {
                nums.Add(nums[nums.Count - 1] + nums[nums.Count - 1] - nums[nums.Count - 2]);
                nums.Insert(0, nums[0] + nums[0] - nums[1]);
            }
        }

        public List<long> getDifferences(List<long> inputNums)
        {
            List<long> tempDiffs = new List<long>();
            for (int i = 0; i < nums.Count - 1; i++)
            {
                tempDiffs.Add(nums[i + 1] - nums[i]);
            }
            return tempDiffs;
        }
    }
}
