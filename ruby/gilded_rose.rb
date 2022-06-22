require File.join(File.dirname(__FILE__), 'item')
require File.join(File.dirname(__FILE__), 'gilded_rose_item')

class GildedRose

  def initialize(items)
    @items = items
  end

  def update_quality()
    @items.each do |item|
      gilded_rose_item = GildedRoseItem.new(item).update
    end
  end
end
