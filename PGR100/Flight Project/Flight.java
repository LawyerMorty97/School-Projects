import java.util.*;
public class Flight
{
    String origin, destination;
    String date, eta;
    String flightID;
    boolean domestic;
    ArrayList<Crew> flightCrew;
    ArrayList<Cargo> flightCargo;
    Aircraft craft;
    
    public Flight(String origin, String destination)
    {
        this.origin = new String(origin);
        this.destination = new String(destination);
        
        craft = new Aircraft();
        flightCrew = new ArrayList<Crew>();
        
        Crew c1 = new Crew("Adam");
        flightCrew.add(c1);
        
        // Generate a flight id
        char l1 = origin.charAt(0);
        char l2 = destination.charAt(0);
        char lid[] = {l1, l2};
        String lad = new String(lid);
        flightID = lad + "0" + origin.length() + destination.length() + craft.getType();
    }
    
    public void getCrewDetails()
    {
        System.out.println("Crew Members: " + flightCrew.size());
        
        for (Crew crew : flightCrew)
        {
            System.out.println(" -[" + crew.getRole() + "] " + crew.getName());
        }
    }
    
    public void getFlightDetails()
    {
        System.out.println(" -- Flight Details -- ");
        System.out.println("Flight ID: " + flightID);
        System.out.println("Flight Origin: " + origin);
        System.out.println("Flight Destination: " + destination);
        System.out.println("-- Aircraft Details -- ");
        System.out.println("Aircraft Manufacturer: " + craft.getManufacturer());
        System.out.println("Aircraft Type: " + craft.getType());
    }
}
