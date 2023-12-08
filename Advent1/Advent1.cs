using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    public class Advent1
    {


        public static List<string> ArrayToList(string[] strList)
        {
            List<string> list = new List<string>();
            foreach (string str in strList)
            {
                list.Add(str);
            }
            return list;
        }

        public void main()
        {
            List<string> inputList = new List<string>();
            List<string> valueList = new List<string>();
            List<string> valueList2 = new List<string>();
            List<string> formattedList = new List<string>();

            List<int> ints = new List<int>();

            List<int> totalsA = new List<int>();
            List<int> totalsB = new List<int>();

            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent1.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputList.Add(line);
                valueList.Add("");
                valueList2.Add("");
                line = sr.ReadLine();
            }
            sr.Close();

            List<string> SplitList(string str)
            {
                List<char> chars = new List<char>();
                int currentPos = 0;
                List<string> strings = new List<string>();
                foreach (char chr in str)
                {
                    if (Char.IsDigit(chr))
                    {
                        var tempStr = new string(chars.ToArray());
                        strings.Add(tempStr);
                        strings.Add(chr.ToString());
                        chars = new List<char>();
                    }
                    else
                    {
                        chars.Add(chr);
                    }
                }
                return strings;
            }

            int GetFirstValue(List<string> values)
            {
                foreach (string str in values)
                {
                    if (str.Length == 1 && Char.IsDigit(str[0]))
                    {
                        return str[0];
                    }
                }
                return -1;
            }

            void Task1()
            {
                //Getting the first int from each string (Task 1)
                for (int i = 0; i < inputList.Count; i++)
                {
                    foreach (char value in inputList[i])
                    {
                        if (Char.IsDigit(value))
                        {
                            valueList[i] += value;
                            break;
                        }
                    }
                }

                //Getting the last int from each string (Task 1)
                for (int i = 0; i < inputList.Count; i++)
                {
                    for (int j = inputList[i].Length - 1; j >= 0; j--)
                    {
                        if (Char.IsDigit(inputList[i][j]))
                        {
                            valueList[i] += inputList[i][j];
                            break;
                        }
                    }
                }

                //Displaying the total (Task 1)
                int total = 0;
                foreach (string value in valueList)
                {
                    total += int.Parse(value);
                }
                Console.WriteLine("Day 1 Task 1: " + total);
            }

            void Task2()
            {
                foreach (string input in inputList)
                {
                    string tempstr = input
                        .Replace("sevenine", "sevennine")
                        .Replace("eightwo", "eighttwo")
                        .Replace("oneight", "oneeight")
                        .Replace("twone", "twoone")
                        .Replace("one", "1")
                        .Replace("two", "2")
                        .Replace("three", "3")
                        .Replace("four", "4")
                        .Replace("five", "5")
                        .Replace("six", "6")
                        .Replace("seven", "7")
                        .Replace("eight", "8")
                        .Replace("nine", "9");
                    formattedList.Add(tempstr);
                }

                //Getting the first int from each string (Task 2)
                for (int i = 0; i < formattedList.Count; i++)
                {
                    foreach (char value in formattedList[i])
                    {
                        if (Char.IsDigit(value))
                        {
                            valueList2[i] += value;
                            break;
                        }
                    }
                }

                //Getting the last int from each string (Task 2)
                for (int i = 0; i < formattedList.Count; i++)
                {
                    for (int j = formattedList[i].Length - 1; j >= 0; j--)
                    {
                        if (Char.IsDigit(formattedList[i][j]))
                        {
                            valueList2[i] += formattedList[i][j];
                            break;
                        }
                    }
                }

                //Displaying the total (Task 2)
                int total = 0;
                foreach (string value in valueList2)
                {
                    total += int.Parse(value);
                    totalsA.Add(total);
                    //Console.WriteLine(value+ "     Total: "+ total);
                }
                Console.WriteLine("Day 1 Task 2: " + total);
            }

            Task1();
            Task2();

            Console.ReadLine();
        }
    }
}
