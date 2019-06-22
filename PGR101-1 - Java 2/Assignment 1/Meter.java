import java.util.Random;
/**
 * Write a description of class Meter here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public abstract class Meter
{
    private String regid; // Instrument Unique Identifier
    private String status; // Instrument Status
    private String locid; // Instrument Location Identifier
    
    private double minValue = 0.0;
    private double maxValue = 0.0;

    public Meter(String regid, String locid) {
        this.regid = regid;
        this.status = "inactive";
        this.locid = locid;
    }
    
    public void setMinimumValue(double minVal) {
        this.minValue = minVal;
    }
    
    public void setMaximumValue(double maxVal) {
        this.maxValue = maxVal;
    }
    
    public double getMinimumValue() {
        return this.minValue;
    }
    
    public double getMaximumValue() {
        return this.maxValue;
    }
    
    public String getUID() {
        return this.regid;
    }
    
    public String getLocationID() {
        return this.locid;
    }
    
    public String getStatus() {
        return this.status;
    }
    
    public boolean setStatus(String status) {
        this.status = status;
        return true;
    }
    
    public String getValue() {
        String ret = "";
        
        if (this.maxValue > this.minValue && this.maxValue > 0.0) {
            ret = Double.toString(this.minValue) + " - " + Double.toString(this.maxValue);
        } else {
            ret = Double.toString(this.minValue);
        }
        
        return ret;
    }
    
    // Utilities for meter identification
    public static String createUID(String prefix) {
        Random r = new Random();
        
        int nid = r.nextInt(500) + 1;
        String id = prefix + Integer.toString(nid);
        
        return id;
    }
}
