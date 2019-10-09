/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package face_detection;

import com.itextpdf.text.BadElementException;
import com.itextpdf.text.DocumentException;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import order_application_java.YourCart;

/**
 *
 * @author Aditya
 */
public class FaceDetect extends Thread{
    private final String username;
    public FaceDetect(String username)
    {
        this.username = username;
    }
    public String getUsername()
    {
        return username;
    }
    public void run()
    {
        Logger logger = Logger.getLogger(YourCart.class.getName());
        try {
            Runtime.getRuntime().exec("python face_detection.py"); 
            } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            }
        PrintReceipt p = new PrintReceipt(); 
        try {
            p.receipt(this.getUsername());
        } catch (FileNotFoundException ex) {
            Logger.getLogger(FaceDetect.class.getName()).log(Level.SEVERE, null, ex);
        } catch (DocumentException ex) {
            Logger.getLogger(FaceDetect.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(FaceDetect.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(FaceDetect.class.getName()).log(Level.SEVERE, null, ex);
        }
    }        
}
