using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Schema;

namespace TexasPoker
{
    public class Pokers
    {
        private List<Poker> _pokers = new List<Poker>();
        
        public Pokers(string[] pokers)
        {
            if (pokers.Length != 5)
                throw new Exception("Poker count is invalid");

            List<string> checkRepeat = new List<string>();
            
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    var exp = pokers[i];
                    if (checkRepeat.Contains(exp)) 
                        throw new Exception("Poker has repeat");
                    _pokers.Add(new Poker(exp.ToUpper().Trim()));
                    checkRepeat.Add(exp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Poker create failed : {e.Message}");
                throw;
            }

            _pokers.Sort();
        }
        
        public Poker this[int index] => _pokers[index];
    }

    public class Poker : IComparable<Poker>
    {
        public static readonly string PokerNums = "23456789TJQKA";
        public static readonly string PokerColors = "DSHC";
        
        public Poker(string poker)
        {
            if (poker.Length != 2)
                throw new Exception("Poker expression is invalid");
            
            if (!PokerNums.Contains(poker[0]))
                throw new Exception("Poker expression is invalid");
            Number = poker[0];

            if (!PokerColors.Contains(poker[1]))
                throw new Exception("Poker expression is invalid");
            Color = poker[1];
        }

        public char Number;
        public char Color;

        public int CompareTo(Poker other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            if (PokerNums.IndexOf(this.Number) > PokerNums.IndexOf(other.Number)) return 1;
            if (PokerNums.IndexOf(this.Number) == PokerNums.IndexOf(other.Number)) return 0;
            return -1;
        }

        public static bool operator >(Poker self, Poker other) => self.CompareTo(other) == 1;

        public static bool operator <(Poker self, Poker other) => self.CompareTo(other) == -1;

        public override string ToString()
        {
            return Number + "" + Color;
        }
    }
}