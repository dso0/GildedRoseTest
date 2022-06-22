require File.join(File.dirname(__FILE__), 'item_type')

class GeneralItemType < ItemType
  def initialize
    @type = "General"
    super
  end
end
