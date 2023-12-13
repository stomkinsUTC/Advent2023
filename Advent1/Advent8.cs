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

        int stepsTaken = 0;
        bool zzzFound = false;

        int task2StepsTaken = 0;
        bool task2ZZZFound = false;
        List<int> task2MultSteps = new List<int>();

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

            //Task1();
            //Console.WriteLine("Day 8 Task 1: " + stepsTaken);

            Task2();
            task2MultSteps.RemoveAll(item => item == 0);
            long task2Total = lcm_of_array_elements(task2MultSteps.ToArray());
            Console.WriteLine("Day 8 Task 2: " + task2Total);
        }

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate 
                // we found all factors and terminate while loop.
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }

        public void Task1()
        {
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

        }

        public void Task2()
        {
            List<direction> task2Directions = new List<direction>();
            foreach (direction dir in directionData)
            {
                if (dir.current[2] == 'A')
                {
                    task2Directions.Add(dir);
                }
            }

            foreach (direction dir in task2Directions)
            {
                direction nextPos = dir;
                while (!task2ZZZFound)
                {
                    foreach (char lrDir in lrData)
                    {
                        if (nextPos.current[2] != 'Z')
                        {
                            if (lrDir == 'L')
                            {
                                nextPos = directionData.Find(i => i.current == nextPos.left);
                            }
                            else
                            {
                                nextPos = directionData.Find(i => i.current == nextPos.right);
                            }
                            task2StepsTaken++;
                        }
                        else
                        {
                            task2ZZZFound = true;
                            task2MultSteps.Add(task2StepsTaken);
                            task2StepsTaken = 0;
                            continue;
                        }
                    }
                }
                task2ZZZFound = false;
            }

            
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
