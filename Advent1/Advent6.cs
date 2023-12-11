using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent6
    {
        List<string> inputData = new List<string>();
        List<long> raceTimes = new List<long>();
        List<long> recordDistances = new List<long>();

        long task2RaceTime;
        long task2RecordDistance;

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent6.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            long task1Total = 0;
            SetTimesAndDistances();
            for (int i = 0; i < raceTimes.Count; i++)
            {
                if (task1Total == 0)
                {
                    task1Total = CheckRecordCount(raceTimes[i], recordDistances[i]);
                }
                else
                {
                    task1Total *= CheckRecordCount(raceTimes[i], recordDistances[i]);
                }
            }
            Console.WriteLine("Day 6 Task 1: " + task1Total);
            Console.WriteLine("Day 6 Task 2: " + CheckRecordCount(task2RaceTime, task2RecordDistance));
        }

        public long CheckRecordCount(long raceTime, long recordDistance)
        {
            int winCount = 0;
            for (long i = 1; i < raceTime; i++)
            {
                long distance = i * (raceTime - i);
                if (distance > recordDistance)
                {
                    winCount++;
                }
            }
            return winCount;
        }

        public void SetTimesAndDistances()
        {
            List<string> tempData = Advent1.ArrayToList(inputData[0].Split(" "));
            tempData.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            tempData.RemoveAt(0);
            foreach (string str in tempData)
            {
                raceTimes.Add(long.Parse(str));
            }
            tempData = Advent1.ArrayToList(inputData[1].Split(" "));
            tempData.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            tempData.RemoveAt(0);
            foreach (string str in tempData)
            {
                recordDistances.Add(long.Parse(str));
            }

            task2RaceTime = long.Parse(inputData[0].Split(":")[1].Replace(" ", ""));
            task2RecordDistance = long.Parse(inputData[1].Split(":")[1].Replace(" ", ""));
        }
    }

}
