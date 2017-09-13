using System;
using System.Collections.Generic;

namespace ADFGX_API_Client_Module_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> CharacterMap = new List<int>();
            for (int i = 1; i < 26; i++)
            {
                CharacterMap.Add(i);
            }

            //How many keysquares you wanna generate
            int Iterations = 10;

            //Set up our Keysquares array
            string[] KeySquares = new string[Iterations];

            //
            for (int i = 1; i < Iterations; i++)
            {
                int LastCell = (CharacterMap.Count - 1);
                CharacterMap = new List<int>(IncrementPosition(CharacterMap, LastCell));
                KeySquares[i - 1] = TranslateCharMap(CharacterMap);
            }
        }

        static List<int> IncrementPosition(List<int> CurrentMapping, int Position)
        {
            List<int> TempMapping = new List<int>(CurrentMapping);
            
            TempMapping.RemoveRange(Position, (TempMapping.Count - Position));
            int NewChar = CurrentMapping[Position] + 1;
            while (TempMapping.Contains(NewChar) || NewChar > 25)
            {
                NewChar++;
                if (NewChar > 25)
                {
                    TempMapping = new List<int>(IncrementPosition(TempMapping, Position - 1));
                    NewChar = 1;
                }
            }
            TempMapping.Add(NewChar);
            return TempMapping;
        }

        static string TranslateCharMap(List<int> CharMap)
        {
            string Output = string.Empty;
            foreach (int i in CharMap)
            {
                int Offset = 0;
                if (i > 9) Offset = 1;
                Output = string.Format("{0}{1}", Output, Char.ConvertFromUtf32(i + Offset + 64));
            }
            return Output;
        }
    }
}
