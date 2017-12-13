using System;
using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class BaseTest
    {
        /*protected const int MAX_QUALITY = 50;
        protected const string GENERIC_ITEM = "generic";
        protected const string AGED_BRIE = "Aged Brie";
        protected const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        protected const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        protected const string CONJURED = "Conjured Mana Cake"; 
        */
        private Program program;

        public BaseTest()
        {
            this.program = new Program();
        }

        protected Program getProgram()
        {
            return this.program;
        }

    }
}
