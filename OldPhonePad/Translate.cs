using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad
{
    internal class Translate
    {
        private string data;
        private string[][] lookUpTable = new string[][] {
            new string[]{" "},
            new string[]{ "&", "'", "(" },
            new string[]{ "A", "B", "C" },
            new string[]{ "D", "E", "F" },
            new string[]{ "G", "H", "I" },
            new string[]{ "J", "K", "L" },
            new string[]{ "M", "N", "O" },
            new string[]{ "P", "Q", "R", "S" },
            new string[]{ "T", "U", "V" },
            new string[]{ "W", "X", "Y", "Z" },
            };

        public string Data
        { get; private set; }

        public Translate(string data)
        {
            Data = data;
        }

        public string ConvertToAlpha()
        {
            // Handle empty input
            if(Data[0] == '#')
            {
                return "";
            }

            // Handle none "#" ending input
            if (Data[Data.Length-1] != '#')
            {
                Data += "#";
            }

            char previous = Data[0];
            int count = 0;
            string finalStr = "";
            int pointer = 1;

            while (pointer < Data.Length)
            {
                if (Data[pointer] == '*' && previous == '*')
                {
                    finalStr = finalStr[:-1:];
                }
                else if (Data[pointer] == '*')
                {
                    previous = Data[pointer + 1];
                    count = 0;
                    pointer += 1;
                }
                else if (Data[pointer] == previous)
                {
                    count += 1;
                    previous = Data[pointer];
                }
                else
                {
                    if (previous != ' ' && previous != '*')
                    {
                        finalStr += lookUpTable[int(previous)][count];
                    }
                    count = 0;
                    previous = Data[pointer];
                }
                pointer += 1;

            }
            return finalStr;
        }
    }
}
