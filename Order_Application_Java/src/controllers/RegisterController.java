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
    
    public int loginInformation(List <String> fieldValues) throws SQLException
    {
        ConnectionClass connection = new ConnectionClass();
        Connection connect = connection.getConnection();
        int user  = 1;
        boolean valid = LoginController.validateUsername(connect,fieldValues.get(1));
        if(!valid)
        {
            user = 0;
        }
        if(valid && !(connect == null))
        {
            PreparedStatement stmt = connect.prepareStatement("INSERT INTO login VALUES"
                    + "(?,?,?,?,?,?,?,?");
            stmt.setString(1, fieldValues.get(6));
            stmt.setString(2, fieldValues.get(7));
            stmt.setString(3, fieldValues.get(8));
            stmt.setString(4, fieldValues.get(9));
            stmt.setString(5, "user");
            stmt.setInt(6, 1);
            java.util.Date date = new java.util.Date();
            java.sql.Date today = new java.sql.Date(date.getTime());
            stmt.setDate(7, today);
            stmt.setInt(8, 0);
            user = stmt.executeUpdate();
            connect.close();
        }
        return user;
    }
}
