import java.util.Scanner;

public class ConsoleInput {
    private Scanner reader;
    
    public ConsoleInput() {
        reader = new Scanner(System.in);
    }
    
    public int readInt() {
        return reader.nextInt();
    }
}