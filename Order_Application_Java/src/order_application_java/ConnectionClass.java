/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_application_java;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Aditya
 */
public class ConnectionClass {
    final String USERNAME = "sa";
    final String PASSWORD = "password@123";
    final String CONNECTION_STRING = "jdbc:sqlserver://localhost:1433;databaseName=BuyGrand";
    
    public Connection getConnection()
    {
        Connection conn = null;
        try
        {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            conn = DriverManager.getConnection(CONNECTION_STRING, USERNAME, PASSWORD);
        }
        catch(SQLException ex)
        {
            System.err.println("Could not connect to database");
            Logger.getLogger(ConnectionClass.class.getName()).
                    log(java.util.logging.Level.SEVERE, "Could not connect to database");
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(ConnectionClass.class.getName()).log(Level.SEVERE, null, ex);
        }
        return conn;
    }
}
