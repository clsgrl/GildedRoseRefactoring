using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public static class StrategyFactory
    {
        public static IUpdateStrategy Create<T>() where T : IUpdateStrategy, new ()
        {
            return new T();
        }
    }
}
