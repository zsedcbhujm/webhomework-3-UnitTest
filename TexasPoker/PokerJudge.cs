using System;
using System.Collections.Generic;

namespace TexasPoker
{
    public static class PokerJudge
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>1 == p1 win, -1 == p2 win, 0 == tie</returns>
        public static int JudgeWinner(Pokers p1, Pokers p2)
        {
            PokerOrder o1 = GetPokersOrder(p1), o2 = GetPokersOrder(p2);
            if (o1 != o2)
                return o1 > o2 ? 1 : -1;

            var result = 0;
            switch (o1)
            {
                case PokerOrder.TongHuaShun:
                    if (p1[4].CompareTo(p2[4]) == 1)
                        result = 1;
                    else if (p1[4].CompareTo(p2[4]) == -1)
                        result = -1; 
                    break;
                case PokerOrder.TongHua:
                    break;
            }

            return result;
        }

        public static PokerOrder GetPokersOrder(Pokers pokers)
        {
            if (IsTongHuaShun(pokers))
                return PokerOrder.TongHuaShun;
            if (IsTongHua(pokers))
                return PokerOrder.TongHua;
            if (IsShunZi(pokers))
                return PokerOrder.ShunZi;
            if (IsSanTiao(pokers))
                return PokerOrder.SanTiao;
            if (IsLiangDui(pokers))
                return PokerOrder.LiangDui;
            if (IsDuiZi(pokers))
                return PokerOrder.DuiZi;

            return PokerOrder.SanPai;
        }

        private static bool IsTongHuaShun(Pokers pokers)
        {
            char color;
            color = pokers[0].Color;
            for (int i = 1; i < 5; i++)
            {
                if (pokers[i].Color != color)
                    return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (Poker.PokerNums.IndexOf(pokers[i].Number) + 1 != Poker.PokerNums.IndexOf(pokers[i + 1].Number))
                    return false;
            }

            return true;
        }

        private static bool IsTongHua(Pokers pokers)
        {
            char color;
            color = pokers[0].Color;
            for (int i = 1; i < 5; i++)
            {
                if (pokers[i].Color != color)
                    return false;
            }

            return true;
        }

        private static bool IsShunZi(Pokers pokers)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Poker.PokerNums.IndexOf(pokers[i].Number) + 1 != Poker.PokerNums.IndexOf(pokers[i + 1].Number))
                    return false;
            }

            return true;
        }

        private static bool IsSanTiao(Pokers pokers)
        {
            return CheckSanTiaoHelper(pokers) != "";
        }

        private static bool IsLiangDui(Pokers pokers)
        {
            return CheckDuiZiHelper(pokers).Length == 2;
        }

        private static bool IsDuiZi(Pokers pokers)
        {
            return CheckDuiZiHelper(pokers).Length == 1;
        }

        private static string CheckSanTiaoHelper(Pokers pokers)
        {
            var result = "";
            Dictionary<char, int> pokerCount = new Dictionary<char, int>();
            
            for (int i = 0; i < 5; i++)
                if (!pokerCount.ContainsKey(pokers[i].Number))
                    pokerCount.Add(pokers[i].Number, 1);
                else
                    pokerCount[pokers[i].Number]++;

            foreach (var i in pokerCount)
                if (i.Value >= 3)
                    result += i.Key;

            return result;
        }

        private static string CheckDuiZiHelper(Pokers pokers)
        {
            var result = "";
            Dictionary<char, int> pokerCount = new Dictionary<char, int>();
            
            for (int i = 0; i < 5; i++)
                if (!pokerCount.ContainsKey(pokers[i].Number))
                    pokerCount.Add(pokers[i].Number, 1);
                else
                    pokerCount[pokers[i].Number]++;

            foreach (var i in pokerCount)
            {
                if (i.Value == 2)
                {
                    if (result != "" && Poker.PokerNums.IndexOf(result[0]) > i.Key)
                        result += i.Key;
                    else
                        result = i.Key + result;
                }
            }

            return result;
        }
    }

    public enum PokerOrder
    {
        SanPai,
        DuiZi,
        LiangDui,
        SanTiao,
        ShunZi,
        TongHua,
        TongHuaShun
    }
}