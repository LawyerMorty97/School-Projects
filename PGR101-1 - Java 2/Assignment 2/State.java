import java.io.*;
import javafx.scene.image.*;
/**
 * Write a description of class State here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class State
{
    // instance variables - replace the example below with your own
    private String name;
    private String imagePath;
    private Image stateFlag;
    
    private boolean doesHiddenImageExist = false;
    private Image hiddenImage;
    
    public State(String name, String path) {
        this.name = name;
        this.imagePath = path;
        
        File stateImageFile = new File("gamedata/images/" + this.imagePath + ".png");
        stateFlag = new Image(stateImageFile.toURI().toString());
        
        // Check if an image with the hidden state name exists
        File h_stateImageFile = new File("gamedata/images/" + this.imagePath + "_pre.png");
        doesHiddenImageExist = h_stateImageFile.exists();
        if (!doesHiddenImageExist) {
            hiddenImage = stateFlag;
        } else {
            hiddenImage = new Image(h_stateImageFile.toURI().toString());
        }
    }
    
    public String getName() {
        return this.name;
    }
    
    public String getImagePath() {
        return this.imagePath;
    }
    
    public Image getImage() {
        return this.stateFlag;
    }
    
    public Image getHiddenImage() {
        return this.hiddenImage;
    }
}
