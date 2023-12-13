using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent8
    {
        List<string> inputData = new List<string>();
        List<direction> directionData = new List<direction>();
        string lrData = "";

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent8.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            lrData = inputData[0];

            for (int i = 2; i < inputData.Count; i++)
            {
                directionData.Add(new direction(inputData[i].Substring(0, 3), inputData[i].Substring(7, 3), inputData[i].Substring(12, 3)));
            }

            int stepsTaken = 0;
            bool zzzFound = false;
            direction nextPos = directionData.Find(i => i.current == "AAA");
            while (!zzzFound)
            {
                foreach (char lrDir in lrData)
                {
                    if (nextPos.current != "ZZZ")
                    {
                        if (lrDir == 'L')
                        {
                            nextPos = directionData.Find(i => i.current == nextPos.left);
                        }
                        else
                        {
                            nextPos = directionData.Find(i => i.current == nextPos.right);
                        }
                        stepsTaken++;    
                    }
                    else
                    {
                        zzzFound = true;
                        break;
                    }
                }
            }

            Console.WriteLine("Day 8 Task 1: " + stepsTaken);
        }
    }

    internal class direction
    {
        public string current;
        public string left;
        public string right;

        public direction(string c, string l, string r)
        {
            current = c;
            left = l;
            right = r;
        }
    }
}
