public class Aircraft
{
    String type, manufacturer;
    int capacity;
    
    public Aircraft()
    {
        this.manufacturer = "Airbus";
        this.type = "A380";
        this.capacity = 390;
    }
    
    public Aircraft(String manufacturer, String type, int capacity)
    {
        this.manufacturer = manufacturer;
        this.type = type;
        this.capacity = capacity;
    }
    
    public String getManufacturer()
    {
        return this.manufacturer;
    }
    
    public String getType()
    {
        return this.type;
    }
    
    public int getCapacity()
    {
        return this.capacity;
    }
}
