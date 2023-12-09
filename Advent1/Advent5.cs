using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Advent2023
{
    internal class Advent5
    {
        List<string> inputData = new List<string>();
        List<long> seeds = new List<long>();
        List<long> rangeSeeds = new List<long>();
        List<long> locations = new List<long>();
        List<long> rangeLocations = new List<long>();

        List<Conversion> seedToSoil = new List<Conversion>();
        List<Conversion> soilToFertiliser = new List<Conversion>();
        List<Conversion> fertiliserToWater = new List<Conversion>();
        List<Conversion> waterToLight = new List<Conversion>();
        List<Conversion> lightToTemperature = new List<Conversion>();
        List<Conversion> temperatureToHumidity = new List<Conversion>();
        List<Conversion> humidityToLocation = new List<Conversion>();

        public bool firstRangeSet = false;
        public long minRangeLocation = 0;

        public void main()
        {
            //Getting the data from the file
            String line;
            StreamReader sr = new StreamReader("..\\advent5.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                inputData.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            inputData.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            SetSeeds();
            SetConversions();

            foreach (long seed in seeds)
            {
                //Console.WriteLine(seed + " converts to: " + checkSeedLocation(seed));
                locations.Add(checkSeedLocation(seed));
            }
            Console.WriteLine("Day 5 Task 1: " + locations.Min());

            foreach (long seed in rangeSeeds)
            {
                rangeLocations.Add(checkSeedLocation(seed));
            }


            
            
            SetSeedRange();

            Console.WriteLine("Day 5 Task 2: " + minRangeLocation);
        }

        public void SetSeeds()
        {

            string seedVals = inputData[0].Split(":")[1];
            foreach (string str in seedVals.Split(" "))
            {
                if (str.Length > 0)
                {
                    seeds.Add(long.Parse(str));
                }
            }
        }

        public void SetSeedRange()
        {
            string[] seedVals = inputData[0].Split(":")[1].Split(" ");
            seedVals = seedVals.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < seedVals.Length; i+=2)
            {
                long value = long.Parse(seedVals[i]);
                long range = long.Parse(seedVals[i + 1]); ;
                if (seedVals[i].Length > 0)
                {
                    //THIS IS THE RAM KILLER, NEED TO FIND A WAY TO OPTIMISE THIS.
                    for (long j = value; j < value + range; j++)
                    {
                        if (!firstRangeSet)
                        {
                            minRangeLocation = checkSeedLocation(j);
                        }
                        else
                        {
                            if (checkSeedLocation(j) < minRangeLocation)
                            {
                                minRangeLocation = checkSeedLocation(j);
                            }
                        }
                        rangeSeeds.Add(j);
                    }
                }

            }
        }

        public void SetConversions()
        {
            List<List<Conversion>> conversions = new List<List<Conversion>>() { seedToSoil, soilToFertiliser, fertiliserToWater, waterToLight, lightToTemperature, temperatureToHumidity, humidityToLocation };
            int conversionIndex = 0;
            for (int i = 2; i < inputData.Count; i++)
            {
                if (Char.IsDigit(inputData[i][0]))
                {
                    conversions[conversionIndex].Add(new Conversion(inputData[i]));
                }
                else
                {
                    conversionIndex++;
                }
            }
        }

        public long checkSeedLocation(long seed)
        {
            long location = seed;
            foreach (Conversion conv in seedToSoil)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Soil: " + location);
                    break;
                }
            }
            foreach (Conversion conv in soilToFertiliser)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Fert: " + location);
                    break;
                }
            }
            foreach (Conversion conv in fertiliserToWater)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Wate: " + location);
                    break;
                }
            }
            foreach (Conversion conv in waterToLight)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Ligh: " + location);
                    break;
                }
            }
            foreach (Conversion conv in lightToTemperature)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Temp: " + location);
                    break;
                }
            }
            foreach (Conversion conv in temperatureToHumidity)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    //Console.WriteLine("Humi: " + location);
                    break;
                }
            }
            foreach (Conversion conv in humidityToLocation)
            {
                if (location >= conv.originStart && location <= conv.originEnd)
                {
                    location += conv.difference;
                    break;
                }
            }
            return location;
        }
    }

    internal class Conversion
    {
        public long originStart;
        public long originEnd;
        public long destinationStart;
        public long destinationEnd;
        public long difference;

        public Conversion(string valToSplit)
        {
            string[] split = valToSplit.Split(" ");
            destinationStart = long.Parse(split[0]);
            destinationEnd = long.Parse(split[0]) + long.Parse(split[2]) - 1;
            originStart = long.Parse(split[1]);
            originEnd = long.Parse(split[1]) + long.Parse(split[2]) - 1;
            difference = destinationStart - originStart;
        }
    }
}
