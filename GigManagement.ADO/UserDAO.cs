using System;
using System.Data;
using System.Data.SqlClient;
using GigManagement.Model;

namespace GigManagement.DAL
{
    public class UserDAO
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ACUTTSL\SQLEXPRESS;Initial Catalog=GigManagement;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        DataTable dt = null;
        DataSet ds = new DataSet();
        string query = null;
        public DataRow SearchGigByName(string gig_name)
        {
            try
            {
                query = "Select * from gigs where gig_name='" + gig_name + "'";

                da = new SqlDataAdapter(query, con);
                dt = new DataTable("gigs");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow SearchGigByDate(DateTime gig_date)
        {
            try
            {
                query = "Select * from gigs where gig_date= CONVERT(VARCHAR,'" + gig_date.ToLongDateString() + "',103)";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable("gigs");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow SearchGigByVenue(string venue)
        {
            try
            {
                query = "Select * from gigs where venue='"+venue+"'";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable("gigs");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Getgigs()
        {
            try
            {
                query = "Select * from gigs";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable("gigs");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddToCalender(string username, int gig_id)
        {
            try
            {
               
                    query = "Insert into gig_calender values(@username,@gig_id)";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@gig_id", gig_id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                    
                
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
            public DataTable ViewCalender()
        {
            try
            {
                query = "Select c.username,c.gig_id,g.gig_name,g.artist_name,g.isCancelled,g.gig_date from gigs g, gig_calender c where g.gig_id=c.gig_id";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ViewNames()
        {
            try
            {
                query = "select artist_username from artist_details";
                da = new SqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool followArtist(string uname, string follow_artist)
        {
            try
            {
                query = "select count(*) from following where username=@uname and artist_username=@follow_artist";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@follow_artist", follow_artist);
                int record = (int)cmd.ExecuteScalar();
                if (record == 0)
                {
                    cmd.Parameters.Clear();
                    query = "Insert into following(username,artist_username) values (@uname,@follow_artist)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@uname", uname);
                    cmd.Parameters.AddWithValue("@follow_artist", follow_artist);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }

            }   
             catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
             
        }
        public void DisplayFollows(string UName)
        {
            try
            {
                query = "Select username ,artist_username as follows  from following where username = @UName";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UName", UName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    Console.WriteLine("UserName:{0}\t Follows:{1}", dr["username"], dr["follows"]);

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
    }
}
