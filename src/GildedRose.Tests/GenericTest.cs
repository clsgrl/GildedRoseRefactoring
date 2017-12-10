using System;
using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class GenericTest : BaseTest
    {

        [Fact]
        public void NameDontChange()
        {
            Program program = getProgram();

            program.Items = new List<Item> { new Item { Name = GENERIC_ITEM, SellIn = 10, Quality = 1 } };

            System.Diagnostics.Trace.WriteLine("------------------ Testing assert 1");

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            System.Diagnostics.Trace.WriteLine("---------- Testing assert");

            Assert.Equal(GENERIC_ITEM, changedItem.Name);

            System.Diagnostics.Trace.WriteLine("----------- End of test NameDontChange");
        }

        [Fact]
        public void QualityAlwaysPositive()
        {
            Program program = getProgram();
            program.Items = new List<Item> { 
                new Item { Name = GENERIC_ITEM, SellIn = 0, Quality = 0 }, 
                new Item { Name = SULFURAS, SellIn = 0, Quality = 0 },
                new Item { Name = AGED_BRIE, SellIn = 0, Quality = 0 },
                new Item { Name = BACKSTAGE_PASSES, SellIn = 0, Quality = 0 }
            };

            program.UpdateQuality();

            foreach (Item it in program.Items)
            {
                Assert.True((it.Quality >= 0), "The quality was negative");
            }

        }

    }
}
