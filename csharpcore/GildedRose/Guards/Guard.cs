using GildedRoseKata.Interfaces;

namespace GildedRoseKata.Guards;

/**
 * Encapsulates possible validation logic into clearly named extension methods.
 * This helps prevent duplication of validation logic and allow for a cleaner management of possible thrown exceptions or the outcomes of rules.
 *
 * This class acts as an entry point for all Guard Clause extension methods.
 *
 * Treated as a simple Singleton by privatising the constructor.
 * Private constructors instantiation.
 * Why not a static class? Static classes cannot inherit from an interface.
 */

public sealed class Guard : IGuardClause
{ 
  // The entry point to the extension methods.
  public static IGuardClause Against { get; } = new Guard();
  private Guard() { }
}
