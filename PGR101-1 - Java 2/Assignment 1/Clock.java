
/**
 * Write a description of class Clock here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Clock extends Meter
{
    public Clock() {
        super(Meter.createUID("CL"), "Cloud");
        setMinimumValue(60.0);
    }
    
    public Clock(String uid) {
        super(uid, "Cloud");
        setMinimumValue(60.0);
    }
    
    public Clock(String uid, String locid) {
        super(uid, locid);
        setMinimumValue(60.0);
    }
    
    public String toString() {
        return "Clock{uID='" + getUID() + "',locID='" + getLocationID() + "'}";
    }
}
