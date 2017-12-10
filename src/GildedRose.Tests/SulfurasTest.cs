using System;
using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class SulfurasTest : BaseTest
    {
        private int defaultSellin = 0;
        private int defaultQuality = 80;

        [Fact]
        public void QualityAndSellInNeverChange()
        {
            Program program = getProgram();

            program.Items = new List<Item> { new Item { Name = SULFURAS, SellIn = defaultSellin, Quality = defaultQuality } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            Assert.Equal(defaultQuality, changedItem.Quality);
            Assert.Equal(defaultSellin, changedItem.SellIn);
        }
    }
}
