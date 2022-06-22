using GildedRoseKata.Guards;
using GildedRoseKata.Interfaces;

namespace GildedRoseKata.ItemTypes;
/**
 * State Pattern, used to convert state machines, generally written using switch or if statements into classes with their relevant state-specific logic.
 * Use-case: Each Item Type has unique logic on how the quality of the type is modified.
 * Parts of this logic can be made generic by assigning properties to take the place of hard-coded values
 * I.E the QualityModifier, which is used to control by how much the quality is adjusted.
 *
 * Base class is made as an abstraction. This allows for inheritance with base logic for the UpdateQuality method and if needed, the ability to override said logic partly or completely.
 */
public abstract class ItemType : IItemType
{
  public string Type { get; set; }
  public int QualityModifier { get; set; } = 1;

  public virtual void UpdateQuality(ref int quality,ref int sellIn)
  {
    int multiplier = sellIn < 0 ? 2 : 1;

    quality -= QualityModifier * multiplier;

    quality = Guard.Against.QualityLimitations(quality);
    
    sellIn--;
  }
}
