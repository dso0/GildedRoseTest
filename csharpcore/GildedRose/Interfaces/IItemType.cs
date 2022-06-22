namespace GildedRoseKata.Interfaces;

public interface IItemType
{
  public string Type { get; set; }
  public int QualityModifier { get; set; }

  public void UpdateQuality(ref int quality, ref int sellIn);
}
