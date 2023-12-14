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

            //THIS IS SPECIFIC TO THE "S" BEING AN "F"
            int[] prevPos = { col + 1, row };
            char startChar = 'F';


            //NOT WORKING
            Console.WriteLine("S found at: " + startPos[0] + ", " + startPos[1]);
            Console.WriteLine("Previous at: " + prevPos[0] + ", " + prevPos[1]);

            Console.WriteLine("Next at: " + getNextPos(startChar, startPos, prevPos)[0] + ", Col: " + getNextPos(startChar, startPos, prevPos)[1]);
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
