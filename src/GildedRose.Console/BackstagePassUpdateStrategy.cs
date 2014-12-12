namespace GildedRose.Console
{
    class BackstagePassUpdateStrategy : IItemUpdateStrategy
    {
        public Item Update(Item item)
        {
            item.IncreaseItemQualityByOne();

            if (item.SellIn < 11)
            {
                item.IncreaseItemQualityByOne();
            }

            if (item.SellIn < 6)
            {
                item.IncreaseItemQualityByOne();
            }

            item.SellIn--;

            if (item.IsExpired())
            {
                item.Quality = 0;
            }

            return item;
        }
    }
}
