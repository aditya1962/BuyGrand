/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_frames;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import javax.swing.border.MatteBorder;
import order_application_java.ConnectionClass;

/**
 *
 * @author Aditya
 */
public class ProductDisplay extends JPanel {
    
    //width of the panel and inside panels
    private final int width;
    
    //height of inside panels
    private final int HEIGHT = 100;
    private String subcategory;
    
    public ProductDisplay(int width,String subcategory)
    {
        this.width = width;
        this.subcategory = subcategory;
        try {
            JPanel panel = components();
            JScrollPane scrollPane = new JScrollPane(panel,ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS,
            ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);
            scrollPane.setPreferredSize(new Dimension(800,800));
            scrollPane.getViewport().revalidate();
            add(scrollPane);
        } catch (SQLException ex) {
            Logger.getLogger(ProductDisplay.class.getName()).log(Level.SEVERE, null, ex);
        }
        
    }
    
    public int[] getPanelInsets()
    {
        int top = 5, left = 0, bottom = 5, right = 5;
        int [] insets = {top,left,bottom,right};
        return insets;
    }
    
    public ResultSet getItem() throws SQLException
    {
        ConnectionClass connection = new ConnectionClass();
        Connection connect = connection.getConnection();
        PreparedStatement statement = connect.prepareStatement("SELECT imagePath,"
                + "name,price,discount FROM item INNER JOIN itemCategory "
                + "ON item.itemID = itemCategory.itemID WHERE subcategory = ?");
        statement.setString(1, subcategory);
        ResultSet results = statement.executeQuery();
        connect.close();
        return results;
    }
    
    public int getCount() throws SQLException
    {
        int count  = 0; 
        ResultSet results = getItem();
        while(results.next())
        {
            count++;
        }
        return count;
    }
    
    public final JPanel components() throws SQLException
    {
        this.setLayout(new BoxLayout(this,BoxLayout.Y_AXIS));
        
        GridBagConstraints gbc = new GridBagConstraints();
        JPanel panel = new JPanel();
        int [] panelInsetValues = getPanelInsets();
        int panelHeight = getCount()*(HEIGHT+panelInsetValues[0] + panelInsetValues[2]);
        panel.setPreferredSize(new Dimension(width,panelHeight));
        ResultSet resultSets = getItem(); 
        while(resultSets.next())    
        {
            JPanel panelInside  = new JPanel();
            panelInside.setLayout(new GridBagLayout());
            
            gbc.insets = new Insets(panelInsetValues[0],panelInsetValues[1],
                    panelInsetValues[2],panelInsetValues[3]);
            panelInside = firstColumn(gbc,panelInside,resultSets.getString(1));
            panelInside = secondColumn(gbc,panelInside,resultSets.getString(2),resultSets.getInt(3));
            panelInside = quantityComponents(gbc,panelInside);
            panelInside = discountComponents(gbc,panelInside,resultSets.getDouble(4));
            panelInside.setPreferredSize(new Dimension(width,HEIGHT));
            panel.add(panelInside);
            panelInside.setBorder(new MatteBorder(0,0,1,0,Color.GRAY));
            panel.setBorder(new MatteBorder(0,0,1,0,Color.GRAY));
            this.add(panel);
        }  
        return panel;
    }
    public static JPanel firstColumn(GridBagConstraints gbc, JPanel panelInside, String path)
    {
        //placing the icon
        JLabel icon = new JLabel(path);
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridheight = 2;
        gbc.fill = GridBagConstraints.VERTICAL;
        panelInside.add(icon,gbc);
        return panelInside;
    }
    public JPanel secondColumn(GridBagConstraints gbc, JPanel panelInside, String name, int price)
    {
        //placing the product name
        JButton product = new JButton(name);
        gbc.gridx = 1;
        gbc.gridy = 0;
        panelInside.add(product,gbc);
        
        //placing the price label name
        JLabel priceLbl = new JLabel("Price : ");
        gbc.gridx = 1;
        gbc.gridy = 2;
        panelInside.add(priceLbl,gbc);
        
        //placing the price label name
        JLabel priceValue = new JLabel(String.valueOf(price));
        gbc.gridx = 2;
        gbc.gridy = 3;
        panelInside.add(priceValue,gbc);
        
        return panelInside;
    }
    public JPanel quantityComponents(GridBagConstraints gbc, JPanel panelInside)
    {
        //placing the quantity label name
        JLabel quantity = new JLabel("Quantity");
        gbc.gridx = 7;
        gbc.gridy = 0;
        panelInside.add(quantity,gbc);
        
        //placing the minus button
        JButton reduceQuantity = new JButton("-");
        gbc.gridx = 8;
        gbc.gridy = 0;
        panelInside.add(reduceQuantity,gbc);
        
        //placing the quantity label 
        JLabel quantityLabel = new JLabel("1");
        gbc.gridx = 9;
        gbc.gridy = 0;
        panelInside.add(quantityLabel,gbc);
        
        //placing the minus button
        JButton addQuantity = new JButton("+");
        gbc.gridx = 10;
        gbc.gridy = 0;
        panelInside.add(addQuantity,gbc);
        
        return panelInside;
    }
    
    public JPanel discountComponents(GridBagConstraints gbc, JPanel panelInside, double discount)
    {
        //placing the discount label name
        JLabel discountLabel = new JLabel("Discount : ");
        gbc.gridx = 7;
        gbc.gridy = 3;
        panelInside.add(discountLabel,gbc);
        
        //placing the discount value
        JLabel discountValue = new JLabel(String.valueOf(discount));
        gbc.gridx = 8;
        gbc.gridy = 3;
        panelInside.add(discountValue,gbc);
        
        return panelInside;
    }
}
