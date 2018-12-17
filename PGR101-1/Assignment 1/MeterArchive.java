import java.util.List;
import java.util.LinkedList;
/**
 * Write a description of class MeterArchive here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class MeterArchive
{
    private LinkedList<Meter> instruments;
    
    public MeterArchive() {
        this.instruments = new LinkedList<Meter>();
    }
    
    public void addInstrument(Meter object) {
        String uid = object.getUID();
        this.instruments.add(object);
        log("Instrument " + uid + " was added. Total objects: " + instruments.size());
    }
    
    public Meter getInstrument(String uID) {
        Meter found = null;
        
        for (Meter obj: this.instruments) {
            if (uID == obj.getUID()) {
                found = obj;
                break;
            }
        }
        
        return found;
    }
    
    public boolean removeInstrument(String uID) {
        Meter object = getInstrument(uID);
        if (object != null) {
            this.instruments.remove(object);
            log("Instrument " + uID + " was removed. Total objects: " + instruments.size());
            return true;
        }
        return false;
    }
    
    public int getInstrumentCount() {
        return this.instruments.size();
    }
    
    public void log(String text) {
        System.out.println(text);
    }
    
    public void getInstrumentOverview() {
        log("Instrument Overview");
        if (this.instruments.size() > 0) {
            for (Meter obj: this.instruments) {
                log("\n" + obj.toString());
                log("Registration ID: " + obj.getUID());
                log("Location: " + obj.getLocationID());
                log("Meter Interval: " + obj.getValue());
                //log(" - " + obj.getUID() + " (Location: " + obj.getLocationID() + ")");
            }
        } else {
            log("These are no instruments instanced.");
        }
    }
}
