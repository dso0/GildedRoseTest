require File.join(File.dirname(__FILE__), 'item_type')
require File.join(File.dirname(__FILE__), '../guard_against')

class ConjuredItemType < ItemType
  def initialize
    @quality_modifier = 2
    @type = "Conjured"
    super
  end

  def update_quality(quality, sell_in)
    multiplier = 1
    multiplier = 2 if sell_in <= 10
    multiplier = 3 if sell_in <= 5

    quality = 0 if sell_in < 0

    quality += @quality_modifier * multiplier

    quality = GuardAgainst.quality_limitations(quality)

    sell_in -= 1

    [quality, sell_in]
  end
end
