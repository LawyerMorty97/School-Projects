import java.io.*;
import java.util.*;
/**
 * Handles the reading of JSON streams
 *
 * @author Mathias Berntsen
 * @version 1.0
 */
public class ParseEngine
{
    public static String ParseFile(String fileToLoad) {
        File theFileToParse = new File(fileToLoad);
        
        String data = "";
        try
        {
            Scanner input = new Scanner(new FileInputStream(fileToLoad));
            
            while(input.hasNext())
            {
                data += input.next();
            }
        }
        catch (IOException e)
        {
            System.out.println("Error parsing file: " + e);
        }
        
        return data;
    }
}
