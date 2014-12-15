namespace GildedRose.Console
{
    class StandardItemStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.ReduceItemQualityByOne();

            item.SellIn--;

            if (item.IsExpired())
            {
                item.ReduceItemQualityByOne();
            }
        }
    }
}
