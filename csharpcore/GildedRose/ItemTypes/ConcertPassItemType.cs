using System.Diagnostics;
using GildedRoseKata.Guards;

namespace GildedRoseKata.ItemTypes;

public class ConcertPassItemType : ItemType
{
  public ConcertPassItemType()
  {
    Type = "Concert Pass";
  }

  public override void UpdateQuality(ref int quality, ref int sellIn)
  {
    int multiplier = 1;

    if (sellIn <= 10) multiplier = 2;
    if (sellIn <= 5) multiplier = 3;
    if (sellIn < 0) quality = 0; 
    
    quality += QualityModifier * multiplier;

    quality = Guard.Against.QualityLimitations(quality);
    
    sellIn--;
  }
}
