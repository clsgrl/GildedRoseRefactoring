using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private static Dictionary<string, IUpdateStrategy> strategies = new Dictionary<string, IUpdateStrategy>();

        static Program()
        {
            strategies.Add(GlobalConstants.ProductTypes.AGED_BRIE, StrategyFactory.Create<AgedBrieStrategy>());
            strategies.Add(GlobalConstants.ProductTypes.SULFURAS, StrategyFactory.Create<SulfurasUpdateStrategy>());
            strategies.Add(GlobalConstants.ProductTypes.CONJURED, StrategyFactory.Create<ConjuredItemStrategy>());
            strategies.Add(GlobalConstants.ProductTypes.BACKSTAGE_PASSES, StrategyFactory.Create<BackstagePassStrategy>());
            strategies.Add(GlobalConstants.ProductTypes.NORMAL, StrategyFactory.Create<NormalItemStrategy>());
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                string name = item.Name;
                IUpdateStrategy strategy;
                bool found = strategies.TryGetValue(name, out strategy);
                if (!found)
                {
                    strategy = strategies[GlobalConstants.ProductTypes.NORMAL];
                }
                strategy.Update(item);
            }
        }

        private void PrintItems()
        {
            foreach (Item item in Items)
            {
                System.Console.WriteLine("Name: " + item.Name);
                System.Console.WriteLine("SellIn: " + item.SellIn);
                System.Console.WriteLine("Quality: " + item.Quality);
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = GlobalConstants.ProductTypes.DEXTERITY_VEST, SellIn = 10, Quality = 20},
                                              new Item {Name = GlobalConstants.ProductTypes.AGED_BRIE, SellIn = 2, Quality = 0},
                                              new Item {Name = GlobalConstants.ProductTypes.ELIXIR_MONGOOSE, SellIn = 5, Quality = 7},
                                              new Item {Name = GlobalConstants.ProductTypes.SULFURAS, SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = GlobalConstants.ProductTypes.BACKSTAGE_PASSES,
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = GlobalConstants.ProductTypes.CONJURED, SellIn = 3, Quality = 6}
                                          }
                          };
            
            app.UpdateQuality();

            System.Console.WriteLine("After update: ");
            app.PrintItems();

            System.Console.ReadKey();

        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
