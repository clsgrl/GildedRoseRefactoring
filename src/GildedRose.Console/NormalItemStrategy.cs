using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    /// <summary>
    /// Normal item update strategy
    /// If sell in date has passed, Quality decreases by 2 otherwise by 1.
    /// Quality cannot be negative.
    /// </summary>
    /// <param name="item">the Item to be update</param>
    public class NormalItemStrategy : AbstractUpdateStrategy
    {
        public override void Update(Item item)
        {
            DecreaseSellIn(item);

            int newQuality = IsSellInPassed(item) ? item.Quality - 2 : item.Quality - 1;

            item.Quality = Math.Max(0, newQuality);
        }
    }
}
