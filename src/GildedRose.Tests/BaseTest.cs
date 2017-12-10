using System;
using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class BaseTest
    {
        protected static readonly int MAX_QUALITY = 50;
        protected static readonly string GENERIC_ITEM = "generic";
        protected static readonly string AGED_BRIE = "Aged Brie";
        protected static readonly string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        protected static readonly string SULFURAS = "Sulfuras, Hand of Ragnaros";

        private Program program;

        public BaseTest()
        {
            this.program = new Program();
        }


        /*protected Program Setup(Item item)
        {
            this.program = new Program()
            {
                Items = new List<Item> { item }
            };
            return this.program;
        }*/

        protected Program getProgram()
        {
            return this.program;
        }

    }
}
