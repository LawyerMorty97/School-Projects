import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
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
import javafx.scene.control.*;
import javafx.scene.control.Alert.*;

/**
 * Write a description of class MenuUI here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class MenuScene
{
    static ImageView mainImage;
    // instance variables - replace the example below with your own
    public static void createMenu(Stage mainStage, String flag, String state) {
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
        
        Label labelTitle = new Label("Guess The 50 States " + state);
        labelTitle.setStyle("-fx-text-fill: #ffffff; -fx-font-size: 18px;");
        //labelTitle.setStyle("-fx-text-fill: #ffffff;");
        labelTitle.setLayoutX(156);
        labelTitle.setLayoutY(165);
        labelTitle.setAlignment(Pos.CENTER);
        labelTitle.setTextAlignment(TextAlignment.CENTER);
        labelTitle.setPrefSize(287, 35);
        centerPane.getChildren().add(labelTitle);
        
        // The main image that is displayed in our game menu (Randomly chosen on runtime similar to how Minecraft had the random text on load)
        mainImage = new ImageView();
        File usFlagFile = new File("gamedata/images/" + flag);
        Image usFlag = new Image(usFlagFile.toURI().toString());
        mainImage.setImage(usFlag);
        mainImage.setLayoutX(156);
        mainImage.setLayoutY(14);
        //mainImage.setPrefSize(287, 150);
        mainImage.setFitWidth(287);
        mainImage.setFitHeight(150);
        //mainImage.setBlendMode(BlendMode.COLOR_BURN);
        
        centerPane.getChildren().add(mainImage);
        
        // Get Started Button
        Button btnStart = new Button("Get Started");
        btnStart.setStyle("-fx-background-color: #222266;-fx-text-fill: #ffffff");
        btnStart.setLayoutX(200);
        btnStart.setLayoutY(72);
        btnStart.setPrefSize(200, 40);
        bottomPane.getChildren().add(btnStart);
        
        // Quit Button
        Button btnQuit = new Button("Quit Game");
        btnQuit.setStyle("-fx-background-color: #af0000;-fx-text-fill: #ffffff");
        btnQuit.setLayoutX(508);
        btnQuit.setLayoutY(150);
        btnQuit.setPrefSize(78, 21);
        bottomPane.getChildren().add(btnQuit);
        
        // Get Started Action
        btnStart.setOnAction(e->{
            Collections.shuffle(Core.flags);
            GameScene.createGameScene(mainStage);
        });
        
        // Quit Action
        btnQuit.setOnAction(e->{
            //System.exit(0);
            Alert alert = new Alert(AlertType.CONFIRMATION);
            alert.setTitle("");
            alert.setHeaderText("Quitting so soon?");
            alert.setContentText("Are you sure you wish to quit the game? Why not have another shot?");
            
            Optional<ButtonType> result = alert.showAndWait();
            if (result.get() == ButtonType.OK)
            {
                System.exit(0);
            }
        });
        
        
        BorderPane pane = new BorderPane();
        pane.setPrefSize(600, 400);
        pane.setStyle("-fx-background-color: #505F50");
        
        pane.setCenter(centerPane);
        pane.setBottom(bottomPane);
        
        Scene menuScene = new Scene(pane, 600, 400);
        mainStage.setTitle("Test");
        mainStage.setScene(menuScene); // Set the scene of GUI to focus on our menu
        
        mainStage.show();
    }
}
