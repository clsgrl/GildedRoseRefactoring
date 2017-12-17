using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public abstract class AbstractUpdateStrategy : IUpdateStrategy
    {
        public abstract void Update(Item item);

        public bool IsQualityNegative(Item item) 
        {
            return item.Quality < 0;
        }

        public bool IsSellInPassed(Item item) 
        {
            return item.SellIn < 0;
        }

        public bool IsSellInZero(Item item)
        {
            return item.SellIn == 0;
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }

    }
}
