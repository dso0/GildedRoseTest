using Xunit;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using GildedRoseKata.ItemTypes;

namespace GildedRoseTests;

public class GildedRoseTest
{
  [Fact]
  public void Foo()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    Assert.Equal("foo", Items.First().Name);
  }

  [Fact]
  public void CheeseTypeMatches()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    GildedRoseItem item = new GildedRoseItem(Items.First());
    Assert.Equal("Cheese!", item.ItemType.Type);
  }
  
  [Fact]
  public void LegendaryTypeMatches()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    GildedRoseItem item = new GildedRoseItem(Items.First());
    Assert.Equal("Legendary", item.ItemType.Type);
  }
  
  [Fact]
  public void ConjuredTypeMatches()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 1}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    GildedRoseItem item = new GildedRoseItem(Items.First());
    Assert.Equal("Conjured", item.ItemType.Type);
  }
  
  [Fact]
  public void ConcertPassTypeMatches()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 1}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    GildedRoseItem item = new GildedRoseItem(Items.First());
    Assert.Equal("Concert Pass", item.ItemType.Type);
  }
  
  [Fact]
  public void GeneralTypesMatch()
  {
    IList<Item> Items = new List<Item>
    {
      new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
      new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
      new Item {Name = "The Third Wheel", SellIn = 6, Quality = 12},
    };
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    Assert.True(Items.All(i => new GildedRoseItem(i).ItemType.Type == "General"));
  }

  [Fact]
  public void LegendaryValuesDoNotChange()
  {
    IList<Item> Items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80}};
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    Assert.True(Items.First().Quality == 80 && Items.First().SellIn == 5);
  }
  
  [Fact]
  public void QualityLimitationsAreMet()
  {
    IList<Item> Items = new List<Item>
    {
      new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
      new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
      new Item {Name = "The Third Wheel", SellIn = 6, Quality = 12},
      new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 1},
      new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 1},
      new Item {Name = "Aged Brie", SellIn = 0, Quality = 50}
    };
    GildedRose app = new GildedRose(Items);
    app.UpdateQuality();
    Assert.True(Items.All(i => i.Quality is >= 0 and <= 50));
  }
}