require File.join(File.dirname(__FILE__), 'ItemTypes/general_item_type')
require File.join(File.dirname(__FILE__), 'ItemTypes/legendary_item_type')
require File.join(File.dirname(__FILE__), 'ItemTypes/cheese_item_type')
require File.join(File.dirname(__FILE__), 'ItemTypes/conjured_item_type')
require File.join(File.dirname(__FILE__), 'ItemTypes/concert_pass_item_type')

class GildedRoseItem
  attr_accessor :item, :item_type

  def initialize(item)
    @item = item
    identify
  end

  def name
    @item.name
  end

  def quality
    @item.quality
  end

  def quality=(value)
    @item.quality = value
  end

  def sell_in
    @item.sell_in
  end

  def sell_in=(value)
    @item.sell_in = value
  end

  def identify
    @item_type = GeneralItemType.new
    @item_type = LegendaryItemType.new if name.downcase.include? "sulfuras"
    @item_type = CheeseItemType.new if name.downcase.include? "aged brie"
    @item_type = ConjuredItemType.new if name.downcase.include? "conjured"
    @item_type = ConcertPassItemType.new if name.downcase.include? "backstage passes"
  end

  def update
    qual = quality
    sell = sell_in

    qual, sell = @item_type.update_quality(qual,sell)

    quality = qual
    sell_in = sell
  end
end
