using GildedRoseKata.Guards;

namespace GildedRoseKata.ItemTypes;

public class CheeseItemType : ItemType
{
  public CheeseItemType()
  {
    Type = "Cheese!";
  }

  public override void UpdateQuality(ref int quality, ref int sellIn)
  {
    int multiplier = sellIn < 0 ? 2 : 1;

    quality += QualityModifier * multiplier;

    quality = Guard.Against.QualityLimitations(quality);
    
    sellIn--;
  }
}
