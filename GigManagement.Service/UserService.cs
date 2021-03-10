using System;
using System.Collections.Generic;
using System.Text;
using GigManagement.DAL;
using GigManagement.Model;
using System.Data;

namespace GigManagement.Service
{
    public class UserService
    {
        UserDAO user = new UserDAO();

        public DataRow SearchGigByName(string gig_name)
        {
            return user.SearchGigByName(gig_name);
        }

        public DataRow SearchGigByDate(DateTime gig_date)
        {
            return user.SearchGigByDate(gig_date);
        }
        public DataRow SearchGigByVenue(string venue)
        {
            return user.SearchGigByVenue(venue);
        }
        public DataTable Getgigs()
        {
            return user.Getgigs();
        }

        public bool AddToCalender(string username, int gig_id)
        {
            return user.AddToCalender(username, gig_id);
        }

        public DataTable ViewCalender()
        {
            return user.ViewCalender();
        }
        public bool followArtist(string UName, string AName)
        {
            return user.followArtist(UName, AName);
        }
        public void DisplayFollows(string UName)
        {
            user.DisplayFollows(UName);
        }
        public DataTable ViewNames()
        {
            return user.ViewNames();
        }






    }
}
