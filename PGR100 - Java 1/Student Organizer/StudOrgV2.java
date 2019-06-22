import java.util.*;

/**
 * List of students
 * get (method, get student), add (method, add student), show (method, print list), getTotal (method, get total students)
 * 
 * String[] <- ArrayList of Strings
 */

public class StudOrgV2
{
    //Liste av studenter
    private ArrayList<Student> alStudents;
    
    public StudOrgV2()
    {
        alStudents = new ArrayList<Student>();
    }
    
    public void addStudent(String name)
    {
        Student newStudent = new Student(name);
        alStudents.add(newStudent);
    }

    public String getStudentName(int index)
    {
        //alStudents.get(index);
        String result = "";
        if (index >= 0 && index < alStudents.size())
        {
            result = alStudents.get(index).getName();
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
    }

    public int getNumberOfStudents()
    {
        return alStudents.size();
    }
    
    public void printStudent()
    {
        System.out.println("Gathering list of all students.");
        /*for (int i = 0; i < alStudents.size(); i++) {
            String studentName = getStudentName(i);
            System.out.println("  - " + studentName);
        }*/
        
        for(Student student : alStudents)
        {
            System.out.println("  - " + student.getName());
        }
    }
}
