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
        }
    }

    internal class ad2Game
    {
        public int gameID;
        public int blue;
        public int red;
        public int green;

        public void setDetails(string input)
        {
            gameID = int.Parse(input.Split(":")[0].Split(" ")[1]);
            List<string> gameInfo = Advent1.ArrayToList(input.Split(":")[1].Split(";"));
            List<List<string>> splitInfo = new List<List<string>>();
            foreach (string game in gameInfo)
            {
                splitInfo.Add(Advent1.ArrayToList(game.Split(",")));
            }

            Console.WriteLine(splitInfo[0][0]);
            //Keep splitting here
        }
    }
}
