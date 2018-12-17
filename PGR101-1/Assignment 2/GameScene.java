import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.control.ProgressBar;
import javafx.scene.image.*;

import javafx.scene.effect.*;
import javafx.geometry.*;
import javafx.scene.layout.*;
import javafx.scene.text.*;

import javafx.stage.Stage;
import javafx.geometry.Pos;

import java.io.*;
import java.util.*;
import java.util.concurrent.*;

/**
 * Where all the game logic is
 *
 * @author Mathias Berntsen
 * @version 1.0
 */
public class GameScene
{
    static Stage mstage;
    static ImageView mainImage;
    static TextField field;
    static State currentState;
    static Button btnQuit;
    
    static Label progressLabel;
    static ProgressBar progressBar;
    
    /**
     * This method handles the creation of the User Interface
    */
    public static void createGameScene(Stage mainStage) {
        mstage = mainStage;
        /*Pane pane = new Pane();
        pane.setMinSize(600, 400);
        pane.setStyle("-fx-background-color: #505F50;");
        
        Button btnQuit = new Button("Quit Game");
        btnQuit.setStyle("-fx-background-color: #af0000;-fx-text-fill: #ffffff");
        btnQuit.setLayoutX(508);
        btnQuit.setLayoutY(365);
        btnQuit.setPrefSize(78, 21);
        
        pane.getChildren().add(btnQuit);
        pane.getChildren().add(labelCopy);*/
        
        Pane centerPane = new Pane();
        Pane bottomPane = new Pane();
        
        Label labelCopy = new Label("Designed and Coded by Mathias Berntsen");
        labelCopy.setStyle("-fx-text-fill: #ffffff;");
        labelCopy.setLayoutX(14);
        labelCopy.setLayoutY(170);
        bottomPane.getChildren().add(labelCopy);
        
        Label labelTitle = new Label("Which state is this?");
        labelTitle.setStyle("-fx-text-fill: #ffffff; -fx-font-size: 18px;");
        //labelTitle.setStyle("-fx-text-fill: #ffffff;");
        labelTitle.setLayoutX(156);
        labelTitle.setLayoutY(165);
        labelTitle.setAlignment(Pos.CENTER);
        labelTitle.setTextAlignment(TextAlignment.CENTER);
        labelTitle.setPrefSize(287, 35);
        centerPane.getChildren().add(labelTitle);
        
        currentState = Core.flags.get(Core.answered);
        
        // The main image that is displayed in our game menu (Randomly chosen on runtime similar to how Minecraft had the random text on load)
        mainImage = new ImageView();
        /*File usFlagFile = new File("gamedata/images/" + stateArray.getImagePath());
        Image usFlag = new Image(usFlagFile.toURI().toString());*/
        Image usFlag = currentState.getHiddenImage();
        mainImage.setImage(usFlag);
        mainImage.setLayoutX(156);
        mainImage.setLayoutY(14);
        mainImage.setFitWidth(287);
        mainImage.setFitHeight(150);
        //mainImage.setBlendMode(BlendMode.COLOR_BURN);
        centerPane.getChildren().add(mainImage);
        
        // Progress Label and Bar
        progressLabel = new Label(Core.answered + "/" + Core.flags.size());
        progressLabel.setLayoutX(500);
        progressLabel.setLayoutY(14);
        progressLabel.setPrefSize(86, 21);
        
        centerPane.getChildren().add(progressLabel);
        
        // Input
        field = new TextField();
        field.setLayoutX(200);
        field.setLayoutY(73);
        field.setPrefSize(200, 21);
        bottomPane.getChildren().add(field);
        
        // Submit
        Button btnSubmit = new Button("Submit");
        btnSubmit.setStyle("-fx-background-color: #ffffff; -fx-text-fill: #000000;");
        btnSubmit.setLayoutX(257);
        btnSubmit.setLayoutY(100);
        btnSubmit.setPrefSize(86, 21);
        bottomPane.getChildren().add(btnSubmit);
        btnSubmit.setOnAction(e->{
            testInput();
        });
        
        // Quit Button
        btnQuit = new Button("Stop");
        btnQuit.setStyle("-fx-background-color: #af0000;-fx-text-fill: #ffffff");
        btnQuit.setLayoutX(508);
        btnQuit.setLayoutY(150);
        btnQuit.setPrefSize(78, 21);
        bottomPane.getChildren().add(btnQuit);
        
        // Quit Action
        btnQuit.setOnAction(e->{
            Core.endTime = System.currentTimeMillis();
            long timePassed = Core.endTime - Core.startTime;
            //System.out.println("Time used: " + timePassed);
            Core.initGame(true);
            MenuScene.createMenu(mainStage, Core.mainMenuFlag, Core.mainMenuFlagName);
        });
        
        
        BorderPane pane = new BorderPane();
        pane.setPrefSize(600, 400);
        pane.setStyle("-fx-background-color: #555555");
        
        pane.setCenter(centerPane);
        pane.setBottom(bottomPane);
        
        Scene menuScene = new Scene(pane, 600, 400);
        mainStage.setTitle("Test");
        mainStage.setScene(menuScene); // Set the scene of GUI to focus on our menu
        
        mainStage.show();
        Core.startTime = System.currentTimeMillis();
    }
    
    /**
     * Handles getting the next state and viewing it in the window
     */
    static void nextQuestion()
    {
        currentState = Core.flags.get(Core.answered);
        field.setText("");
        mainImage.setImage(currentState.getHiddenImage());
        mainImage.setBlendMode(BlendMode.SRC_OVER);
    }
    
    /**
     * Does input checking so we can see if the player gave a correct answer or not
     */
    static void testInput()
    {
        String entered = field.getText();
        
        System.out.println(entered + " = " + currentState.getName());
        if (entered.equals(currentState.getName())) {
            Core.correct++;
            mainImage.setBlendMode(BlendMode.GREEN);
        } else {
            mainImage.setBlendMode(BlendMode.COLOR_BURN);
        }
        
        mainImage.setImage(currentState.getImage());
        Core.answered++;
        
        progressLabel.setText(Core.answered + "/" + Core.flags.size());
        
        // Check if the game is done
        if (Core.answered == Core.flags.size()) {
            System.out.println("DONE");
            //btnQuit.fire();
            Core.endTime = System.currentTimeMillis();
            Core.initGame(true);
            MenuScene.createMenu(mstage, Core.mainMenuFlag, Core.mainMenuFlagName);
            return;
        }
        
        nextQuestion();
    }
}
