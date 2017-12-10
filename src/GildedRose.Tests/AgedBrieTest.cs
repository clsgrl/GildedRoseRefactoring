using System;
using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class AgedBrieTest : BaseTest
    {
        [Fact]
        public void IncreaseQualitySimple()
        {
            Program program = getProgram();

            int initQuality = 1;
            program.Items = new List<Item> { new Item { Name = AGED_BRIE, SellIn = 1, Quality = initQuality } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            Assert.Equal(initQuality + 1, changedItem.Quality);
        }
        
        [Fact]
        public void QualityNotGreaterThan50()
        {
            Program program = getProgram();
            
            program.Items = new List<Item> { 
                new Item { Name = AGED_BRIE, SellIn = 20, Quality = MAX_QUALITY },
                new Item { Name = AGED_BRIE, SellIn = 0, Quality = MAX_QUALITY },
                new Item { Name = AGED_BRIE, SellIn = -10, Quality = MAX_QUALITY }
            };

            program.UpdateQuality();

            foreach (Item item in program.Items)
            {
                Assert.Equal(MAX_QUALITY, item.Quality);
            }
        }

        [Fact]
        public void DoubleIncreaseQualityWhenDateZeroOrLess()
        {
            Program program = getProgram();

            int initQuality = 2;
            program.Items = new List<Item> { 
                new Item { Name = AGED_BRIE, SellIn = 0, Quality = initQuality },
                new Item { Name = AGED_BRIE, SellIn = -2, Quality = initQuality } 
            };

            program.UpdateQuality();

            Item changedItemAt0 = program.Items[0];
            Item changedItemAtLess2 = program.Items[1];

            Assert.Equal(initQuality + 2, changedItemAt0.Quality);
            Assert.Equal(initQuality + 2, changedItemAtLess2.Quality);
        }

    }
}
