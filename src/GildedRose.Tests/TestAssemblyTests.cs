using System;
using System.IO;
using NUnit.Framework;
using GildedRose.Console;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        private Program _prog;

        [SetUp]
        public void SetUp()
        {
            _prog = Program.GetApp();
        }

        [Test]
        public void GoldenMasterTest()
        {
            //var writer = new StreamWriter("master.txt");
            //System.Console.SetOut(writer);

            var reader = new StreamReader("master.txt");

            for (var i = 0; i < 200; i++)
            {
                _prog.UpdateQuality();
                var masterLine = reader.ReadLine();
                Assert.That(_prog.Status(), Is.EqualTo(masterLine));
                //System.Console.WriteLine(_prog.Status());
            }

            //writer.Close();
        }
    }
}