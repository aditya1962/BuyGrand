/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package order_application_java;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author Aditya
 */
public class PopulateCart {
    public ResultSet populate(String username) throws SQLException
    {
        ConnectionClass cc = new ConnectionClass();
        Connection conn = cc.getConnection();
        ResultSet rs = null;
        if(conn!=null)
        {
            PreparedStatement stmt = conn.prepareStatement ("SELECT userCart.itemID,"+
             "description,quantity, price,totalPrice FROM userCart INNER JOIN item "
                    + "ON userCart.itemID=item.itemID where username=? ");
            stmt.setString(1, username);
            rs = stmt.executeQuery();
        }
        return rs;
    }
    public int getRowCount(String username) throws SQLException
    {
        ResultSet rs = this.populate(username);
        int count = 0;
        while(rs!=null && rs.next())
        {
            count++;
        }
        return count;
    }
}
