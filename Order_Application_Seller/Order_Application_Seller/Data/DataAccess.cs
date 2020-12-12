using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Order_Application_Seller.Data
{
    public class DataAccess
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        public int validateUser(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from dbo.login where username='" + username + "' and password='" + password + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    int rows = table.Rows.Count;
                    int validate = 0;
                    if (rows > 0)
                    {
                        DataRow row = table.Rows[0];
                        bool passwordVerify = VerifyHash(password, row["password"].ToString());
                        if (passwordVerify == true && row["role"].ToString().Equals("admin"))
                        {
                            validate = 1;
                        }
                    }
                    connection.Close();
                    return validate;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return -99;
            }

        }


        public string getUsersName(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from dbo.loggedUser where username='" + username + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DataRow row = table.Rows[0];
                    string name = row["firstName"].ToString() + " " + row["lastName"].ToString();
                    connection.Close();
                    return name;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }

        }

        public string Hash(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            var hash = pbkdf2.GetBytes(20);

            var hashInByte = new byte[36];
            Array.Copy(salt, 0, hashInByte, 0, 16);
            Array.Copy(hash, 0, hashInByte, 16, 20);

            var base64 = Convert.ToBase64String(hashInByte);
            return base64;
        }

        public Boolean VerifyHash(string password, string hashed)
        {
            var hashInByte = Convert.FromBase64String(hashed);
            var salt = new byte[16];

            Array.Copy(hashInByte, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            var hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                int j = i + 20;
                if (hashInByte[j] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}