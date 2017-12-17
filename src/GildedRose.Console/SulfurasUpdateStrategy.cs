using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    /// <summary>
    /// Sulfuras item update strategy
    /// Quality and sell in date never change. The quality is always 80
    /// </summary>
    /// <param name="item">the Item to be update</param>
    public class SulfurasUpdateStrategy : AbstractUpdateStrategy
    {
        public override void Update(Item item)
        {

        }
    }
}
