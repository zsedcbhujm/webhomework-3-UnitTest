namespace TexasPoker
{
    public static class PokerJudge
    {
        public static PokerOrder GetPokersOrder(Pokers pokers)
        {
            return PokerOrder.SanPai;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>1 == p1 win, -1 == p2 win, 0 == tie</returns>
        public static int JudgeWinner(Pokers p1, Pokers p2)
        {
            return 0;
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