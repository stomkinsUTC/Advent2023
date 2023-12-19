using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent11
    {
        public static List<string> inputData = new List<string>();
        public static List<string> backupData = new List<string>();
        public List<int> galaxyX = new List<int>();
        public List<int> galaxyY = new List<int>();

        public List<int> verticalPoints = new List<int>();

        public int expansionAmount = 0;

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
            backupData = inputData;

            //True for task 1, false for task 2
            bool task1 = false;
            
            
            if (task1)
            {
                ExpandUniverse(true);
                FindGalaxies();

                long galaxyTotal = 0;
                for (int i = 0; i < galaxyX.Count - 1; i++)
                {
                    for (int j = i + 1; j < galaxyX.Count; j++)
                    {
                        //Console.WriteLine("Combination: " + i + ", " + j);
                        galaxyTotal += (Math.Abs(galaxyX[i] - galaxyX[j]) + Math.Abs(galaxyY[i] - galaxyY[j]));
                    }
                }
                Console.WriteLine("Day 11 Task 1: " + galaxyTotal);
            }
            else
            {
                Console.WriteLine("Day 11 Task 2: " + findPointForEquation());
            }
        }

        public long findPointForEquation()
        {
            ExpandUniverse(false);
            FindGalaxies();

            long yFor0 = 0;
            for (int i = 0; i < galaxyX.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxyX.Count; j++)
                {
                    yFor0 += (Math.Abs(galaxyX[i] - galaxyX[j]) + Math.Abs(galaxyY[i] - galaxyY[j]));
                }
            }
            inputData = backupData;
            galaxyX = new List<int>();
            galaxyY = new List<int>();
            verticalPoints = new List<int>();

            expansionAmount++;

            ExpandUniverse(false);
            FindGalaxies();

            long yFor1 = 0;
            for (int i = 0; i < galaxyX.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxyX.Count; j++)
                {
                    yFor1 += (Math.Abs(galaxyX[i] - galaxyX[j]) + Math.Abs(galaxyY[i] - galaxyY[j]));
                }
            }

            Console.WriteLine("0: " + yFor0);
            Console.WriteLine("1: " + yFor1);
            //Enter these values into Wolfram Alpha in the form of (0, total)(1, total) equation
            Console.Write("Enter the X multiplier: ");
            long xMult = long.Parse(Console.ReadLine());
            Console.Write("Enter the addition: ");
            long addition = long.Parse(Console.ReadLine());


            return (xMult * 999999) + addition;
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
                IdentifyVerticals();
                ExpandHorizontally(expansionAmount);
                ExpandVertically(expansionAmount);

                /**/
            }
        }

        public void ExpandHorizontally(int expansion)
        {
            List<int> rowIndexes = new List<int>();
            int rowOffset = 0;
            string lineToAdd = "";
            //Console.WriteLine("Expanding:");
            for (int i = 0; i < inputData.Count; i++)
            {
                //Console.WriteLine(i + "/" + (inputData.Count - 1));
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

        public void IdentifyVerticals()
        {
            for (int i = 0; i < inputData[0].Length; i++)
            {
                StringBuilder tempStr = new StringBuilder("");
                for (int j = 0; j < inputData.Count; j++)
                {
                    tempStr.Append(inputData[j][i]);
                }
                if (!tempStr.ToString().Contains("#"))
                {
                    verticalPoints.Add(i);
                }
            }
        }

        public void ExpandVertically(int expansion)
        {
            StringBuilder sbToAppend = new StringBuilder();
            for (int i = 0; i < expansion; i++)
            {
                sbToAppend.Append(".");
            }    
            string toAppend = sbToAppend.ToString();

            for (int line = 0; line < inputData.Count; line++)
            {
                int appendedCount = 0;
                foreach (int point in verticalPoints)
                {
                    int index = point + (appendedCount * expansion);
                    inputData[line] = new StringBuilder(inputData[line].Insert(index, toAppend)).ToString();
                    appendedCount++;
                }
            }
        }

        //CHANGE THIS, THIS IS WHAT IS KILLING THE PROGRAM IN TASK 2
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
