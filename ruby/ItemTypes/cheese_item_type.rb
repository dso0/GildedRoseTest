require File.join(File.dirname(__FILE__), 'item_type')
require File.join(File.dirname(__FILE__), '../guard_against')

class CheeseItemType < ItemType
  def initialize
    @type = "Cheese!"
    super
  end

  def update_quality(quality, sell_in)
    multiplier = sell_in < 0 ? 2 : 1

    quality += @quality_modifier * multiplier

    quality = GuardAgainst.quality_limitations(quality)

    sell_in -= 1

    [quality, sell_in]
  end
end
