using System;
using System.Collections.Generic;
using System.Text;
using GigManagement.DAL;
using GigManagement.Model;
using System.Data;

namespace GigManagement.Service
{
    public  class GigLoginService
    {

        GigLogin login = new GigLogin();
        public bool CreateUserAccount(CreateUser item)
        {
            return login.CreateUserAccount(item);
        }

        public bool CreateArtistAccount(CreateArtist item)
        {
            return login.CreateArtistAccount(item);

        }

        public bool UserLogin(string username, string password)
        {
            return login.UserLogin(username, password);
        }

        public bool ArtistLogin(string username, string password)
        {
            return login.ArtistLogin(username, password);
        }
    }
}
