using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023
{
    internal class Advent7
    {
        List<string> inputData = new List<string>();
        List <camelCard> cardData = new List<camelCard> ();
        Char[] cardRanking = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'};
        List<string> stringRanks = new List<string>{ "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };

        public List<List<camelCard>> rankedCards = new List<List<camelCard>>();

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent7TEST.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            foreach (string data in inputData)
            {
                cardData.Add(new camelCard(data.Split(" ")[0], int.Parse(data.Split(" ")[1])));
            }
            //cardData = cardData.OrderBy(cc => cc.type).ToList();
            splitCamelCards();
            rankCamelCards();

            foreach (List<camelCard> cc in rankedCards)
            {
                foreach (camelCard c in cc)
                {
                    Console.WriteLine(c.card + ", Type: " + c.type);
                }
            }

        }

        public void splitCamelCards()
        {
            for (int i = 0; i < 7; i++)
            {
                rankedCards.Add(new List<camelCard>());
            }
            foreach (camelCard card in cardData)
            {
                rankedCards[7 - card.type].Add(card);
            }    
        }

        public void rankCamelCards()
        {
            List<List<camelCard>> tempList = new List<List<camelCard>>();
            foreach (List<camelCard> camelList in rankedCards)
            {
                if (camelList.Count > 1)
                {
                    tempList.Add(camelList.OrderBy(card => stringRanks.IndexOf(card.card)).ToList());
                    //THIS DOESN'T WORK
                }
                else if (camelList.Count > 0)
                {
                    tempList.Add(camelList);
                }
            }
            rankedCards = tempList;
        }
    }



    internal class camelCard
    {
        public string card;
        public int bet;
        public int type = 1;
        public int rank = 0;

        public camelCard(string c, int b)
        {
            card = c;
            bet = b;
            this.CalculateType();
        }

        public void CalculateType()
        {
                         //A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2
            int[] cards = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            foreach (char c in card)
            {
                if (Char.IsDigit(c))
                {
                    cards[14 - int.Parse(c.ToString())]++;
                }
                else if (c == 'A')
                {
                    cards[0]++;
                }
                else if (c == 'K')
                {
                    cards[1]++;
                }
                else if (c == 'Q')
                {
                    cards[2]++;
                }
                else if (c == 'J')
                {
                    cards[3]++;
                }
                else
                {
                    cards[4]++;
                }
            }
            if (cards.Contains(5))
            {
                type = 7;
            }
            else if (cards.Contains(4))
            {
                type = 6;
            }
            else if (cards.Contains(3) && cards.Contains(2))
            {
                type = 5;
            }
            else if (cards.Contains(3))
            {
                type = 4;
            }
            else if (cards.Contains(2))
            {
                int pairCount = 0;
                foreach (int i in cards)
                {
                    if (i == 2)
                    {
                        pairCount++;
                    }
                }
                if (pairCount == 2)
                {
                    type = 3;
                }
                else
                {
                    type = 2;
                }
            }
        }
    }

}
