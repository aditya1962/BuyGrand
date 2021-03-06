/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.nio.charset.StandardCharsets;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import order_application_java.ConnectionClass;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.sql.ResultSetMetaData;
/**
 *
 * @author Aditya
 */
public class LoginController {
    private String username;
    private String password;
    public LoginController(String username, String password)
    {
        this.username = username;
        this.password = password;
    }
    
    public static boolean validateUsername(Connection conn, String username) throws SQLException
    {
        PreparedStatement statement = conn.prepareStatement("SELECT * FROM loggedUser WHERE username = ?");
        statement.setString(1, username);
        ResultSet results = statement.executeQuery();
        boolean valid = false;
        while(results.next())
        {
            valid = true;
        }
        return valid;
    }
    
    public int login() throws SQLException, NoSuchAlgorithmException
    {
        int valid = 0;
        ConnectionClass connection = new ConnectionClass();
        Connection connect = connection.getConnection();
        if(!(connect==null))
        {
            boolean exists = validateUsername(connect,username);
            if(!exists)
            {
                valid = -1;
            }
            else
            {
                PreparedStatement statement = connect.prepareStatement("SELECT password FROM login WHERE username = ?");
                statement.setString(1, username);
                ResultSet results = statement.executeQuery();
                String passwordHashed = "";
                while(results.next())
                {
                    passwordHashed = results.getString(1);                
                }
                MessageDigest digest = MessageDigest.getInstance("SHA-256");
                byte [] passwordBytes = digest.digest(password.getBytes(StandardCharsets.UTF_8));
                StringBuilder sb = new StringBuilder();
                for(byte b: passwordBytes)
                {
                    sb.append(String.format("%02x", b));
                }
                String hashedPassword = sb.toString();
                if(hashedPassword.equals(passwordHashed))
                {
                    valid = 1;
                }
                else
                {
                    valid = -2;
                }
            }
            connect.close();
        }
        return valid;
    }
}
