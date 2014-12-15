namespace GildedRose.Console
{
    class IncreasingValueUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.IncreaseItemQualityByOne();

            item.SellIn--;

            if (item.IsExpired())
            {
                item.IncreaseItemQualityByOne();
            }
        }
    }
}
