import java.util.*;

public class Client
{
    public void Play()
    {
        SecretNumber engine = new SecretNumber();
        Scanner reader = new Scanner(System.in);
        boolean found = true;
        int attemptsLeft = 5;
        
        System.out.println("Welcome to the game. Please enter any number. (You have 5 attempts, if you guess all wrong, you lose)");
        int entered = reader.nextInt();
        
        while(found) {
            
            if (engine.isEqual(entered))
            {
                System.out.println("Congratulations! You guessed correct.");
                found = false;
            } else {
                boolean highOrLow = engine.isHighOrLow(entered);
                
                if (highOrLow)
                {
                    System.out.println("Your number is higher than the generated number, try again!");
                } else {
                    System.out.println("Your number is lower than the generated number, try again!");
                }
                attemptsLeft--;
                System.out.println("Please enter a new guess!");
                entered = reader.nextInt();
            }
        }
    }
}
