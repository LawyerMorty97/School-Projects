
/**
 * Write a description of class Thermometer here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Thermometer extends Meter
{
    public final double MIN_TEMP = -10.5; // Lowest temperature the instrument can measure
    public final double MAX_TEMP = 125.75; // Highest temperature the instrument can measure
    private double temp; // The current temperature the instrument has measured
    
    public Thermometer() {
        super(Meter.createUID("TH"), "Cloud");
        setMinimumValue(MIN_TEMP);
        setMaximumValue(MAX_TEMP);
    }
    
    public Thermometer(String uid) {
        super(uid, "Cloud");
        setMinimumValue(MIN_TEMP);
        setMaximumValue(MAX_TEMP);
    }
    
    public Thermometer(String uid, String locid)
    {
        super(uid, locid);
        setMinimumValue(MIN_TEMP);
        setMaximumValue(MAX_TEMP);
    }
    
    public double getTemp() {
        return this.temp;
    }
    
    public String toString() {
        return "Thermometer{uID='" + getUID() + "',locID='" + getLocationID() + "'}";
    }
}
