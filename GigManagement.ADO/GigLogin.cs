using System;
using System.Data;
using System.Data.SqlClient;
using GigManagement.Model;

namespace GigManagement.DAL
{
    public class GigLogin
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ACUTTSL\SQLEXPRESS;Initial Catalog=GigManagement;Integrated Security=True");
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;

        SqlDataReader dr = null;
        DataSet ds = new DataSet();
        string query = null;
        string query1 = null;
        public bool CreateUserAccount(CreateUser create)
        {
            try
            {
                query = "Select count(*) from user_details where username=@username";
                query1 = "Select count(*) from artist_details where artist_username=@username";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", create.username);
                cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@username", create.username);
                con.Open();
                int record = (int)cmd.ExecuteScalar();
                int record1 = (int)cmd1.ExecuteScalar();
                if (record == 0 && record1 == 0)
                {
                    cmd.Parameters.Clear();
                    query = "Insert into user_details values(@username,@names,@passwords)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", create.username);
                    cmd.Parameters.AddWithValue("@names", create.name);
                    cmd.Parameters.AddWithValue("@passwords", create.password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public bool CreateArtistAccount(CreateArtist creates)
        {
            try
            {
                query1 = "Select count(*) from user_details where username=@username";
                query = "Select count(*) from artist_details where artist_username=@username";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", creates.artist_username);
                cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@username", creates.artist_username);
                con.Open();
                int record = (int)cmd.ExecuteScalar();
                int record1 = (int)cmd1.ExecuteScalar();
                if (record == 0 && record1 == 0)
                {
                    cmd.Parameters.Clear();
                    query = "Insert into artist_details values(@username,@names,@passwords)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", creates.artist_username);
                    cmd.Parameters.AddWithValue("@names", creates.name);
                    cmd.Parameters.AddWithValue("@passwords", creates.password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UserLogin(string username, string password)
        {
            if(username == null || password == null)
            {
                return false;
            }
            else if(username == null && password == null)
            {
                return false;
            }
            else
            {
                query = "select * from user_details where username=@username and passwords=@password";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                cmd.ExecuteScalar();
                try
                {

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public bool ArtistLogin(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }
            else if (username == null && password == null)
            {
                return false;
            }
            else
            {
                query = "select * from artist_details where artist_username=@username and passwords=@password";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                cmd.ExecuteScalar();
                try
                {

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
