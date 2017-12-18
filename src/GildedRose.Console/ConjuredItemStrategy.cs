using System;

namespace GildedRose.Console
{
    /// <summary>
    /// Conjured item update strategy
    /// Quality decreases twice as fast as a normal item.
    /// Quality cannot be negative.
    /// </summary>
    /// <param name="item">the Item to be update</param>
    public class ConjuredItemStrategy : AbstractUpdateStrategy
    {
        public override void Update(Item item)
        {
            DecreaseSellIn(item);

            int newQuality = IsSellInPassed(item) ? item.Quality - 4 : item.Quality - 2;

            item.Quality = Math.Max(0, newQuality);
        }
    }
}
