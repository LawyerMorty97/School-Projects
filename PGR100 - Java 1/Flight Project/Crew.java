import java.util.*;
public class Crew
{
    String name, role;
    private int age;
    
    
    public Crew(String name)
    {
        this.name = name;
        this.role = "";
    }
    
    public String getName()
    {
        return this.name;
    }
    
    public String getRole()
    {
        return this.role;
    }
    
    public int getAge()
    {
        return this.age;
    }
    
}