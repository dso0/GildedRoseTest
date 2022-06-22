require File.join(File.dirname(__FILE__), 'gilded_rose')
require File.join(File.dirname(__FILE__), 'gilded_rose_item')
require 'test/unit'

class TestUntitled < Test::Unit::TestCase

  def test_foo
    items = [Item.new("foo", 0, 0)]
    GildedRose.new(items).update_quality
    assert_equal items[0].name, "foo"
  end

  def test_quality_limitations_met
    items = [
      Item.new(name="+5 Dexterity Vest", sell_in=10, quality=20),
      Item.new(name="Aged Brie", sell_in=3, quality=48),
      Item.new(name="Backstage passes to a TAFKAL80ETC concert", sell_in=15, quality=20),
      Item.new(name="Conjured Mana Cake", sell_in=3, quality=6)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| item.quality >= 0 && item.quality <= 50}
  end

  def test_legend_values_dont_change
    items = [Item.new("Sulfuras, Hand of Ragnaros", 0, 80)]
    GildedRose.new(items).update_quality
    assert_equal true, items.first.quality == 80 && items.first.sell_in == 0
  end

  def test_general_type_match
    items = [
      Item.new(name="+5 Dexterity Vest", sell_in=10, quality=20),
      Item.new(name="Elixir of the Mongoose", sell_in=5, quality=7),
      Item.new(name="The Third Wheel", sell_in=6, quality=9)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| GildedRoseItem.new(item).item_type.type == "General"}
  end

  def test_pass_type_match
    items = [
      Item.new(name="Backstage passes to a TAFKAL80ETC concert", sell_in=10, quality=20)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| GildedRoseItem.new(item).item_type.type == "Concert Pass"}
  end

  def test_cheese_type_match
    items = [
      Item.new(name="Aged Brie", sell_in=10, quality=20)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| GildedRoseItem.new(item).item_type.type == "Cheese!"}
  end

  def test_legendary_type_match
    items = [
      Item.new(name="Sulfuras, Hand of Ragnaros", sell_in=10, quality=20)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| GildedRoseItem.new(item).item_type.type == "Legendary"}
  end

  def test_conjured_type_match
    items = [
      Item.new(name="Conjured Mana Cake", sell_in=10, quality=20)
    ]
    GildedRose.new(items).update_quality
    assert_equal true, items.all? {|item| GildedRoseItem.new(item).item_type.type == "Conjured"}
  end

end