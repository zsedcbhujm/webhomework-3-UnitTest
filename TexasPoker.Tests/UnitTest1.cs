using System;
using System.Collections.Generic;
using System.Data;
using Xunit;
using TexasPoker;

namespace TexasPoker.Tests
{
    public class UnitTest1
    {
        /// <summary>
        /// 散牌测试
        /// </summary>
        /// <param name="pokers"></param>
        [Theory]
        [MemberData(nameof(DataOfSanPai))]
        public void CanJudgeSanPai(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.SanPai, PokerJudge.GetPokersOrder(pokers));
        }
        
        public static IEnumerable<object[]> DataOfSanPai()
        {
            yield return new object[] {new Pokers(new []{"2H", "3D", "5S", "9C", "KD"}) };
            yield return new object[] {new Pokers(new []{"2H", "5D", "9S", "JC", "KD"}) };
        }

        /// <summary>
        /// 对子测试
        /// </summary>
        /// <param name="pokers"></param>
        [Theory]
        [MemberData(nameof(DataOfDuiZi))]
        public void CanJudgeDuiZi(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.DuiZi, PokerJudge.GetPokersOrder(pokers));
        }
        
        public static IEnumerable<object[]> DataOfDuiZi()
        {
            yield return new object[] {new Pokers(new []{"2H", "5D", "5S", "9C", "KD"}) };
            yield return new object[] {new Pokers(new []{"2H", "9D", "9S", "JC", "KD"}) };
        }

        /// <summary>
        /// 两对测试
        /// </summary>
        [Theory]
        [MemberData(nameof(DataOfLiangDui))]
        public void CanJudgeLiangDui(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.LiangDui, PokerJudge.GetPokersOrder(pokers));
        }
        
        public static IEnumerable<object[]> DataOfLiangDui()
        {
            yield return new object[] {new Pokers(new []{"2H", "5D", "5S", "2C", "KD"}) };
            yield return new object[] {new Pokers(new []{"2H", "9D", "9S", "kC", "KD"}) };
        }

        /// <summary>
        /// 三条测试
        /// </summary>
        /// <param name="pokers"></param>
        [Theory]
        [MemberData(nameof(DataOfSanTiao))]
        public void CanJudgeSanTiao(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.SanTiao, PokerJudge.GetPokersOrder(pokers));
        }

        public static IEnumerable<object[]> DataOfSanTiao()
        {
            yield return new object[] {new Pokers(new []{"2H", "2D", "2S", "5C", "KD"}) };
            yield return new object[] {new Pokers(new []{"2H", "2D", "2S", "2C", "KD"}) };
        }
        
        /// <summary>
        /// 同花测试
        /// </summary>
        /// <param name="pokers"></param>
        [Theory]
        [MemberData(nameof(DataOfTongHua))]
        public void CanJudgeTongHua(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.TongHua, PokerJudge.GetPokersOrder(pokers));
        }

        public static IEnumerable<object[]> DataOfTongHua()
        {
            yield return new object[] {new Pokers(new []{"2H", "4H", "9H", "5H", "KH"}) };
            yield return new object[] {new Pokers(new []{"2D", "3D", "8D", "5D", "KD"}) };
        }
        
        /// <summary>
        /// 同花顺测试
        /// </summary>
        /// <param name="pokers"></param>
        [Theory]
        [MemberData(nameof(DataOfTongHuaShun))]
        public void CanJudgeTongHuaShun(Pokers @pokers)
        {
            Assert.Equal(PokerOrder.TongHuaShun, PokerJudge.GetPokersOrder(pokers));
        }

        public static IEnumerable<object[]> DataOfTongHuaShun()
        {
            yield return new object[] {new Pokers(new []{"2H", "3H", "4H", "5H", "6H"}) };
            yield return new object[] {new Pokers(new []{"5D", "6D", "7D", "8D", "9D"}) };
        }
    }
}
