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
            var reader = new StreamReader("master.txt");

            for (var i = 0; i < 200; i++)
            {
                _prog.UpdateQuality();
                var masterLine = reader.ReadLine();
                Assert.That(_prog.Status(), Is.EqualTo(masterLine));
            }
        }

        [TestCase("This is a standard item", 10, 9)]
        [TestCase("This is a standard item", 0, 8)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 16, 11)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 11)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 12)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 13)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 0)]
        [TestCase("Aged Brie", 10, 11)]
        [TestCase("Aged Brie", 5, 11)]
        [TestCase("Aged Brie", 0, 12)]
        [TestCase("Aged Brie", -1, 12)]
        public void TestItemQualityOnUpdate(String itemName, int startingSellIn, int expectedQualityAfterUpdate)
        {
            var item = new Item
            {
                Name = itemName,
                Quality = 10,
                SellIn = startingSellIn
            };

            item.Update();

            Assert.That(item.Quality, Is.EqualTo(expectedQualityAfterUpdate));
        }

        //[TestCase(10, 9)]
        //[TestCase(0, 8)]
        //public void StandardItemDecreasesInQuality(int startingSellIn, int expectedValueAfterUpdate)
        //{
        //    var item = new Item
        //    {
        //        Name = "This is a standard item",
        //        Quality = 10,
        //        SellIn = startingSellIn
        //    };

        //    item.Update();

        //    Assert.That(item.Quality, Is.EqualTo(expectedValueAfterUpdate));
        //}

        [TestCase(1000, -50)]
        [TestCase(-80, 0)]
        [TestCase(1, 1)]
        public void LegendaryItemDoesNotChange(int quality, int sellIn)
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality,
                SellIn = sellIn
            };

            item.Update();

            Assert.That(item.Quality, Is.EqualTo(quality));
            Assert.That(item.SellIn, Is.EqualTo(sellIn));
        }

        //[TestCase(16, 21)]
        //[TestCase(15, 21)]
        //[TestCase(10, 22)]
        //[TestCase(1, 23)]
        //[TestCase(0, 0)]
        //public void BackstagePassQualityDecreasesBeforeEvent(int startingSellIn, int expectedQualityAfterUpdate)
        //{
        //    var item = new Item
        //    {
        //        Name = "Backstage passes to a TAFKAL80ETC concert",
        //        Quality = 20,
        //        SellIn = startingSellIn
        //    };

        //    item.Update();

        //    Assert.That(item.Quality, Is.EqualTo(expectedQualityAfterUpdate));
        //}

        //[TestCase(10, 11)]
        //[TestCase(5, 11)]
        //[TestCase(0, 12)]
        //[TestCase(-1, 12)]
        //public void IncreasingValueItemsIncreaseInQuality(int startingSellIn, int expectedQualityAfterUpdate)
        //{
        //    var item = new Item
        //    {
        //        Name = "Aged Brie",
        //        Quality = 10,
        //        SellIn = startingSellIn
        //    };

        //    item.Update();

        //    Assert.That(item.Quality, Is.EqualTo(expectedQualityAfterUpdate));
        //}
    }
}