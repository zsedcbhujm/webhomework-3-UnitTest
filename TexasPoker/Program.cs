using System;
using System.Collections.Generic;

namespace TexasPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokers pokers = new Pokers(new []{"2H", "2D", "2S", "5C", "KD"});
            Console.WriteLine(PokerJudge.GetPokersOrder(pokers));
        }
    }
}
