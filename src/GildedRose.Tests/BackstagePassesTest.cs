using System;
using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class BackstagePassesTest : BaseTest
    {

        private Item performTest(int sellIn, int initQuality)
        {
            Program program = getProgram();

            program.Items =  new List<Item> { new Item { Name = BACKSTAGE_PASSES, SellIn = sellIn, Quality = initQuality } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            return changedItem;
        }

        [Fact]
        public void QualityIncreaseBefore11Days()
        {
            Item changedItem = performTest(11,20);

            Assert.Equal(21, changedItem.Quality);
        }

        [Fact]
        public void QualityIncreaseBetween10DaysAnd5Days()
        {
            Item changedItem = performTest(10,20);

            Assert.Equal(22, changedItem.Quality);
        }

        [Fact]
        public void QualityIncreaseBefore5Days()
        {
            Item changedItem = performTest(5, 20);

            Assert.Equal(23, changedItem.Quality);
        }

        [Fact]
        public void QualityIncreaseAt0()
        {
            Item changedItem = performTest(0, 20);

            Assert.Equal(0, changedItem.Quality);
        }

        [Fact]
        public void QualityIncreaseBeforeAfterConcert()
        {
            Item changedItem = performTest(-1, 20);

            Assert.Equal(0, changedItem.Quality);
        }

        [Fact]
        public void QualityIncreaseNotAbove50()
        {
            Item changedItem11 = performTest(11, MAX_QUALITY);
            Item changedItem10 = performTest(10, MAX_QUALITY);
            Item changedItem5 = performTest(5, MAX_QUALITY);

            Assert.Equal(MAX_QUALITY, changedItem11.Quality);
            Assert.Equal(MAX_QUALITY, changedItem10.Quality);
            Assert.Equal(MAX_QUALITY, changedItem5.Quality);
        }

    }
}
