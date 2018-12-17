
/**
 * Write a description of class Weight here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Weight extends Meter
{
    public final double MIN_WEIGHT = 0.1; // The minimum weight the instrument can measure (1 gram)
    public final double MAX_WEIGHT = 1000; // The maximum weight the instrument can measure (1 tonne)
    private double weight; // Current weight the instrument has measured;
    
    public Weight() {
        super(Meter.createUID("WG"), "Cloud");
        setMinimumValue(MIN_WEIGHT);
        setMaximumValue(MAX_WEIGHT);
    }
    
    public Weight(String uid) {
        super(uid, "Cloud");
        setMinimumValue(MIN_WEIGHT);
        setMaximumValue(MAX_WEIGHT);
    }
    
    public Weight(String uid, String locid)
    {
        super(uid, locid);
        setMinimumValue(MIN_WEIGHT);
        setMaximumValue(MAX_WEIGHT);
    }
    
    public boolean equals(Weight objectToCompare) {
        if (this == objectToCompare) {
            return true;
        }
        
        if (this.getUID() == objectToCompare.getUID() && this.getLocationID() == objectToCompare.getLocationID()) {
            return true;
        }
        
        
        return false;
    }
    
    public String toString() {
        return "Weight{uID='" + getUID() + "',locID='" + getLocationID() + "'}";
    }
}
