using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> _items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = GetApp();

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public static Program GetApp()
        {
            return new Program()
            {
                _items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }

            };
        }

        public String Status()
        {
            return _items.Aggregate("", (current, item) => current + (item.Stringify()));
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.IsLegendary()) continue;

                if (item.IsStandard())
                {
                    item.ReduceItemQualityByOne();
                }
                else
                {
                    item.IncreaseItemQualityByOne();

                    UpdateItemQualityForBackstagePass(item);
                }

                ItemQualityUpdateByAge(item);
            }
        }

        private static void UpdateItemQualityForBackstagePass(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private static void ItemQualityUpdateByAge(Item item)
        {
            item.SellIn--;

            if (item.IsExpired())
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        item.IncreaseItemQualityByOne();
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.Quality = 0;
                        break;
                    default:
                        item.ReduceItemQualityByOne();
                        break;
                }
            }
        }
    }
}
