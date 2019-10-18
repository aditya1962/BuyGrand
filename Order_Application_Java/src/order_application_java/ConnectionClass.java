/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_application_java;

import com.itextpdf.text.log.Level;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.logging.Logger;

/**
 *
 * @author Aditya
 */
public class ConnectionClass {
    final String USERNAME = "sa";
    final String PASSWORD = "admin123";
    final String CONNECTION_STRING = "jdbc:sqlserver://localhost:1433;databaseName=Order";
    
    public Connection getConnection()
    {
        Connection conn = null;
        try
        {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            conn = DriverManager.getConnection(CONNECTION_STRING, USERNAME, PASSWORD);
        }
        catch(Exception e)
        {
            System.err.println("Could not connect to database");
            Logger.getLogger(ConnectionClass.class.getName()).
                    log(java.util.logging.Level.SEVERE, "Could not connect to database");
        }
        return conn;
    }
}
