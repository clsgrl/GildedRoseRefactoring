using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

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

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != GlobalConstants.ProductTypes.AGED_BRIE && Items[i].Name != GlobalConstants.ProductTypes.BACKSTAGE_PASSES)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != GlobalConstants.ProductTypes.SULFURAS)
                        {
                            //added quality decreasing for "Conjured Nana Cake"
                            if (Items[i].Name == GlobalConstants.ProductTypes.CONJURED)
                            {
                                int newQuality = Items[i].Quality - 2;
                                Items[i].Quality = Math.Max(0, newQuality);
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == GlobalConstants.ProductTypes.BACKSTAGE_PASSES)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != GlobalConstants.ProductTypes.SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != GlobalConstants.ProductTypes.AGED_BRIE)
                    {
                        if (Items[i].Name != GlobalConstants.ProductTypes.BACKSTAGE_PASSES)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != GlobalConstants.ProductTypes.SULFURAS)
                                {
                                    //added quality decreasing for "Conjured Nana Cake"
                                    if (Items[i].Name == GlobalConstants.ProductTypes.CONJURED)
                                    {
                                        int newQuality = Items[i].Quality - 2;
                                        Items[i].Quality = Math.Max(0, newQuality);
                                    }
                                    else
                                    {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
