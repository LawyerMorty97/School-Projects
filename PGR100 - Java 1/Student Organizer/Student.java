
/**
 * Write a description of class Student here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Student
{
    private String name;
    
    public Student()
    {
        name = "UnidentifiedFlyingObject";
    }
    
    public Student(String name)
    {
        this.name = name;
    }
    
    public String getName()
    {
        return this.name;
    }
}
