using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    /// <summary>
    /// Aged Brie item update strategy
    /// It increases in quality the older it gets. The quality cannot increase more then GlobalConstants.Limits.MAX_QUALITY
    /// Quality cannot be negative.
    /// </summary>
    /// <param name="item">the Item to be update</param>
    public class AgedBrieStrategy : AbstractUpdateStrategy
    {
        public override void Update(Item item) 
        {
            DecreaseSellIn(item);

            int newQuality = IsSellInPassed(item) ? item.Quality + 2 : item.Quality + 1;

            item.Quality = newQuality < GlobalConstants.Limits.MAX_QUALITY? newQuality : GlobalConstants.Limits.MAX_QUALITY;
        }

    }
}
