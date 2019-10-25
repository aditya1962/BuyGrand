/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_frames;

/**
 *
 * @author Aditya
 */
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
 
import java.awt.Dimension;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import static sun.misc.ClassFileTransformer.add;
 
public class NewMain {
    
    public JPanel components()
    {
        JButton jb1 = new JButton("Button 1 -");        
        JButton jb2 = new JButton("Button 2 --------");
        
         
        // Define the panel to hold the buttons 
        JPanel panel1 = new JPanel();
        
         
        // Set up the BoxLayout
        BoxLayout layout1 = new BoxLayout(panel1, BoxLayout.Y_AXIS);
        
        panel1.setLayout(layout1);
//       
        
        for(int i = 0; i < 2; i++)
        {
            System.out.println(i);
        panel1.add(jb1);
        panel1.add(jb2);
        }
        return panel1;
    }
 
    public static void main(String[] args) {
        // Create and set up a frame window
        JFrame.setDefaultLookAndFeelDecorated(true);
        JFrame frame = new JFrame("BoxLayout Example Alignment");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
         
//        // Define new buttons with different width on help of the ---
//        JButton jb1 = new JButton("Button 1 -");        
//        JButton jb2 = new JButton("Button 2 --------");
//        
//         
//        // Define the panel to hold the buttons 
//        JPanel panel1 = new JPanel();
//        
//         
//        // Set up the BoxLayout
//        BoxLayout layout1 = new BoxLayout(panel1, BoxLayout.Y_AXIS);
//        
//        panel1.setLayout(layout1);
////       
//        
//        for(int i = 0; i < 2; i++)
//        {
//            System.out.println(i);
//        panel1.add(jb1);
//        panel1.add(jb2);
        //}
        
//      
        JPanel panel1 = new ProductDisplay(450,"abc").components();
        frame.add(panel1);
//        
         JScrollPane scrollPane = new JScrollPane(panel1,ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED,
        ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        scrollPane.setPreferredSize(new Dimension(800,800));
        scrollPane.getViewport().revalidate();
        frame.add(scrollPane);
        // Set the window to be visible as the default to be false
        frame.pack();
        frame.setVisible(true);
         
    }
 
}