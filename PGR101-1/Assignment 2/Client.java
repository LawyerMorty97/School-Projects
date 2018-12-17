import javafx.application.Application;
import javafx.stage.*;
import java.util.*;

/**
 * Instances the game
 *
 * @author Mathias Berntsen
 * @version 1.0
 */
public class Client extends Application
{
    @Override
    public void start(Stage stage) throws Exception
    {
        Core.initGame(false);
        
        stage.initStyle(StageStyle.UNDECORATED);
        MenuScene.createMenu(stage, Core.mainMenuFlag, Core.mainMenuFlagName); // Remove the ability to resize and maximize
    }
}
