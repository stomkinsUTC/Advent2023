using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Advent2023
{
    internal class Advent4
    {
        List<string> inputData = new List<string>();
        List<List<int>> winningNums = new List<List<int>>();
        List<List<int>> checkNums = new List<List<int>>();
        List<int> multipliers = new List<int>();

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent4.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                winningNums.Add(new List<int>());
                checkNums.Add(new List<int>());
                multipliers.Add(1);
                line = sr.ReadLine();
            }
            sr.Close();

            for (int i = 0; i < inputData.Count; i++)
            {
                string allData = inputData[i].Split(":")[1];
                string tempWinners = allData.Split("|")[0];
                string tempChecks = allData.Split("|")[1];
                
                foreach (string str in tempWinners.Split(" "))
                {
                    if (str.Length > 0)
                    {
                        winningNums[i].Add(int.Parse(str));
                    }
                }
                foreach (string str in tempChecks.Split(" "))
                {
                    if (str.Length > 0)
                    {
                        checkNums[i].Add(int.Parse(str));
                    }
                }
            }

            int totalScore = 0;
            for (int i = 0; i < winningNums.Count;i++)
            {
                int score = 0;
                int multScore = 0;
                foreach (int num in winningNums[i])
                {
                    if (checkNums[i].Contains(num))
                    {
                        multScore+= 1;
                        if (score == 0)
                        {
                            score = 1;
                        }
                        else
                        {
                            score *= 2;
                        }
                    }
                }
                totalScore += score;

                for (int j = i + 1; j < i + multScore + 1; j++)
                {
                    for (int k = 0; k < multipliers[i]; k++)
                    {
                        multipliers[j] += 1;
                    }
                }
            }

            int task2Total = 0;
            foreach (int mult in multipliers)
            {
                task2Total += mult;
            }
            Console.WriteLine("Day 4 Task 1: " + totalScore);
            Console.WriteLine("Day 4 Task 2: " + task2Total);
        }
    }
}
