using System;

namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public static class ItemExtension
    {
        public static String Stringify(this Item item)
        {
            return item.Name + " " + item.SellIn + " " + item.Quality;
        }

        public static bool IsLegendary(this Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public static bool IsStandard(this Item item)
        {
            return !(item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert");
        }

        public static bool IsExpired(this Item item)
        {
            return item.SellIn < 0;
        }

        public static void IncreaseItemQualityByOne(this Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public static void ReduceItemQualityByOne(this Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}
