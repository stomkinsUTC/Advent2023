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

            foreach (ad2Game game in gameList)
            {
                //NEED TO CHECK THE NUMBERS INSTEAD OF PRINTING THIS HERE
                Console.WriteLine(game.green);
            }
        }
    }

    internal class ad2Game
    {
        public int gameID;
        public int blue = 0;
        public int red = 0;
        public int green = 0;

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
                    }
                    else if (tempColour == "red")
                    {
                        red += tempCount;
                    }
                    else
                    {
                        green += tempCount;
                    }
                }
            }
        }
    }
}
