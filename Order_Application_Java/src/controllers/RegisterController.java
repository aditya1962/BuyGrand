/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import order_application_java.ConnectionClass;

/**
 *
 * @author Aditya
 */
public class RegisterController {
        
    public int personalInformation(List <String> fieldValues) throws SQLException
    {
        ConnectionClass connection = new ConnectionClass();
        Connection connect = connection.getConnection();
        int user  = 0;
        if(!(connect == null))
        {
            PreparedStatement stmt = connect.prepareStatement("INSERT INTO loggedUser VALUES"
                    + "(?,?,?,?,?,?,?,?)");
            stmt.setString(1, fieldValues.get(0));
            stmt.setString(2, fieldValues.get(1));
            stmt.setString(3, fieldValues.get(2));
            stmt.setString(4, fieldValues.get(3));
            stmt.setString(5, fieldValues.get(4));
            stmt.setString(6, fieldValues.get(5));
            stmt.setString(7, fieldValues.get(6));
            stmt.setString(8, fieldValues.get(7));
            user = stmt.executeUpdate();
            connect.close();
        }
        return user;
    }
    
    public int verifyUser(String username)
    { 
        int user = 0;
        try {
            ConnectionClass connection = new ConnectionClass();
            Connection connect = connection.getConnection();
            boolean valid = LoginController.validateUsername(connect,username);
            if(valid)
            {
                user = 1;
            }
        } catch (SQLException ex) {
            Logger.getLogger(RegisterController.class.getName()).log(Level.SEVERE, null, ex);
        }
        return user;
    }
    
    public int loginInformation(List <String> fieldValues) 
    {
        int inserted = 0;
        try
        {
            ConnectionClass connection = new ConnectionClass();
            Connection connect = connection.getConnection();
            PreparedStatement stmt = connect.prepareStatement("INSERT INTO login VALUES"
                    + "(?,?,?,?,?,?,?,?)");
            stmt.setString(1, fieldValues.get(0));
            stmt.setString(2, fieldValues.get(1));
            stmt.setString(3, fieldValues.get(2));
            stmt.setString(4, fieldValues.get(3));
            stmt.setString(5, "user");
            stmt.setInt(6, 1);
            java.util.Date date = new java.util.Date();
            java.sql.Date today = new java.sql.Date(date.getTime());
            stmt.setDate(7, today);
            stmt.setInt(8, 0);
            inserted = stmt.executeUpdate();
            connect.close();
        }
        catch(SQLException e)
        {
            Logger.getLogger(RegisterController.class.getName()).log(Level.SEVERE, null, e);
        }
        return inserted;
    }
}
