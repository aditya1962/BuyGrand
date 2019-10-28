/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import order_application_java.ConnectionClass;

/**
 *
 * @author Aditya
 */
public class ConfirmPasswordController {
    private String username;
    private String password;
    private String question;
    private String answer;
    
    public ConfirmPasswordController(String username, String password,String question,String answer)
    {
        this.username = username;
        this.password = password;
        this.question = question;
        this.answer = answer;
    }
    
    public boolean validateFields(Connection connect) throws SQLException
    {
        boolean valid = false;
        PreparedStatement statement = connect.prepareStatement("SELECT secretQuestion,answer FROM login WHERE username = ?");
        statement.setString(1, username);
        ResultSet results = statement.executeQuery();
        while(results.next())
        {
            String questionText = results.getString(0); 
            String answerText = results.getString(1);
            if(questionText.equals(question)&&answerText.equals(answer))
            {
                valid = true;
            }
        }
        return valid;
    }
    
    public int updateUser() throws SQLException
    {
        int updated = 0;
        ConnectionClass connection = new ConnectionClass();
        Connection connect = connection.getConnection();
        boolean exists = LoginController.validateUsername(connect,username);
        if(!exists)
        {
            updated = -1;
        }
        else
        {
           boolean fields = validateFields(connect);
           if(!fields)
           {
               updated = -2;
           }
           else
           {
               PreparedStatement stmt = connect.prepareStatement("UPDATE login SET password = ? WHERE username = ?");
               stmt.setString(1, password);
               stmt.setString(2, username);
               updated = stmt.executeUpdate();
           }
        }
        return updated;
    }
}
