import java.util.*;

/**
 * List of students
 * get (method, get student), add (method, add student), show (method, print list), getTotal (method, get total students)
 * 
 * String[] <- ArrayList of Strings
 */

public class StudentOrganizer
{
    //Liste av studenter
    private ArrayList<String> alStudents;
    //private ArrayList<String> alTempData;
    
    public StudentOrganizer()
    {
        alStudents = new ArrayList<String>();
        //alTempData = new ArrayList<String>();
    }
    
    public void addStudent(String name)
    {
        alStudents.add(name);
    }
    
    public String getStudent(int index)
    {
        //alStudents.get(index);
        String result = "";
        if (index >= 0 && index < alStudents.size())
        {
            result = alStudents.get(index);
        }
        else
        {
            result = "Illegal value";
        }
        
        return result;
    }
    
    public void removeStudent(int index)
    {
        if (index >= 0 && index < alStudents.size())
        {
            alStudents.remove(index);
        }
        else
        {
            
        }
    }
    
    public void removeStudent(String name) // Remove a student by their name, if their name is defined inside the alStudents ArrayList.
    {
        alStudents.remove(name);
    }
    
    public int getNumberOfStudents()
    {
        return alStudents.size();
    }
    
    public void printStudent()
    {
        System.out.println("Gathering list of all students.");
        for (int i = 0; i < alStudents.size(); i++) {
            String studentName = getStudent(i);
            System.out.println("  - " + studentName);
        }
    }
}
