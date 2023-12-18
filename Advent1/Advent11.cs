using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent11
    {
        public static List<string> inputData = new List<string>();
        public List<int> galaxyX = new List<int>();
        public List<int> galaxyY = new List<int>();

        bool task1 = true;
        bool task2 = false;

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent11.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            //True for task 1, false for task 2
            
            ExpandUniverse(task2);
            FindGalaxies();

            //Console.WriteLine("Unique Pairs: " + (galaxyX.Count() * (galaxyX.Count() - 1)) / 2);

            long galaxyTotal = 0;
            for (int i = 0; i < galaxyX.Count -1; i++)
            {
                for (int j = i + 1; j < galaxyX.Count; j++)
                {
                    //Console.WriteLine("Combination: " + i + ", " + j);
                    galaxyTotal += (Math.Abs(galaxyX[i] - galaxyX[j]) + Math.Abs(galaxyY[i] - galaxyY[j]));
                }
            }
            if (task1)
            {
                Console.WriteLine("Day 11 Task 1: " + galaxyTotal);
            }
            else
            {
                Console.WriteLine("Day 11 Task 2: " + galaxyTotal);
            }
        }

        /*Expand horizontally, then rotate 90 degrees.
          Expand horizontally again, then rotate back.*/
        public void ExpandUniverse(bool task1)
        {
            if (task1)
            {
                ExpandHorizontally(1);
                RotateUniverse(true);
                ExpandHorizontally(1);
                RotateUniverse(false);
            }
            else
            {
                ExpandHorizontally(999999);
                RotateUniverse(true);
                ExpandHorizontally(999999);
                RotateUniverse(false);
            }
        }

        public void ExpandHorizontally(int expansion)
        {
            List<int> rowIndexes = new List<int>();
            int rowOffset = 0;
            string lineToAdd = "";
            Console.WriteLine("Expanding:");
            for (int i = 0; i < inputData.Count; i++)
            {
                Console.WriteLine(i + "/" + (inputData.Count - 1));
                if (!inputData[i].Contains('#'))
                {
                    for (int j = 0; j < expansion; j++)
                    {
                        rowIndexes.Add(i + rowOffset + j);
                    }
                    rowOffset += expansion;

                    lineToAdd = inputData[i];
                }
            }
            foreach (int index in rowIndexes)
            {
                inputData.Insert(index, lineToAdd);
            }
        }

        //CHANGE THIS, THIS IS WHAT IS KILLING THE PROGRAM
        /*Lazy way to rotate the list counterclockwise, but it works.*/
        public void RotateUniverse(bool clockwise)
        {
            if (clockwise)
            {
                List<string> tempData = new List<string>();
                List<string> rotatedData = new List<string>();
                for (int yPos = 0; yPos < inputData[0].Length; yPos++)
                {
                    List<char> line = new List<char>();
                    for (int xPos = inputData.Count - 1; xPos >= 0; xPos--)
                    {
                        line.Add(inputData[xPos][yPos]);
                    }
                    tempData.Add(String.Concat(line));
                }
                inputData = tempData;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    RotateUniverse(true);
                }
            }
            
        }

        public void FindGalaxies()
        {
            for (int row = 0; row < inputData.Count; row++)
            {
                for (int col = 0; col < inputData[row].Length; col++)
                {
                    if (inputData[row][col] == '#')
                    {
                        galaxyX.Add(col);
                        galaxyY.Add(row);
                    }
                }
            }
        }
    }
}
