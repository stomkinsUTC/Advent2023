using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent2
    {
        List<string> inputData = new List<string>();
        List<ad2Game> gameList = new List<ad2Game>();
        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent2.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                gameList.Add(new ad2Game());
                line = sr.ReadLine();
            }
            sr.Close();

            for (int i = 0; i < inputData.Count; i++)
            {
                gameList[i].setDetails(inputData[i]);
            }

            int task1Total = 0;
            int task2Total = 0;
            foreach (ad2Game game in gameList)
            {
                //game.displayDetails();
                if (game.maxRed <= 12 && game.maxGreen <= 13 && game.maxBlue <= 14)
                {
                    //Console.WriteLine(game.gameID + ": possible");
                    task1Total += game.gameID;
                }
                task2Total += (game.maxRed * game.maxBlue * game.maxGreen);
            }
            Console.WriteLine("Day 2 Task 1: " + task1Total);
            Console.WriteLine("Day 2 Task 2: " + task2Total);
        }
    }

    internal class ad2Game
    {
        public int gameID;
        public int blue = 0;
        public int red = 0;
        public int green = 0;
        public int maxBlue = 0;
        public int maxRed = 0;
        public int maxGreen = 0;

        public void setDetails(string input)
        {
            gameID = int.Parse(input.Split(":")[0].Split(" ")[1]);
            List<string> gameInfo = Advent1.ArrayToList(input.Split(":")[1].Split(";"));
            List<List<string>> splitInfo = new List<List<string>>();
            foreach (string game in gameInfo)
            {
                splitInfo.Add(Advent1.ArrayToList(game.Split(",")));
            }

            foreach (List<string> colourData in splitInfo)
            {
                foreach (string colour in colourData)
                {
                    int tempCount = int.Parse(colour.Split()[1]);
                    string tempColour = colour.Split(" ")[2];
                    if (tempColour == "blue")
                    {
                        blue += tempCount;
                        if (tempCount > maxBlue)
                        {
                            maxBlue = tempCount;
                        }
                    }
                    else if (tempColour == "red")
                    {
                        red += tempCount;
                        if (tempCount > maxRed)
                        {
                            maxRed = tempCount;
                        }
                    }
                    else
                    {
                        green += tempCount;
                        if (tempCount > maxGreen)
                        {
                            maxGreen = tempCount;
                        }

                    }
                }
            }
        }

        public void displayDetails()
        {
            Console.WriteLine("Game: " + gameID + "     Blue: " + maxBlue + "     Red: " + maxRed + "     Green: " + maxGreen);
        }
    }
}
