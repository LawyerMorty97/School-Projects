
/**
 * Write a description of class Client here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Client
{
    public MeterArchive archive;
    
    public Client() {
        archive = new MeterArchive();
    }
    
    public String addClock(String locationID) {
        String identifier = Meter.createUID("CL");
        Meter clock = new Clock(identifier, locationID);
        
        this.archive.addInstrument(clock);
        return identifier;
    }
    
    public String addThermometer(String locationID) {
        String identifier = Meter.createUID("TH");
        Meter thermo = new Thermometer(identifier, locationID);
        
        this.archive.addInstrument(thermo);
        return identifier;
    }
    
    public String addWeight(String locationID) {
        String identifier = Meter.createUID("WG");
        Meter weight = new Weight(identifier, locationID);
        
        this.archive.addInstrument(weight);
        return identifier;
    }
    
    public void mainMethod() {
        String clock = addClock("F1R1");
        Meter cObj = archive.getInstrument(clock);
        
        String weight = addWeight("F1R2");
        Meter wObj = archive.getInstrument(weight);
        
        String thermo = addThermometer("F1R3");
        Meter tObj = archive.getInstrument(thermo);
        
        archive.removeInstrument(clock);
    }
}
