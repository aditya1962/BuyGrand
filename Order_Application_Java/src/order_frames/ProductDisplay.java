/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_frames;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import javax.swing.border.MatteBorder;

/**
 *
 * @author Aditya
 */
public class ProductDisplay extends JPanel {
    
    private final int width;
    
    public ProductDisplay(int width,String subcategory)
    {
        this.width = width;
        JPanel panel = components();
        //JScrollPane scrollPane = new JScrollPane(panel,ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS,
        //ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        //scrollPane.setPreferredSize(new Dimension(800,800));
        //scrollPane.getViewport().revalidate();
        //add(scrollPane);
    }
    
    
    public final JPanel components()
    {
        this.setLayout(new BoxLayout(this,BoxLayout.Y_AXIS));
        //this.setLayout(new FlowLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        JPanel panel = new JPanel();
        
        for(int i = 0; i< 8; i++)
        {           
            JPanel panelInside  = new JPanel();
            panelInside.setLayout(new GridBagLayout());
            gbc.insets = new Insets(5,5,5,5);
            panelInside = firstColumn(gbc,panelInside);
            panelInside = secondColumn(gbc,panelInside);
            panelInside = quantityComponents(gbc,panelInside);
            panelInside.setPreferredSize(new Dimension(width,100));
            panel.add(panelInside);
            panel.setBorder(new MatteBorder(0,0,1,0,Color.GRAY));
            this.add(panel);
        }  
        return panel;
    }
    public static JPanel firstColumn(GridBagConstraints gbc, JPanel panelInside)
    {
        //placing the icon
        JLabel icon = new JLabel("icon");
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridheight = 2;
        gbc.fill = GridBagConstraints.VERTICAL;
        panelInside.add(icon,gbc);
        return panelInside;
    }
    public JPanel secondColumn(GridBagConstraints gbc, JPanel panelInside)
    {
        //placing the product name
        JButton name = new JButton("Product name");
        gbc.gridx = 1;
        gbc.gridy = 0;
        panelInside.add(name,gbc);
        
        //placing the price label name
        JLabel price = new JLabel("Price : ");
        gbc.gridx = 1;
        gbc.gridy = 2;
        panelInside.add(price,gbc);
        
        //placing the price label name
        JLabel priceValue = new JLabel("price");
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
    
    public JPanel discountComponents(GridBagConstraints gbc, JPanel panelInside)
    {
        //placing the discount label name
        JLabel discount = new JLabel("Discount : ");
        gbc.gridx = 7;
        gbc.gridy = 3;
        panelInside.add(discount,gbc);
        
        //placing the discount value
        JLabel discountValue = new JLabel("discount");
        gbc.gridx = 8;
        gbc.gridy = 3;
        panelInside.add(discountValue,gbc);
        
        return panelInside;
    }
}
