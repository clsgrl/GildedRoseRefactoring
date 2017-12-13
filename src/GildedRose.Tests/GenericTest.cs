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

            program.Items = new List<Item> { new Item { Name = GlobalConstants.ProductTypes.DEXTERITY_VEST, SellIn = 10, Quality = 1 } };

            program.UpdateQuality();

            Item changedItem = program.Items[0];

            Assert.Equal(GlobalConstants.ProductTypes.DEXTERITY_VEST, changedItem.Name);

        }

        [Fact]
        public void QualityAlwaysPositive()
        {
            Program program = getProgram();
            program.Items = new List<Item> { 
                new Item { Name = GlobalConstants.ProductTypes.DEXTERITY_VEST, SellIn = 0, Quality = 0 }, 
                new Item { Name = GlobalConstants.ProductTypes.SULFURAS, SellIn = 0, Quality = 0 },
                new Item { Name = GlobalConstants.ProductTypes.AGED_BRIE, SellIn = 0, Quality = 0 },
                new Item { Name = GlobalConstants.ProductTypes.BACKSTAGE_PASSES, SellIn = 0, Quality = 0 }
            };

            program.UpdateQuality();

            foreach (Item it in program.Items)
            {
                Assert.True((it.Quality >= 0), "The quality was negative");
            }

        }

    }
}
