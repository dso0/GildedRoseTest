require 'singleton'

class GuardAgainst
  include Singleton

  def self.quality_limitations(quality)
    return 50 if quality > 50
    return 0 if quality < 0
    quality
  end
end
