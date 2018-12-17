import java.util.*;
import javafx.scene.control.*;
import javafx.scene.control.Alert.*;

/**
 * Handles game session creation
 *
 * @author Mathias Bertsen
 * @version 1.0
 */
public class Core
{
    // instance variables - replace the example below with your own
    public static ArrayList<State> flags;
    static String mainMenuFlag = "us.png";
    static String mainMenuFlagName = "United States";
    static long startTime = 0;
    static long endTime = 0;
    static int answered = 0;
    static int correct = 0;
    
    final static int scorePerAnswer = 284; // 284 points for each flag the player gets correct (Max score: 14200)
    
    /**
     * Uses the ParseEngine to parse and create all questions.
     * Format of '.flag': flagName,Official Name
     * A semi-colon is the splitter between a State object
     * A comma is the splitter between the filename and official name of a state
    */
    public static void initGame(boolean menuReturn) {
        if (!menuReturn) {
            flags = new ArrayList<>();
            String flagData = ParseEngine.ParseFile("gamedata/flagData.flags");
            flagData = flagData.replaceAll("-", " ");
            ArrayList<String> pre_flags = new ArrayList<>(Arrays.asList(flagData.split(";")));
            for(String stateData : pre_flags)
            {
                String[] stateString = stateData.split(",");
                State state = new State(stateString[1], stateString[0]);
                
                flags.add(state);
            }
        } else {
            int secondsUsed = (int)Math.floor((double)(endTime - startTime) / 1000);
            int minsUsed = (int)Math.floor((double)(endTime - startTime) / 1000 / 60);
            
            Alert alert = new Alert(AlertType.INFORMATION);
            alert.setTitle("Game Session Finished");
            alert.setHeaderText("Well that is a wrap, here's how you did");
            alert.setContentText("Time used: " + minsUsed + " minute(s) " + secondsUsed + " second(s)\nAnswered: " + answered + " out of " + flags.size() + "(" + correct + " Correct)" + "\nScore: " + (correct * scorePerAnswer));
            
            alert.showAndWait();
        }
        
        startTime = 0;
        endTime = 0;
        answered = 0;
        
        Random randomFlag = new Random();
        int index = randomFlag.nextInt(flags.size());
        State chosenState = flags.get(index);
        
        mainMenuFlag = chosenState.getImagePath() + ".png";
        mainMenuFlagName = "(" + chosenState.getName() + ")";
    }
}
