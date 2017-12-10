using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class GenericItemTest : BaseTest
    {

        [Fact]
        public void DecreaseSellDateAndQuality()
        {
            Program program = getProgram();

            program.Items = new List<Item> { new Item { Name = GENERIC_ITEM, SellIn = 0, Quality = 1 } };

            System.Diagnostics.Trace.WriteLine("------------------ Testing assert 1");

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            System.Diagnostics.Trace.WriteLine("---------- Testing assert");

            Assert.Equal(0, changedItem.Quality);
            Assert.Equal(-1, changedItem.SellIn);

        }

        [Fact]
        public void DecraseQualityTwiceWhenExpired()
        {
            Program program = getProgram();
            int initQuality = 2;
            program.Items = new List<Item> { new Item { Name = GENERIC_ITEM, SellIn = -1, Quality = initQuality } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            Assert.Equal(initQuality - 2, changedItem.Quality);
        }

        [Fact]
        public void DecraseQualityTwiceWhenExpiredNonNegativeQuality()
        {
            Program program = getProgram();

            program.Items = new List<Item> { new Item { Name = GENERIC_ITEM, SellIn = -1, Quality = 1 } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            Assert.Equal(0, changedItem.Quality);
        }
    }
}
