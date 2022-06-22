namespace GildedRoseKata.ItemTypes;

public class LegendaryItemType : ItemType
{
  public LegendaryItemType()
  {
    Type = "Legendary";
    QualityModifier = 0;
  }

  // Legendary Items do not lose or gain Quality and have no sellIn timeframe. Values remain the same.
  public override void UpdateQuality(ref int quality, ref int sellIn) {}
}
