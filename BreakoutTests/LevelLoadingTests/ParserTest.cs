using NUnit.Framework;
using DIKUArcade.Entities;
using Breakout.Blocks;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using System.IO;
using DIKUArcade.GUI;
using System.Collections.Generic;
using Breakout.Levels;

namespace BreakoutTests {
    public class ParserTest {

        private LevelData leveldata;

        [SetUp]
        public void Setup() {
            leveldata = new LevelData("level1");
        }

        //[Test]
        public void TestParseRows() {
            List<string> expected = new List<string>();
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("-qqqqqqqqqq-");
            expected.Add("-qqqqqqqqqq-");
            expected.Add("-111----111-");
            expected.Add("-111-##-111-");
            expected.Add("-111-22-111-");
            expected.Add("-111-##-111-");
            expected.Add("-111----111-");
            expected.Add("-##########-");
            expected.Add("-##########-");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            expected.Add("------------");
            Assert.AreEqual(expected, leveldata.RowsList);
        }

        //[Test]
        public void TestParseMeta() {
            var expected = new Dictionary<string, string>();
            expected.Add("name", "LEVEL 1");
            expected.Add("time", "300");
            expected.Add("hardened", "#");
            expected.Add("powerup", "2");
            Assert.AreEqual(expected, leveldata.MetaList);

        }

        //[Test]
        public void TestParseImages() {
            var expected = new Dictionary<char, string>();
            expected.Add('#', "teal-block.png");
            expected.Add('1', "blue-block.png");
            expected.Add('2', "green-block.png");
            expected.Add('q', "darkgreen-block.png");
            Assert.AreEqual(expected, leveldata.LegendList);
        }
    }
}