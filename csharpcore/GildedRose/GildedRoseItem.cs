using GildedRoseKata.Interfaces;
using GildedRoseKata.ItemTypes;

namespace GildedRoseKata;

/**
 * Adapter Pattern, used to convert an object to another with better compatibility with the application being written or refactored.
 * Original object remains intact and the adapter hides all the logic of the conversion.
 * In this case, object persistence is used to update the original object within it's collection passed into the GildedRose Class.
 */

public class GildedRoseItem : IGildedRoseItem
{
  private Item Item { get; }

  public string Name => Item.Name;
  public int Quality { get => Item.Quality; set => Item.Quality = value; }
  public int SellIn { get => Item.SellIn; set => Item.SellIn = value; }
  public ItemType ItemType { get; set; } = null!;
  
  public GildedRoseItem(Item item)
  {
    Item = item;
    IdentifyItem();
  }

  /**
   * Item identification, making use of the State Pattern to pattern match the names of each object to their relevant types.
   * The type contains identification characteristics and unique logic constraints to be applied to the item.
   * Additional types can be added as new classes, inheriting the base characteristics from the ItemType Class. 
   */
  private void IdentifyItem()
  {
    switch (Name)
    {
      case string legendary when legendary.ToLower().Contains("sulfuras"):
        ItemType = new LegendaryItemType();
        break;
      case string cheese when cheese.ToLower().Contains("aged brie"):
        ItemType = new CheeseItemType();
        break;
      case string conjured when conjured.ToLower().Contains("conjured"):
        ItemType = new ConjuredItemType();
        break;
      case string pass when pass.ToLower().Contains("backstage passes"):
        ItemType = new ConcertPassItemType();
        break;
      default:
        ItemType = new GeneralItemType();
        break;
    }
  }

  public void Update()
  {
    int quality = Quality;
    int sellIn = SellIn;
    
    ItemType.UpdateQuality(ref quality, ref sellIn);

    Quality = quality;
    SellIn = sellIn;
  }
}
