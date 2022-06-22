using GildedRoseKata.Interfaces;

namespace GildedRoseKata.Guards;

public static partial class GuardClauseExtensions
{
  public static int QualityLimitations(this IGuardClause guard, int quality)
  {
    switch (quality)
    {
      case > 50:
        return 50;
      case < 0:
        return 0;
      default:
        return quality;
    }

    // Alternative, compact syntax (Readability Issue)
    // return quality switch
    // {
    //   > 50 => 50,
    //   < 0 => 0,
    //   _ => quality
    // };
  }
}
