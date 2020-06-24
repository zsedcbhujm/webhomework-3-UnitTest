using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace TexasPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp;
            Pokers black, white;
            while ((temp = Console.ReadLine()) != "")
            {
                var s1 = temp.Substring(temp.IndexOf("Black:") + 6, 15);
                List<string> l1 = new List<string>(), l2 = new List<string>();
                Console.WriteLine(s1);
                foreach (var s in s1.Split(' '))
                {
                    if (s.Length == 2)
                        l1.Add(s);
                }
                black = new Pokers(l1.ToArray());
                
                var s2 = temp.Substring(temp.IndexOf("White:") + 6, 15);
                Console.WriteLine(s2);
                foreach (var s in s2.Split(' '))
                {
                    if (s.Length == 2)
                        l2.Add(s);
                }
                white = new Pokers(l2.ToArray());
                
                PrintWinner(PokerJudge.JudgeWinner(black, white));
            }
        }

        private static void PrintWinner(int winner)
        {
            if (winner == 1)
                Console.WriteLine("Black wins");
            else if (winner == -1)
                Console.WriteLine("White wins");
            else
                Console.WriteLine("Tie");
        }
    }
}
