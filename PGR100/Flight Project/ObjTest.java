import java.util.*;

public class ObjTest
{
    private ArrayList<String> crewlist;
    
    private ArrayList<Crew> crews;
    
    private ArrayList<Integer> intAR;
    
    private final int count;
    public ObjTest()
    {
        crewlist = new ArrayList<String>();
        crewlist.add("John Doe");
        crewlist.add("Larry Paige");
        crewlist.add("Rolando");
        
        crews = new ArrayList<Crew>();
        Crew c1 = new Crew("Rolando");
        crews.add(c1);
        
        intAR = new ArrayList<Integer>();
        intAR.add(2);
        
        count = crewlist.size();
    }
    
    public void demoArrays()
    {
        int[] luckyNumbers = new int[7];
        Random r = new Random();
        
        int sum = 0;
        String b = "";
        int[] binary = {1,0,0,1};
        
        System.out.println("BIN");
        for (int i = (binary.length - 1); i > -1; i--)
        {
            int val = 2^i;
            System.out.println("i = " + i + " § " + val);
        }
        /*for (int ba : binary) {
            sum += ba^2;
            b += ba;
        }*/
        //System.out.println(b + " | " + sum);
        
        System.out.println("Lucky numbers are:");
        for (int i = 0; i < luckyNumbers.length; i++) {
            luckyNumbers[i] = r.nextInt(256);
            System.out.println("§ " + luckyNumbers[i]);
        }
    }
    
    public void printCrew()
    {
        System.out.println("Crew Members: " + count);
        for (String crewMem : crewlist)
        {
            System.out.println(crewMem);
        }
        
        Iterator it = crewlist.iterator();
        while(it.hasNext()) {
            System.out.println("it: " + it.next());
        }
    }
}
