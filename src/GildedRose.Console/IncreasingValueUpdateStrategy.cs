namespace GildedRose.Console
{
    class IncreasingValueUpdateStrategy : IItemUpdateStrategy
    {
        public Item Update(Item item)
        {
            item.IncreaseItemQualityByOne();

            item.SellIn--;

            if (item.IsExpired())
            {
                item.IncreaseItemQualityByOne();
            }

            return item;
        }
    }
}
