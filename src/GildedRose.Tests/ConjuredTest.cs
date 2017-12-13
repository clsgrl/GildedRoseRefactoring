using System;
using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ConjuredTest : BaseTest
    {
        private Item performTest(int sellIn, int initQuality)
        {
            Program program = getProgram();

            program.Items = new List<Item> { new Item { Name = GlobalConstants.ProductTypes.CONJURED, SellIn = sellIn, Quality = initQuality } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            return changedItem;
        }

        [Fact]
        public void DegradeTwiceAsGenericItemBeforeSellIn()
        {
            Item changedItem = performTest(2, 10);

            Assert.Equal(8, changedItem.Quality);
        }

        [Fact]
        public void DegradeTwiceAsGenericItemAtSellIn()
        {
            Item changedItem = performTest(0, 10);

            Assert.Equal(6, changedItem.Quality);
        }

        [Fact]
        public void DegradeTwiceAsGenericItemAfterSellIn()
        {
            Item changedItem = performTest(-1, 10);

            Assert.Equal(6, changedItem.Quality);
        }

        [Fact]
        public void QualityNotNegativeBeforeSellIn()
        {
            Item changedItem = performTest(1, 1);

            Assert.Equal(0, changedItem.Quality);
        }

        [Fact]
        public void QualityNotNegativeAfterSellIn()
        {
            Item changedItem = performTest(-1, 1);

            Assert.Equal(0, changedItem.Quality);
        }

        [Fact]
        public void DecreaseSellIn()
        {
            Item changedItem = performTest(2, 10);

            Assert.Equal(1, changedItem.SellIn);
        }

    }
}
