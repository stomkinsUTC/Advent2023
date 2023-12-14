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

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent10.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
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
                    }
                }
            }

            int[] startPos = { col, row };
            int[] originalPos = startPos;

            //THIS IS SPECIFIC TO THE "S" BEING AN "F"
            int[] prevPos = { col + 1, row };
            char startChar = 'F';

            //Home
            //int[] prevPos = { col, row - 1 };
            //char startChar = 'J';


            /*Console.WriteLine("Previous at: " + prevPos[0] + ", " + prevPos[1]);
            Console.WriteLine("S found at: " + startPos[0] + ", " + startPos[1]);
            Console.WriteLine("Next at: " + getNextPos(startChar, startPos, prevPos)[0] + ", " + getNextPos(startChar, startPos, prevPos)[1]);*/

            int[] nextPos = getNextPos(startChar, startPos, prevPos);
            int stepsTaken = 0;
            prevPos = startPos;
            while (nextPos != startPos && !nextPos.Contains(-1))
            {
                int[] temp = nextPos;
                nextPos = getNextPos(inputData[nextPos[0]][nextPos[1]], nextPos, prevPos);
                prevPos = temp;
                stepsTaken++;
            }
            Console.WriteLine("Day 10 Task 1: " + stepsTaken/2);


            /*For Task 2, set up a 2D array to store whether each tile is:
             I - Inside
             O - Outside
             P - Pipe
             If a tile borders an edge and isn't a pipe, it must be O.
             If a tile borders an O, it must also be an O.
             If a tile is entirely surrounded by I's and P's, it must be an I.*/
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

        public bool checkPipe(char pc, int col, int row)
        {
            bool validLoop = true;

            

            //Console.WriteLine("Pipe is: " + pc + ": " + validLoop + " at: " + y + ", " + x);

            return validLoop;
        }

    }

    internal class pipe
    {
        Char pipeChar;
        public pipe first;
        public pipe second;

        public pipe(char pc, int x, int y)
        {
            /*pipeChar = pc;
            if (checkPipe(pc, x, y))
            {
                Console.WriteLine("Valid pipe");
            }
            else
            {
                //Console.WriteLine("Invalid pipe at: " + y + ", " + x);
            }*/
        }

        
    }

}
