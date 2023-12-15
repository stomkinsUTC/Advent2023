using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent10
    {
        public static List<string> inputData = new List<string>();
        public static List<StringBuilder> modifiedData = new List<StringBuilder>();
        public List<List<bool>> partOfPipe = new List<List<bool>>();

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent10TEST.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                modifiedData.Add(new StringBuilder(line));
                partOfPipe.Add(new List<bool>());
                line = sr.ReadLine();
            }
            sr.Close();

            int col = 0;
            int row = 0;
            for (int i = 0; i < inputData.Count; i++)
            {
                for (int j = 0; j < inputData[0].Length; j++)
                {
                    
                    if (inputData[i][j] == 'S')
                    {
                        col = i;
                        row = j;
                        partOfPipe[i].Add(true);
                    }
                    else
                    {
                        partOfPipe[i].Add(false);
                    }
                }
            }

            int[] startPos = { col, row };
            int[] originalPos = startPos;

            //Work - Main code
            //int[] prevPos = { col + 1, row };
            //char startChar = 'F';

            //Work - Test code
            int[] prevPos = { col + 1, row };
            char startChar = 'F';
            partOfPipe[col + 1][row] = true;

            //Home
            //int[] prevPos = { col, row - 1 };
            //char startChar = 'J';


            Console.WriteLine("Previous at: " + prevPos[0] + ", " + prevPos[1]);
            Console.WriteLine("S found at: " + startPos[0] + ", " + startPos[1]);
            Console.WriteLine("Next at: " + getNextPos(startChar, startPos, prevPos)[0] + ", " + getNextPos(startChar, startPos, prevPos)[1]);

            int[] nextPos = getNextPos(startChar, startPos, prevPos);
            int stepsTaken = 0;
            prevPos = startPos;
            while (nextPos != startPos && !nextPos.Contains(-1))
            {
                int[] temp = nextPos;
                nextPos = getNextPos(inputData[nextPos[0]][nextPos[1]], nextPos, prevPos);
                partOfPipe[prevPos[0]][prevPos[1]] = true;
                prevPos = temp;
                stepsTaken++;
            }
            Console.WriteLine("Day 10 Task 1: " + stepsTaken/2);

            int changeCount = 1;
            while (changeCount > 0)
            {
                changeCount = 0;
                for (int mCol = 0; mCol < modifiedData.Count; mCol++)
                {
                    for (int mRow = 0; mRow < modifiedData[0].Length; mRow++)
                    {
                        if (isO(mCol, mRow))
                        {
                            changeCount++;
                        }
                    }
                }
            } 

            int task2Count = 0;
            for (int mCol = 0; mCol < modifiedData.Count; mCol++)
            {
                for (int mRow = 0; mRow < modifiedData[0].Length; mRow++)
                {
                    if (modifiedData[mCol][mRow] == '.')
                    {
                        modifiedData[mCol][mRow] = 'I';
                        task2Count++;
                    }
                }
            }

            Console.WriteLine("Day 10 Task 2: " + task2Count);

            foreach (StringBuilder id in modifiedData)
            {
                Console.WriteLine(id);
            }
        }

        public bool isPipe(char pipe)
        {
            return "|-LJ7F".Contains(pipe);
        }

        public bool isStartOrEnd(char pipe)
        {
            return pipe == 'S';
        }

        public int[] getNextPos(char pipeChar, int[]currPos, int[] prevPos)
        {
            int[] nextPos = { -1, -1 };

            if (pipeChar == '|')
            {
                if (prevPos[0] != currPos[0] - 1)
                {
                    if (currPos[0] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0] - 1;
                        nextPos[1] = currPos[1];
                    }
                }
                else
                {
                    if (currPos[0] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0] + 1;
                        nextPos[1] = currPos[1];
                    }
                }
            }
            else if (pipeChar == '-')
            {
                if (prevPos[1] != currPos[1] - 1)
                {
                    if (currPos[1] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] - 1;
                    }
                }
                else
                {
                    if (currPos[1] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] + 1;
                    }
                }
            }
            else if (pipeChar == 'L')
            {
                if (prevPos[0] != currPos[0] - 1)
                {
                    if (currPos[0] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0] - 1;
                        nextPos[1] = currPos[1];
                    }
                }
                else
                {
                    if (currPos[1] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] + 1;
                    }
                }
            }
            else if (pipeChar == 'J')
            {
                if (prevPos[0] != currPos[0] - 1)
                {
                    if (currPos[0] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0] - 1;
                        nextPos[1] = currPos[1];
                    }
                }
                else
                {
                    if (currPos[1] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] - 1;
                    }
                }
            }
            else if (pipeChar == '7')
            {
                if (prevPos[0] != currPos[0] + 1)
                {
                    if (currPos[0] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0] + 1;
                        nextPos[1] = currPos[1];
                    }
                }
                else
                {
                    if (currPos[1] - 1 >= 0)
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] - 1;
                    }
                }
            }
            else if (pipeChar == 'F')
            {
                if (prevPos[0] != currPos[0] + 1)
                {
                    if (currPos[0] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0] + 1;
                        nextPos[1] = currPos[1];
                    }
                }
                else
                {
                    if (currPos[1] + 1 < inputData.Count())
                    {
                        nextPos[0] = currPos[0];
                        nextPos[1] = currPos[1] + 1;
                    }
                }
            }

            return nextPos;
        }

        public bool isO(int col, int row)
        {
            bool changeMade = false;
            if (!partOfPipe[col][row])
            {
                if (col == 0 || col == modifiedData.Count - 1 || row == 0 || row == modifiedData[0].Length - 1)
                {
                    modifiedData[col][row] = 'O';
                    changeMade = true;
                    partOfPipe[col][row] = true;
                }
            }
            else if (modifiedData[col][row] == 'O')
            {
                if (col + 1 < modifiedData.Count && !partOfPipe[col + 1][row])
                {
                    modifiedData[col + 1][row] = 'O';
                    changeMade = true;
                    partOfPipe[col + 1][row] = true;
                }
                if (col - 1 >= 0 && !partOfPipe[col - 1][row])
                {
                    modifiedData[col - 1][row] = 'O';
                    changeMade = true;
                    partOfPipe[col - 1][row] = true;
                }
                if (row + 1 < modifiedData[0].Length && !partOfPipe[col][row + 1])
                {
                    modifiedData[col][row + 1] = 'O';
                    changeMade = true;
                    partOfPipe[col][row + 1] = true;
                }
                if (row - 1 >= 0 && !partOfPipe[col][row - 1])
                {
                    modifiedData[col][row - 1] = 'O';
                    changeMade = true;
                    partOfPipe[col][row - 1] = true;
                }

                if (col + 3 < modifiedData.Count && !isPipe(modifiedData[col + 3][row]))
                {
                    if ((isPipe(modifiedData[col + 2][row]) || isStartOrEnd(modifiedData[col + 2][row])) && (isPipe(modifiedData[col + 1][row]) || isStartOrEnd(modifiedData[col + 1][row])))
                    {
                        modifiedData[col + 3][row] = 'O';
                        changeMade = true;
                    }
                    else
                    {
                        modifiedData[col + 3][row] = 'I';
                        changeMade = true;
                    }
                }
                if (col - 3 >= 0 && !isPipe(modifiedData[col - 3][row]))
                {
                    if ((isPipe(modifiedData[col - 2][row]) || isStartOrEnd(modifiedData[col - 2][row])) && (isPipe(modifiedData[col - 1][row]) || isStartOrEnd(modifiedData[col - 1][row])))
                    {
                        modifiedData[col - 3][row] = 'O';
                        changeMade = true;
                    }
                    else
                    {
                        modifiedData[col - 3][row] = 'I';
                        changeMade = true;
                    }
                }
                if (row + 3 < modifiedData[0].Length && !isPipe(modifiedData[col][row + 3]))
                {
                    if ((isPipe(modifiedData[col][row + 2]) || isStartOrEnd(modifiedData[col][row + 2])) && (isPipe(modifiedData[col][row + 1]) || isStartOrEnd(modifiedData[col][row + 1])))
                    {
                        modifiedData[col][row + 3] = 'O';
                        changeMade = true;
                    }
                    else
                    {
                        modifiedData[col][row + 3] = 'I';
                        changeMade = true;
                    }
                }
                if (row - 3 >= 0 && !isPipe(modifiedData[col][row - 3]))
                {
                    if ((isPipe(modifiedData[col][row - 2]) || isStartOrEnd(modifiedData[col][row - 2])) && (isPipe(modifiedData[col][row - 1]) || isStartOrEnd(modifiedData[col][row - 1])))
                    {
                        modifiedData[col][row - 3] = 'O';
                        changeMade = true;
                    }
                    else
                    {
                        modifiedData[col][row - 3] = 'I';
                        changeMade = true;
                    }
                }

            }
            return changeMade;
        }

    }

}
