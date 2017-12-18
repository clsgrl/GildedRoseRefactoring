
namespace GildedRose.Console
{
    /// <summary>
    /// Update strategy for concert backstage passes
    /// It increases in quality, as sellin date approaches, with the following pattern.
    /// Quality +1 if there are more then 10 days
    /// Quality +2 if there are 10 days or less.
    /// Quality +3 if there are 5 days or less.
    /// Quality = 0 after the concert
    /// Quality cannot be negative.
    /// The quality cannot increase more then GlobalConstants.Limits.MAX_QUALITY
    /// </summary>
    /// <param name="item">the Item to be update</param>
    public class BackstagePassStrategy : AbstractUpdateStrategy
    {
        public override void Update(Item item)
        {
            int sellIn = item.SellIn;
            int newQuality;
            if (IsSellInPassed(item) || IsSellInZero(item))
            {
                newQuality = 0;
            }
            else if(sellIn > 0 && sellIn < 6)
            {
                newQuality = item.Quality + 3;
            }
            else if(sellIn >= 6 && sellIn < 11)
            {
                newQuality = item.Quality + 2;
            }
            else
            {
                newQuality = item.Quality + 1;
            }
            DecreaseSellIn(item);
            item.Quality = newQuality < GlobalConstants.Limits.MAX_QUALITY ? newQuality : GlobalConstants.Limits.MAX_QUALITY;
        }
    }
}
