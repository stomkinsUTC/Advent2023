using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent3
    {
        List<string> inputData = new List<string>();
        List<string> tempData = new List<string>();
        List<numCoords> numCoords = new List<numCoords>();
        List<int> invalidCoords = new List<int>() {-1, -1};

        int maxRow = 0;
        int maxCol = 0;

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent3.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            maxRow = inputData[0].Count() - 1;
            maxCol = inputData.Count() - 1;

            Task1();
            Task2();
        }

        public bool isNeighbourChar(int col, int row)
        {
            bool neighbourChar = false;
            if (Char.IsDigit(inputData[col][row]))
                {
                //Horizontal neighbours
                if (row != 0)
                {
                    if (!Char.IsDigit(inputData[col][row - 1]) && inputData[col][row - 1] != '.')
                    {
                        neighbourChar = true;
                    }
                    //Diagonal
                    if (col != 0)
                    {
                        if (!Char.IsDigit(inputData[col - 1][row - 1]) && inputData[col - 1][row - 1] != '.')
                        {
                            neighbourChar = true;
                        }
                    }
                    if (col != maxCol)
                    {
                        if (!Char.IsDigit(inputData[col + 1][row - 1]) && inputData[col + 1][row - 1] != '.')
                        {
                            neighbourChar = true;
                        }
                    }
                }
                if (row != maxRow)
                {
                    if (!Char.IsDigit(inputData[col][row + 1]) && inputData[col][row + 1] != '.')
                    {
                        neighbourChar = true;
                    }
                    //Diagonal
                    if (col != 0)
                    {
                        if (!Char.IsDigit(inputData[col - 1][row + 1]) && inputData[col - 1][row + 1] != '.')
                        {
                            neighbourChar = true;
                        }
                    }
                    if (col != maxCol)
                    {
                        if (!Char.IsDigit(inputData[col + 1][row + 1]) && inputData[col + 1][row + 1] != '.')
                        {
                            neighbourChar = true;
                        }
                    }
                }

                //Vertical neighbours
                if (col != 0)
                {
                    if (!Char.IsDigit(inputData[col - 1][row]) && inputData[col - 1][row] != '.')
                    {
                        neighbourChar = true;
                    }
                }
                if (col != maxCol)
                {
                    if (!Char.IsDigit(inputData[col + 1][row]) && inputData[col + 1][row] != '.')
                    {
                        neighbourChar = true;
                    }
                }
            }

            return neighbourChar;
        }

        public List<int> isNeighbourCharCoords(int col, int row)
        {
            List<int> coordinates = new List<int>() {-1, -1};
            if (Char.IsDigit(inputData[col][row]))
            {
                //Horizontal neighbours
                if (row != 0)
                {
                    if (!Char.IsDigit(inputData[col][row - 1]) && inputData[col][row - 1] == '*')
                    {
                        coordinates[0] = col;
                        coordinates[1] = row-1;
                        return coordinates;
                    }
                    //Diagonal
                    if (col != 0)
                    {
                        if (!Char.IsDigit(inputData[col - 1][row - 1]) && inputData[col - 1][row - 1] == '*')
                        {
                            coordinates[0] = col - 1;
                            coordinates[1] = row - 1;
                            return coordinates;
                        }
                    }
                    if (col != maxCol)
                    {
                        if (!Char.IsDigit(inputData[col + 1][row - 1]) && inputData[col + 1][row - 1] == '*')
                        {
                            coordinates[0] = col + 1;
                            coordinates[1] = row - 1;
                            return coordinates;
                        }
                    }
                }
                if (row != maxRow)
                {
                    if (!Char.IsDigit(inputData[col][row + 1]) && inputData[col][row + 1] == '*')
                    {
                        coordinates[0] = col;
                        coordinates[1] = row + 1;
                        return coordinates;
                    }
                    //Diagonal
                    if (col != 0)
                    {
                        if (!Char.IsDigit(inputData[col - 1][row + 1]) && inputData[col - 1][row + 1] == '*')
                        {
                            coordinates[0] = col - 1;
                            coordinates[1] = row + 1;
                            return coordinates;
                        }
                    }
                    if (col != maxCol)
                    {
                        if (!Char.IsDigit(inputData[col + 1][row + 1]) && inputData[col + 1][row + 1] == '*')
                        {
                            coordinates[0] = col + 1;
                            coordinates[1] = row + 1;
                            return coordinates;
                        }
                    }
                }

                //Vertical neighbours
                if (col != 0)
                {
                    if (!Char.IsDigit(inputData[col - 1][row]) && inputData[col - 1][row] == '*')
                    {
                        coordinates[0] = col - 1;
                        coordinates[1] = row;
                        return coordinates;
                    }
                }
                if (col != maxCol)
                {
                    if (!Char.IsDigit(inputData[col + 1][row]) && inputData[col + 1][row] == '*')
                    {
                        coordinates[0] = col + 1;
                        coordinates[1] = row;
                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        public void Task1()
        {
            for (int row = 0; row < inputData.Count; row++)
            {
                StringBuilder tempNum = new StringBuilder("");
                for (int col = 0; col < inputData[row].Count(); col++)
                {
                    if (isNeighbourChar(row, col) && Char.IsDigit(inputData[row][col]))
                    {
                        int tempCol = col;
                        while (tempCol != 0 && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempCol--;
                        }
                        if (tempCol == 0 && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempNum.Append(inputData[row][tempCol]);
                        }
                        tempCol++;
                        while (tempCol <= maxCol && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempNum.Append(inputData[row][tempCol]);
                            tempCol++;
                        }
                        col = tempCol;
                        tempData.Add(tempNum.ToString());
                        //Console.WriteLine(tempNum);
                        tempNum.Length = 0;
                    }
                }

            }
            int total = 0;
            foreach (string str in tempData)
            {
                total += int.Parse(str);
            }
            Console.WriteLine("Day 3 Task 1: " + total);
        }

        public void Task2()
        {
            for (int row = 0; row < inputData.Count; row++)
            {
                StringBuilder tempNum = new StringBuilder("");
                for (int col = 0; col < inputData[row].Count(); col++)
                {
                    List<int> tempCoords = isNeighbourCharCoords(row, col);
                    if (tempCoords != invalidCoords && Char.IsDigit(inputData[row][col]))
                    {
                        int tempCol = col;
                        while (tempCol != 0 && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempCol--;
                        }
                        if (tempCol == 0 && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempNum.Append(inputData[row][tempCol]);
                        }
                        tempCol++;
                        while (tempCol <= maxCol && Char.IsDigit(inputData[row][tempCol]))
                        {
                            tempNum.Append(inputData[row][tempCol]);
                            if (isNeighbourCharCoords(row, tempCol)[0] != -1)
                            {
                                tempCoords[0] = isNeighbourCharCoords(row, tempCol)[0];
                                tempCoords[1] = isNeighbourCharCoords(row, tempCol)[1];
                            }
                            tempCol++;
                        }
                        col = tempCol;
                        tempData.Add(tempNum.ToString());
                        if (tempCoords[0] != -1 && tempCoords[1] != -1)
                        {
                            bool addedToList = false;
                            foreach (numCoords nc in numCoords)
                            {
                                if (nc.charX == tempCoords[0] && nc.charY == tempCoords[1])
                                {
                                    nc.parter = new numCoords(int.Parse(tempNum.ToString()), tempCoords);
                                    addedToList = true;
                                }
                            }
                            if (!addedToList)
                            {
                                numCoords.Add(new numCoords(int.Parse(tempNum.ToString()), tempCoords));
                            }
                        }
                        tempNum.Length = 0;
                    }
                }

            }
            List<int> removeIndexes = new List<int>();
            for (int i = numCoords.Count-1; i > 0; i--)
            {
                if (numCoords[i].parter == null)
                {
                    removeIndexes.Add(i);
                }
            }
            foreach (int index in removeIndexes)
            {
                numCoords.RemoveAt(index);
            }

            int total = 0;
            foreach (numCoords nc in numCoords)
            {
                total += (nc.value * nc.parter.value);
            }

            



            Console.WriteLine("Day 3 Task 2: " + total);
        }
    }


    internal class numCoords
    {
        public int value;
        public int charX;
        public int charY;
        public numCoords? parter = null;

        public numCoords(int val, List<int> xy)
        {
            value = val;
            charX = xy[0];
            charY = xy[1];
        }

        public void displayValues()
        {
            if (parter != null)
            {
                Console.WriteLine(value + " found * at: " + charX + ", " + charY + ", parter value: " + parter.value);
            }
            else
            {
                Console.WriteLine(value + " found * at: " + charX + ", " + charY);
            }
        }
    }
}
