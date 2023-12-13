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
        List<camelCard> task2Data = new List<camelCard>();
        List<string> stringRanks = new List<string>{ "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        List<string> task2Ranks = new List<string> { "A", "K", "Q", "T", "9", "8", "7", "6", "5", "4", "3", "2", "J" };

        public List<List<camelCard>> rankedCards = new List<List<camelCard>>();
        public List<camelCard> orderedList = new List<camelCard>();

        public List<List<camelCard>> task2Ranked = new List<List<camelCard>>();
        public List<camelCard> task2Ordered = new List<camelCard>();

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent7.txt");
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
                task2Data.Add(new camelCard(data.Split(" ")[0], int.Parse(data.Split(" ")[1]), true));
            }


            SplitCamelCards();
            RankCamelCards();

            int task1Total = 0;
            int rank = rankedCards.SelectMany(list => list).Distinct().Count();
            foreach (List<camelCard> cc in rankedCards)
            {
                foreach (camelCard c in cc)
                {
                    c.rank = rank;
                    rank--;
                    orderedList.Add(c);
                    task1Total += (c.rank * c.bet);
                }
            }

            Console.WriteLine("Day 7 Task 1: " + task1Total);

            SplitCamelCardsTask2();
            RankCamelCardsTask2();


            int task2Total = 0;
            int rank2 = task2Ranked.SelectMany(list => list).Distinct().Count();
            foreach (List<camelCard> cc in task2Ranked)
            {
                foreach (camelCard c in cc)
                {
                    c.rank = rank2;
                    rank2--;
                    task2Ordered.Add(c);
                    task2Total += (c.rank * c.bet);
                }
            }

            Console.WriteLine("Day 7 Task 2: " + task2Total);

            /*foreach (List<camelCard> cc in task2Ranked)
            {
                foreach (camelCard card in cc)
                {
                    //Console.WriteLine(card.card[0].ToString() + card.card[1].ToString() + card.card[2].ToString() + card.card[3].ToString() + card.card[4].ToString());
                    Console.WriteLine(card.cardString + ", Type: " + card.type + ", Sorted: " + card.sortingString + ", Adjusted: " + card.task2String + ", Rank: " + card.rank);
                }
            }*/
        }

        public void SplitCamelCards()
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

        public void RankCamelCards()
        {
            List<List<camelCard>> tempList = new List<List<camelCard>>();
            foreach (List<camelCard> camelList in rankedCards)
            {
                if (camelList.Count > 1)
                {
                    tempList.Add(camelList.OrderBy(card => stringRanks.IndexOf(card.card[0].ToString())).ToList());
                }
                else if (camelList.Count > 0)
                {
                    tempList.Add(camelList);
                }
            }
            for (int i = 0; i < tempList.Count; i++)
            {
                tempList[i] = tempList[i].OrderBy(rc => rc.sortingString).ToList();
            }
            rankedCards = tempList;
        }

        public void SplitCamelCardsTask2()
        {
            for (int i = 0; i < 7; i++)
            {
                task2Ranked.Add(new List<camelCard>());
            }
            foreach (camelCard card in task2Data)
            {
                task2Ranked[7 - card.type].Add(card);
            }
        }

        public void RankCamelCardsTask2()
        {
            List<List<camelCard>> tempList = new List<List<camelCard>>();
            foreach (List<camelCard> camelList in task2Ranked)
            {
                if (camelList.Count > 1)
                {
                    tempList.Add(camelList.OrderBy(card => task2Ranks.IndexOf(card.sortingString)).ToList());
                }
                else if (camelList.Count > 0)
                {
                    tempList.Add(camelList);
                }
            }
            for (int i = 0; i < tempList.Count; i++)
            {
                tempList[i] = tempList[i].OrderBy(rc => rc.sortingString).ToList();
            }
            task2Ranked = tempList;
        }
    }



    internal class camelCard
    {
        public static List<string> cardIndexes =  new List<string>{ "X", "X", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
        public static List<string> task2Indexes = new List<string> { "X", "X", "J", "2", "3", "4", "5", "6", "7", "8", "9", "T", "Q", "K", "A" };
        public static string[] sortVals = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };

                                  //A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2
        public int[] cardCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                                   //A, K, Q, T, 9, 8, 7, 6, 5, 4, 3, 2, J
        public int[] task2Counts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public string cardString = "";
        public string task2String = "";
        public string sortingString = "";
        public List<int> card = new List<int>{0, 0, 0, 0, 0};
        public int bet;
        public int type = 1;
        public int rank = 0;

        public camelCard(string c, int b)
        {
            for (int i = 0; i < c.Length; i++)
            {
                card[i] = cardIndexes.IndexOf(c[i].ToString()) ;
            }
            cardString = c;
            sortingString = (sortVals[14-card[0]] + sortVals[14 - card[1]] + sortVals[14 - card[2]] + sortVals[14 - card[3]] + sortVals[14 - card[4]]);
            bet = b;
            this.CalculateType();
        }

        public camelCard(string c, int b, bool task2)
        {
            for (int i = 0; i < c.Length; i++)
            {
                card[i] = task2Indexes.IndexOf(c[i].ToString());
            }
            cardString = c;
            //sortingString = (sortVals[14 - card[0]] + sortVals[14 - card[1]] + sortVals[14 - card[2]] + sortVals[14 - card[3]] + sortVals[14 - card[4]]);
            bet = b;
            foreach (int i in card)
            {
                task2Counts[14 - i]++;
            }

            StringBuilder tempStr = new StringBuilder("");
            int maxValue = task2Counts.Max();
            int maxIndex = task2Counts.ToList().IndexOf(maxValue);
            for (int i = cardString.Length - 1; i >= 0 ; i--)
            {
                if (cardString[i] != 'J')
                {
                    tempStr.Insert(0, cardString[i].ToString());
                }
                else
                {
                    /*int checkedCards = 1;
                    while (checkedCards < 4 && task2Indexes[14 - maxIndex] == "J")
                    {
                        maxIndex = (from number in task2Counts
                                    orderby number descending
                                    select number).Skip(checkedCards).First();
                        checkedCards++;
                        Console.WriteLine("maxIndex: " + maxIndex);
                    }*/

                    tempStr.Insert(0, task2Indexes[14-maxIndex]);
                }
                
            }
            task2String = tempStr.ToString();
            for (int i = 0; i < task2String.Length; i++)
            {
                card[i] = task2Indexes.IndexOf(cardString[i].ToString());
            }
            sortingString = (sortVals[14 - card[0]] + sortVals[14 - card[1]] + sortVals[14 - card[2]] + sortVals[14 - card[3]] + sortVals[14 - card[4]]);
            this.CalculateTypeTask2();
        }

        public void CalculateType()
        {
            foreach (int c in card)
            {
                cardCounts[14 - c]++;
            }
            
            if (cardCounts.Contains(5))
            {
                type = 7;
            }
            else if (cardCounts.Contains(4))
            {
                type = 6;
            }
            else if (cardCounts.Contains(3) && cardCounts.Contains(2))
            {
                type = 5;
            }
            else if (cardCounts.Contains(3))
            {
                type = 4;
            }
            else if (cardCounts.Contains(2))
            {
                int pairCount = 0;
                foreach (int i in cardCounts)
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

        public void CalculateTypeTask2()
        {
            for (int i = 0; i < task2Counts.Length; i++)
            {
                task2Counts[i] = 0;
            }    
            foreach (int c in card)
            {
                task2Counts[14 - c]++;
            }

            if (task2Counts.Contains(5))
            {
                type = 7;
            }
            else if (task2Counts.Contains(4))
            {
                int count = cardString.Count(f => f == 'J');
                if (count == 0)
                {
                    type = 6;
                }
                else
                {
                    type = 7;
                }
            }
            else if (task2Counts.Contains(3) && task2Counts.Contains(2))
            {
                int count = cardString.Count(f => f == 'J');
                if (count == 2 || count == 3)
                {
                    type = 7;
                }
                else
                {
                    type = 5;
                }
            }
            else if (task2Counts.Contains(3))
            {
                int count = cardString.Count(f => f == 'J');
                if (count == 3 || count == 1)
                {
                    type = 6;
                }
                else
                {
                    type = 4;
                }
            }
            else if (task2Counts.Contains(2))
            {
                int pairCount = 0;
                foreach (int i in task2Counts)
                {
                    if (i == 2)
                    {
                        pairCount++;
                    }
                }
                if (pairCount == 2)
                {
                    int count = cardString.Count(f => f == 'J');
                    if (count == 1)
                    {
                        type = 5;
                    }
                    else if (count == 2)
                    {
                        type = 6;
                    }
                    else
                    {
                        type = 3;
                    }
                }
                else
                {
                    int count = cardString.Count(f => f == 'J');
                    if (count == 1 || count == 2)
                    {
                        type = 4;
                    }
                    else
                    {
                        type = 2;
                    }
                }
            }
            else if(cardString.Contains("J"))
            {
                type = 2;
            }
        }
    }
}
