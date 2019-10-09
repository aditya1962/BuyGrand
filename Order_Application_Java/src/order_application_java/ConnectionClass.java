/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_application_java;

import java.sql.Connection;
import java.sql.DriverManager;

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
            e.printStackTrace();
        }
        return conn;
    }
}
