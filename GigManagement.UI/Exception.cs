using System;
using System.Collections.Generic;
using System.Text;

namespace GigManagement.UI
{
    class UserExistsException : Exception
    {
        public UserExistsException() : base(String.Format("User Already Exists, Please choose a new username"))
        {

        }
    }
    class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(String.Format("User not found kindly enter the correct details"))
        {

        }
    }
    class InvalidGigNameException : Exception
    {
        public InvalidGigNameException() : base (String.Format("Gig Name Not Found In The Data Base"))
        {

        }
    }
    class InvalidGigIdExcpetion : Exception
    {
        public InvalidGigIdExcpetion() : base (String.Format("Gid Id Not Found In The Data Base"))
        {

        }
    }
}
