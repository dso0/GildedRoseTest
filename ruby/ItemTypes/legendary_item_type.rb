require File.join(File.dirname(__FILE__), 'item_type')

class LegendaryItemType < ItemType
  def initialize
    @quality_modifier = 0
    @type = "Legendary"
    super
  end

  def update_quality(quality, sell_in)
    [quality,sell_in]
  end
end
