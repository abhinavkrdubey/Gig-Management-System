using System;
using System.Data;
using System.Data.SqlClient;
using GigManagement.Model;

namespace GigManagement.DAL
{
    public class ArtistDAO
    {
        SqlConnection con = new SqlConnection(@"Data Source=MAITRAYEE1;Initial Catalog=GigManagement;Integrated Security=True");
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;

        DataSet ds = new DataSet();
        string query = null;
        public bool AddGig(CreateGigs creates)
        {
            try
            {
                query = "select * from gigs where gig_id=@gig_id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gig_id", creates.gigid);
                con.Open();
                int record = (int)cmd.ExecuteScalar();
                if (record == 0)
                {
                    query = "insert into gigs values(@gig_id,@gig_name,@artist_name,@venue,@gig_date,@genre,DEFAULT)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@gig_id", creates.gigid);
                    cmd.Parameters.AddWithValue("@gig_name", creates.gig_name);
                    cmd.Parameters.AddWithValue("@artist_name", creates.artist);
                    cmd.Parameters.AddWithValue("@venue", creates.venue);
                    cmd.Parameters.AddWithValue("@gig_date", creates.gigdate);
                    cmd.Parameters.AddWithValue("@genre", creates.genre);
                    cmd.ExecuteNonQuery();
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
        public bool UpdateGigbyVenue(int gigid, string updated_venue)
        {
            try
            {
                query = "select count(*) from gigs where gig_id=@gig_id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gig_id", gigid);
                con.Open();
                int record = (int)cmd.ExecuteScalar();
                if (record == 0)
                {
                    return false;
                }
                con.Close();
                cmd.Parameters.Clear();
                query = "Update gigs set venue = @venue where gig_id = @gig_id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@venue", updated_venue);
                cmd.Parameters.AddWithValue("@gig_id", gigid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
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
        public bool UpdateGigbyDate(int gigid, DateTime date)
        {
            try
            {
                query = "select count(*) from gigs where gig_id=@gig_id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gig_id", gigid);
                con.Open();
                int record = (int)cmd.ExecuteScalar();
                if (record == 0)
                {
                    return false;
                }
                con.Close();
                cmd.Parameters.Clear();
                query = "Update gigs set  gig_date = @gig_date   where gig_id = @gig_id";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@gig_date", date);
                cmd.Parameters.AddWithValue("@gig_id", gigid);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
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
        public bool isCancelled(int gigid, string isCancelled)
        {
            try
            {
                query = "select count(*) from gigs where gig_id=@gig_id";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@gig_id", gigid);
                con.Open();

                int record = (int)cmd.ExecuteScalar();
                if (record == 0)


                {

                    return false;
                }
                con.Close();
                cmd.Parameters.Clear();
                query = "Update gigs set isCancelled = @isCancelled   where gig_id = @gig_id";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@isCancelled",isCancelled);
                cmd.Parameters.AddWithValue("@gig_id", gigid);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
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


        public bool deleteGig(int gig_id)
        {
            try
            {
                query = "select count(*) from gigs where gig_id=@gig_id";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@gig_id", gig_id);
                con.Open();

                int record = (int)cmd.ExecuteScalar();
                if (record == 0)
                {

                    return false;
                }
                con.Close();
                cmd.Parameters.Clear();
                string query1 = "delete from gig_calender where gig_id = @gig_id";
                query = "Delete from gigs where gig_id = @gig_id";
                cmd1 = new SqlCommand(query1, con);
                cmd = new SqlCommand(query, con);
                cmd1.Parameters.AddWithValue("@gig_id", gig_id);
                cmd.Parameters.AddWithValue("@gig_id", gig_id);
                con.Open();
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                return true;

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
