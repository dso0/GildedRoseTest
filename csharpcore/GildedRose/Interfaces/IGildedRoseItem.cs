using GildedRoseKata.ItemTypes;

namespace GildedRoseKata.Interfaces;

public interface IGildedRoseItem
{
  public int Quality { get; set; }
  public int SellIn { get; set; }
  public ItemType ItemType { get; set; }

  public void Update();
}
