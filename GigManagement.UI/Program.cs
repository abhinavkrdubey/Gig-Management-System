using System;
using System.Data;
using System.Text.RegularExpressions;
using GigManagement.DAL;

namespace GigManagement.UI
{
    class Program
    {

        static void Main(string[] args)
        {
            GigLogin prog = new GigLogin();
            ArtistDAO ado = new ArtistDAO();
            UserADO user = new UserADO();
            string uname = null;
            string aname = null;
            bool isWholeFalse = true;
            while(isWholeFalse)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Please select from the following options:");
                Console.WriteLine("1. To create account");
                Console.WriteLine("2. Login to your account");
                Console.WriteLine("3. To exit from the applicatom");
                Console.WriteLine("--------------------------------------------");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Register as 1.user or 2.artist");
                        int ch2 = Convert.ToInt32(Console.ReadLine());
                        bool isFalse = true;
                        while (isFalse)
                        {
                            switch (ch2)
                            {
                                case 1:
                                    Console.WriteLine("Enter your username");
                                    string username = Console.ReadLine();
                                    Console.WriteLine("Enter your name");
                                    string name = Console.ReadLine();
                                    string password;
                                    do
                                    {
                                        Console.WriteLine("Enter your password(Must Contain a number)");
                                        password = Console.ReadLine();
                                    } while (!IsValidPassword(password));
                                    try
                                    {
                                        if (prog.CreateUserAccount(new Model.CreateUser() { username = username, name = name, password = password }))
                                        {
                                            Console.WriteLine("Account Created! Welcome, {0}", name);
                                            isFalse = false;
                                        }
                                        else
                                        {
                                            throw new UserExistsException();
                                        }
                                    }
                                    catch (UserExistsException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Enter your username");
                                    string username1 = Console.ReadLine();
                                    Console.WriteLine("Enter your name");
                                    string name1 = Console.ReadLine();
                                    string password1;
                                    do
                                    {
                                        Console.WriteLine("Enter your password(Must Contain a number)");
                                        password1 = Console.ReadLine();
                                    } while (!IsValidPassword(password1));
                                    try
                                    {
                                        if (prog.CreateArtistAccount(new Model.CreateArtist() { artist_username = username1, name = name1, password = password1 }))
                                        {
                                            Console.WriteLine("Account Created! Welcome, {0}", name1);
                                            isFalse = false;
                                        }
                                        else
                                        {
                                            throw new UserExistsException();
                                        }
                                    }
                                    catch (UserExistsException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Login as \n 1. User \n 2. Artist");
                        int ch3 = Convert.ToInt32(Console.ReadLine());
                        switch (ch3)
                        {
                            case 1:
                                Console.WriteLine("Enter your username:");
                                string username2 = Console.ReadLine();
                                Console.WriteLine("Enter your password");
                                string password2 = Console.ReadLine();
                                try
                                {
                                    if (prog.UserLogin(username2, password2))
                                    {
                                        Console.WriteLine("Login Success");
                                        uname = username2;
                                        bool isUserQuit = true;
                                        while(isUserQuit)
                                        {
                                            Console.WriteLine("--------------------------------------------");
                                            Console.WriteLine("Welcome {0}, Choose one of the following:", uname);
                                            Console.WriteLine("1. View a Gig");
                                            Console.WriteLine("2. Search a gig");
                                            Console.WriteLine("3. Add Gig to calender");
                                            Console.WriteLine("4. View your Calender");
                                            Console.WriteLine("5. Follow an artist");
                                            Console.WriteLine("6. View Following List");
                                            Console.WriteLine("7. Log out");
                                            Console.WriteLine("--------------------------------------------");
                                            int user_choice = Convert.ToInt32(Console.ReadLine());
                                            switch (user_choice)
                                            {
                                                case 1:
                                                    Console.WriteLine("Here are your following Gigs");
                                                    DataTable dt = user.Getgigs();
                                                    foreach (DataRow r in dt.Rows)
                                                    {
                                                        Console.WriteLine($"GigName:{r["gig_name"]} \t GigDate:{r["gig_date"]} \t GigVenue:{r["venue"]}");
                                                    }
                                                    break;
                                                case 2:
                                                    Console.WriteLine("--------------------------------------------");
                                                    Console.WriteLine("Choose one of the method to search a Gig:");
                                                    Console.WriteLine("1. Search Gig using Gig Name");
                                                    Console.WriteLine("2. Search Gig using Gig Venue");
                                                    Console.WriteLine("3. Search Gig using Gig Date");
                                                    Console.WriteLine("--------------------------------------------");
                                                    int search_choice = Convert.ToInt32(Console.ReadLine());
                                                    switch (search_choice)
                                                    {
                                                        case 1:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig Name");
                                                                string gig_name = Console.ReadLine();
                                                                DataRow row = user.SearchGigByName(gig_name);
                                                                if (row != null)

                                                                    Console.WriteLine($"GigName:{row["gig_name"]} GigDate:{row["gig_date"]} GigVenue:{row["venue"]}");
                                                                else
                                                                    throw new InvalidGigNameException();
                                                            }
                                                            catch (InvalidGigNameException ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        case 2:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig Venue");
                                                            string gig_venue = Console.ReadLine();
                                                            DataRow row2 = user.SearchGigByVenue(gig_venue);
                                                                if (row2 != null)

                                                                    Console.WriteLine($"GigName:{row2["gig_name"]} GigDate:{row2["gig_date"]} GigVenue:{row2["venue"]}");
                                                                else
                                                                    throw new InvalidGigNameException();
                                                            }
                                                            catch(InvalidGigNameException ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        case 3:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig Date");
                                                                DateTime gig_date = DateTime.Parse(Console.ReadLine());
                                                                DataRow row1 = user.SearchGigByDate(gig_date);
                                                                if (row1 != null)

                                                                    Console.WriteLine($"GigName:{row1["gig_name"]} GigDate:{row1["gig_date"]} GigVenue:{row1["venue"]}");
                                                                else
                                                                    throw new NoGigOnDate();
                                                            }
                                                            catch (InvalidGigNameException ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        default:
                                                            Console.WriteLine("Kindly Enter a proper choice");
                                                            break;
                                                    }
                                                    break;
                                                case 3:
                                                    try
                                                    {
                                                        
                                                        Console.WriteLine("enter gig id ");
                                                        int gigid = Convert.ToInt32(Console.ReadLine());

                                                        if (user.AddToCalender(uname, gigid))
                                                        {
                                                            Console.WriteLine(" Gig added to Calender");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    break;
                                                case 4:
                                                    dt = user.ViewCalender();
                                                    foreach (DataRow r in dt.Rows)
                                                    {
                                                        Console.WriteLine($"Username:{r["username"]} GigId:{r["gig_id"]} GigName:{r["gig_name"]} ArtistName:{r["artist_name"]} isCancelled:{r["isCancelled"]} GigDate:{r["gig_date"]}");
                                                    }
                                                    break;
                                                case 5:
                                                    dt = user.ViewNames();
                                                    foreach(DataRow r in dt.Rows)
                                                    {
                                                        Console.WriteLine($"{ r["names"] }");
                                                    }
                                                    Console.WriteLine("Enter the Artist Name you want to follow");
                                                    string follow_artist = Console.ReadLine();
                                                    user.followArtist(uname, follow_artist);
                                                    Console.WriteLine(uname + " " + "following " + follow_artist);
                                                    break;
                                                case 6: user.DisplayFollows(uname);
                                                    break;
                                                case 7: isUserQuit = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Kinndly, choose the Options from the following list");
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new UserNotFoundException();
                                    }
                                }
                                catch (UserNotFoundException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message, Console.ForegroundColor);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 2:
                                Console.WriteLine("Enter your username:");
                                string username3 = Console.ReadLine();
                                Console.WriteLine("Enter your password");
                                string password3 = Console.ReadLine();
                                try
                                {
                                    if (prog.ArtistLogin(username3, password3))
                                    {
                                        Console.WriteLine("Login Success");
                                        aname = username3;
                                        bool isArtistQuit = true;
                                        while(isArtistQuit)
                                        {
                                            Console.WriteLine("--------------------------------------------");
                                            Console.WriteLine("Welcome {0}, Choose one of the following:", aname);
                                            Console.WriteLine("1. Add a Gig");
                                            Console.WriteLine("2. Edit a Gig");
                                            Console.WriteLine("3. Remove a Gig");
                                            Console.WriteLine("4. Logout");
                                            Console.WriteLine("--------------------------------------------");
                                            int artist_choice = Convert.ToInt32(Console.ReadLine());
                                            switch (artist_choice)
                                            {
                                                case 1:
                                                    try
                                                    {
                                                        Console.WriteLine("enter gig id ");
                                                        int gigid = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Enter the Gig name");
                                                        string gig_name = Console.ReadLine();
                                                        Console.WriteLine("Enter the Artist name");
                                                        string artist_name = Console.ReadLine();
                                                        Console.WriteLine("Enter the venue name");
                                                        string venue = Console.ReadLine();
                                                        Console.WriteLine("Enter the Gig Date");
                                                        DateTime date = DateTime.Parse(Console.ReadLine());
                                                     
                                                        Console.WriteLine("Enter the Genre: ");
                                                        string gig_genre = Console.ReadLine();
                                                      
                                                        if (ado.AddGig(new Model.CreateGigs() { gigid = gigid, gig_name = gig_name, artist = artist_name, venue = venue, gigdate = date, genre = gig_genre }))
                                                        {
                                                            Console.WriteLine("New gig added ");
                                                        }
                                                        else
                                                        {
                                                            throw new GigIDAlreadyExistsExists();
                                                        }
                                                    }
                                                    catch(GigIDAlreadyExistsExists ex)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                   
                                                    break;
                                                case 2:
                                                    Console.WriteLine("--------------------------------------------");
                                                    Console.WriteLine("Choose an option on how you want to edit the Gig:");
                                                    Console.WriteLine("1. Update Gig Venue");
                                                    Console.WriteLine("2. Update Gig Date");
                                                    Console.WriteLine("3. Cancel a Gig");
                                                    Console.WriteLine("--------------------------------------------");
                                                    int edit_choice = Convert.ToInt32(Console.ReadLine());
                                                    switch (edit_choice)
                                                    {
                                                        case 1:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig ID: ");
                                                                int gig_id = Convert.ToInt32(Console.ReadLine());
                                                                Console.WriteLine("Enter the updated venue: ");
                                                                string updated_venue = Console.ReadLine();
                                                                if (ado.UpdateGigbyVenue(gig_id, updated_venue))
                                                                {
                                                                    Console.WriteLine("Venue updated ");
                                                                }
                                                                else
                                                                {
                                                                    throw new InvalidGigIdExcpetion();
                                                                }
                                                            }
                                                            catch(InvalidGigIdExcpetion ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        case 2:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig ID: ");
                                                                int gig_id1 = Convert.ToInt32(Console.ReadLine());
                                                                Console.WriteLine("Enter the updated Date: ");
                                                                DateTime updated_date = DateTime.Parse(Console.ReadLine());
                                                                if (ado.UpdateGigbyDate(gig_id1, updated_date))
                                                                {
                                                                    Console.WriteLine("Date updated");
                                                                }
                                                                else
                                                                {
                                                                    throw new InvalidGigIdExcpetion();
                                                                }
                                                            }
                                                            catch (InvalidGigIdExcpetion ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        case 3:
                                                            try
                                                            {
                                                                Console.WriteLine("Enter the Gig ID: ");
                                                                int gig_id2 = Convert.ToInt32(Console.ReadLine());
                                                                Console.WriteLine("Do you want to cancel the Gig?");
                                                                string isCancelled = Console.ReadLine();
                                                                if (ado.isCancelled(gig_id2, isCancelled))
                                                                {
                                                                    Console.WriteLine("Gig Status Modified");
                                                                }
                                                                else
                                                                {
                                                                    throw new InvalidGigIdExcpetion();
                                                                }
                                                            }
                                                            catch (InvalidGigIdExcpetion ex)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                            break;
                                                        default:
                                                            Console.WriteLine("Please choose a proper option");
                                                            break;
                                                    }
                                                    break;
                                                case 3:
                                                    try
                                                    {
                                                        Console.WriteLine("Enter gig Id you want to delete");
                                                        int gigId = Convert.ToInt32(Console.ReadLine());
                                                        if (ado.deleteGig(gigId))
                                                        {
                                                            Console.WriteLine("Gig deleted");
                                                        }
                                                        else
                                                        {
                                                            throw new InvalidGigIdExcpetion();
                                                        }
                                                    }
                                                    catch (InvalidGigIdExcpetion ex)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(ex.Message, Console.ForegroundColor);
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                    break;
                                                case 4: isArtistQuit = false;
                                                    break;

                                                default:
                                                    break;
                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        throw new UserNotFoundException();
                                    }
                                }
                                catch (UserNotFoundException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message, Console.ForegroundColor);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                        }
                        break;
                    case 3: isWholeFalse = false;
                        break;
                    default: Console.WriteLine("Kindly Enter a proper option");
                        break;
                }
            }
        }
        public static bool IsValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*\d).{4,16}$");
            Match match = regex.Match(password);
            return match.Success;
        }
        
    }
}
