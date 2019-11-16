/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;
import order_application_java.ConnectionClass;

/**
 *
 * @author Aditya
 */
public class PersonalSettings {
    
    public int updatePersonalDetails(ArrayList <String> values) throws SQLException
    {   
       String username = "username"; //temporary value
       ConnectionClass conn = new ConnectionClass();
       Connection con = conn.getConnection();
       int update = 0;
       if(!(con==null))
       {
           PreparedStatement stmt = con.prepareStatement("UPDATE loggedUser SET"
                   + "firstName = ?, lastName = ?, address = ?, phoneNumber = ?"
                   + ",emailAddress = ? WHERE username = ?");
           stmt.setString(1, values.get(0));
           stmt.setString(2, values.get(1));
           stmt.setString(3, values.get(2));
           stmt.setString(4, values.get(3));
           stmt.setString(5, values.get(4));
           stmt.setString(6, username);
           update = stmt.executeUpdate();
       }
       return update;
    }
}
