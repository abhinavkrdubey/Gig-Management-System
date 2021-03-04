using System;
using System.Collections.Generic;
using System.Text;

namespace GigManagement.Model
{
    public class CreateGigs
    {
        public int gigid { get; set; }
        public string gig_name { get; set; }
        public DateTime gigdate { get; set; }
        public string venue { get; set; }
        public string artist { get; set; }
        public string genre { get; set; }
        public string isCancelled { get; set; }

        
    }
}
