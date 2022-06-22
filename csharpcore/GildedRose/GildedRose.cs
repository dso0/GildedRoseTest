using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
  IList<Item> Items;

  public GildedRose(IList<Item> Items)
  {
    this.Items = Items;
  }

  public void UpdateQuality()
  {
    foreach (Item item in Items)
    {
      GildedRoseItem gildedRoseItem = new GildedRoseItem(item);
      
      gildedRoseItem.Update();
    }
  }
}
