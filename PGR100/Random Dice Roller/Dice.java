import java.util.*;

public class Dice {
    private int diceValue;
    private Random generator;
    
    public Dice()
    {
        generator = new Random();
    }
    
    public Dice roll() {
        diceValue = generator.nextInt(7);
        return this;
    }
    
    public int getValue() {
        return this.diceValue;
    }
}