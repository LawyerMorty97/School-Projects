import java.util.*;

public class SecretNumber
{
    private int secretNumber; // Private generated integer
    
    private Random generator; // Random generation class
    
    // Constructor
    public SecretNumber()
    {
        generator = new Random();
        
        secretNumber = generator.nextInt(50);
    }
    
    public int getSecretNumber()
    {
        return secretNumber;
    }
    
    // Methods
    // Check equality
    public boolean isEqual(int input)
    {
        boolean result = false;
        if (input == secretNumber)
            result = true;
            
        return result;
    }
    // Check High/Low
    public boolean isHighOrLow(int input)
    {
        boolean result = false;
        
        if (input > secretNumber)
            result = true;
        
        return result;
    }
    // Restart
}
