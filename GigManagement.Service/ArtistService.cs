using System;
using System.Collections.Generic;
using System.Text;
using GigManagement.DAL;
using GigManagement.Model;


namespace GigManagement.Service
{
    public class ArtistService
    {
        ArtistDAO artist = new ArtistDAO();

        public bool AddGig(CreateGigs item)
        {
            return artist.AddGig(item);
        }

        public bool UpdateGigbyVenue(int gigid, string updated_venue)
        {
            return artist.UpdateGigbyVenue(gigid, updated_venue);
        }

        public bool UpdateGigbyDate(int gigid, DateTime date)
        {
            return artist.UpdateGigbyDate(gigid, date);
        }

        public bool isCancelled(int gigid, string isCancelled)
        {
           return artist.isCancelled(gigid, isCancelled);
        }
        public bool deleteGig(int gig_id)
        {
            return artist.deleteGig(gig_id);
        }

    }
}
