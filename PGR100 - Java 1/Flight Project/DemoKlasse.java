import java.util.*;

public class DemoKlasse
{
    int int1, int2;
    String string1, string2;
    public DemoKlasse()
    {
        int1 = 10;
        int2 = 20;
        
        string1 = new String("Hi");
        string2 = new String("Hi");
    }
    
    public void demoSammenligning()
    {
        System.out.println("Test 1: " + (string1 == string2));
        System.out.println("Test 2: " + string1.equals(string2));
        System.out.println("Test 3: " + ("hi" == "hi"));
    }
    
    public void demoLoop()
    {
        ArrayList<String> ar = new ArrayList<String>();
        ar.add("Hi?");
        ar.add("Hi.");
        ar.add("Bye.");
        
        // for each loop
        for(String s : ar)
        {
            System.out.println("ar: " + s);
        }
        
        // for-loop
        for (int i = 0; i < ar.size(); i++)
        {
            System.out.println("forLOOP: [i" + i + "]=" + ar.get(i));
        }
        
        // while
        int currN = 0;
        while(currN < ar.size())
        {
            System.out.println(ar.get(currN));
            currN++;
        }
        
        Iterator<String> itar = ar.iterator();
        while(itar.hasNext()) {
            System.out.println("itar1: " + itar.next());
        }
    }
}
