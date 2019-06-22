import java.util.*;

public class DiceClient {
    public void Play() {
        Scanner reader = new Scanner(System.in);
        
        System.out.println("Welcome to roll-a-dice! Enter a amount of times you want to roll the dice");
        System.out.println(" > Rolls: ");
        
        int rollCount = reader.nextInt();
        
        System.out.println("Rolling dice " + rollCount + (rollCount > 1 ? " times." : " time."));
        
        int diceValue = 0;
        Dice ourDice = new Dice();
        for (int i = 0; i < rollCount; i++)
        {
            System.out.println("Potential dice value: " + ourDice.roll().getValue());
        }
        
        System.out.println("You rolled a " + ourDice.getValue() + " through " + rollCount + (rollCount > 1 ? " rolls." : " roll."));
    }
}