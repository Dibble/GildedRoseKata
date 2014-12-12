namespace GildedRose.Console
{
    class StandardItemStrategy : IItemUpdateStrategy
    {
        public Item Update(Item item)
        {
            item.ReduceItemQualityByOne();

            item.SellIn--;

            if (item.IsExpired())
            {
                item.ReduceItemQualityByOne();
            }

            return item;
        }
    }
}
