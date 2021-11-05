/**
 * @author 19030709-Animesh Singh Basnet, 19031360-Pranamya Sharma, 19032186-Srijana Tamang
 */

package Opticalog.Main;

import java.util.Arrays;
import java.util.List;
import javax.swing.ImageIcon;


public class MainClass {

    public static void main(String[] args) {
        System.setProperty("sun.java2d.uiScale", "1");          // Setting the UI Scale to default 100% resolution 
        
        LoadingScreen();
        
        MainFrame login = new MainFrame();
        login.setIconImage(new ImageIcon("src/Opticalog/Image/opticalog_icon.png").getImage());             // Update the Icon for panel
        login.setVisible(true);
    }
    
    
    
    private static void LoadingScreen(){             // Initialization of splash screen
        SplashScreen startScreen = new SplashScreen();
        startScreen.setIconImage(new ImageIcon("src/Opticalog/Image/opticalog_icon.png").getImage());       // Update the Icon for panel 
        startScreen.setVisible(true);
        
        int count = 3, txtcounter =0;
        String dot = " .";
        List<String> texts = Arrays.asList(         // List of words to be displayed
                "Intializing",
                "Intializing Plugins",
                "Importing Libraries",
                "Importing Database",
                "Checking System",
                "Verifying JDK",
                "Almost Done",
                "Generating UI");
        
        try{
            for(int i = 0; i <101; i++){
                
                Thread.sleep(15);           // Hold the program for 15 microseconds
                startScreen.ProgressBar.setValue(i);                        // Update the percentage bar with each new iteration
                startScreen.percentage_lbl.setText(String.valueOf(i)+"%");  // Update the precentage label with each new iteration
                
                if(i % 13 == 0){            // Every 13th iternation update the panel with new values 
                    count ++;
                    if(count>3)count=0;     // Limit the range of count from 0 upto 3 
                    startScreen.loading_lbl.setText("Loading"+dot.repeat(count));
                    startScreen.randomtxt_lbl.setText(texts.get(txtcounter));
                    txtcounter++;
                }
            }
            Thread.sleep(400);              // Hold the program for 400 microseconds or 0.4 seconds
            startScreen.dispose();          // Close the panel
            
        }catch(Exception e){
            e.printStackTrace();
        }
        
    }
    
}
