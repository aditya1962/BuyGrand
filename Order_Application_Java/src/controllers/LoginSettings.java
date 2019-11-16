/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import order_application_java.ConnectionClass;

/**
 *
 * @author Aditya
 */
public class LoginSettings {
    
    public int updatePassword(String username,String password) throws SQLException, NoSuchAlgorithmException
    {
        ConnectionClass conn = new ConnectionClass();
        Connection con = conn.getConnection();
        PreparedStatement stmt = con.prepareStatement("UPDATE login SET password = ? WHERE username = ?");
        MessageDigest digest = MessageDigest.getInstance("SHA-256");
        digest.update(password.getBytes());
        String hashedPassword = new String(digest.digest());
        stmt.setString(1, hashedPassword);
        stmt.setString(2, username);
        int update = stmt.executeUpdate();
        con.close();
        return update;
    }
    
    public int updateSecret(String username, String question, String answer) throws SQLException
    {
        ConnectionClass conn = new ConnectionClass();
        Connection con = conn.getConnection();
        PreparedStatement stmt = con.prepareStatement("UPDATE login SET secretQuestion = ? AND answer = ? WHERE username = ?");
        stmt.setString(1, question);
        stmt.setString(2, answer);
        stmt.setString(3, username);
        int update = stmt.executeUpdate();
        con.close();
        return update;
    }
}
