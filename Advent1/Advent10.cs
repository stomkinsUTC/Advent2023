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
            StreamReader sr = new StreamReader("..\\advent10TEST.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            pipe startPos = new pipe('F', 2, 0);
        }
    }

    internal class pipe
    {
        Char pipeChar;
        public pipe first;
        public pipe second;

        public pipe(char pc, int x, int y)
        {
            pipeChar = pc;
            if (checkPipe(pc, x, y))
            {
                Console.WriteLine("Valid pipe");
            }
            else
            {
                //Console.WriteLine("Invalid pipe at: " + y + ", " + x);
            }
        }

        private bool checkPipe(char pc, int x, int y)
        {
            bool validLoop = true;

            if (pc == '|')
            {
                if (y - 1 >= 0)
                {
                    first = new pipe(Advent10.inputData[y - 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (y + 1 < Advent10.inputData.Count())
                {
                    second = new pipe(Advent10.inputData[y + 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == '-')
            {
                if (x - 1 >= 0)
                {
                    first = new pipe(Advent10.inputData[y][x - 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (x + 1 < Advent10.inputData[0].Count())
                {
                    second = new pipe(Advent10.inputData[y][x + 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == 'L')
            {
                if (y - 1 >= 0)
                {
                    first = new pipe(Advent10.inputData[y - 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (x + 1 < Advent10.inputData[0].Count())
                {
                    second = new pipe(Advent10.inputData[y][x + 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == 'J')
            {
                if (y - 1 >= 0)
                {
                    first = new pipe(Advent10.inputData[y - 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (x - 1 >= 0)
                {
                    second = new pipe(Advent10.inputData[y][x - 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == '7')
            {
                if (y + 1 < Advent10.inputData.Count())
                {
                    first = new pipe(Advent10.inputData[y + 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (x - 1 >= 0)
                {
                    second = new pipe(Advent10.inputData[y][x - 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == 'F')
            {
                if (y + 1 < Advent10.inputData.Count())
                {
                    //ERROR
                    first = new pipe(Advent10.inputData[y - 1][x], x, y);
                }
                else
                {
                    validLoop = false;
                }
                if (x + 1 < Advent10.inputData[0].Count())
                {
                    second = new pipe(Advent10.inputData[y][x + 1], x, y);
                }
                else
                {
                    validLoop = false;
                }
            }
            else if (pc == '.')
            {
                validLoop = false;
            }

            Console.WriteLine("Pipe is: " + pc + ": " + validLoop + " at: " + y + ", " + x);

            return validLoop;
        }
    }

}
