using System;
using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class BaseTest
    {

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
