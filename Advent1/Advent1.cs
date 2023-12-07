using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent1
    {

        public void main()
        {
            List<string> inputList = new List<string>();
            List<string> valueList = new List<string>();
            List<string> valueList2 = new List<string>();
            List<string> formattedList = new List<string>();

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

            List<string> ArrayToList(string[] strList)
            {
                List<string> list = new List<string>();
                foreach (string str in strList)
                {
                    list.Add(str);
                }
                return list;
            }

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
                Console.WriteLine("Task 1: " + total);
            }

            void Task2()
            {
                foreach (string input in inputList)
                {
                    string tempstr = input.Replace("one", "1")
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
                    //Console.WriteLine(value+ "     Total: "+ total);
                }
                Console.WriteLine("Task 2: " + total);
            }

            void Task2Alt()
            {
                int globalCount = 0;
                foreach (var line in inputList)
                {
                    var ints = new List<int>();

                    for (var i = 0; i < line.Length; i++)
                    {
                        var curr = line[i..];
                        if (curr.StartsWith("one") || curr.StartsWith("1"))
                            ints.Add(1);
                        else if (curr.StartsWith("two") || curr.StartsWith("2"))
                            ints.Add(2);
                        else if (curr.StartsWith("three") || curr.StartsWith("3"))
                            ints.Add(3);
                        else if (curr.StartsWith("four") || curr.StartsWith("4"))
                            ints.Add(4);
                        else if (curr.StartsWith("five") || curr.StartsWith("5"))
                            ints.Add(5);
                        else if (curr.StartsWith("six") || curr.StartsWith("6"))
                            ints.Add(6);
                        else if (curr.StartsWith("seven") || curr.StartsWith("7"))
                            ints.Add(7);
                        else if (curr.StartsWith("eight") || curr.StartsWith("8"))
                            ints.Add(8);
                        else if (curr.StartsWith("nine") || curr.StartsWith("9"))
                            ints.Add(9);
                    }

                    if (ints.Count == 1)
                        globalCount += ints[0] * 10 + ints[0];
                    else
                        globalCount += ints[0] * 10 + ints.Last();
                }
                Console.WriteLine("Task 2: " + globalCount);
            }

            Task1();
            //Task2();
            Task2Alt();
            Console.ReadLine();
        }
    }
}
