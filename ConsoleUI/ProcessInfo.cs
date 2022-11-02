using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestBookLibrary.Models;

namespace ConsoleUI
{
    //ask guest for all the info at least once and to unknown maximum times
    //info to capture: first name, last name, message to host, number of people in their party
    //once done, print all information about each guest and total number of guests to the console
    public static class ProcessInfo
    {
        private static List<GuestModel> _guests = new List<GuestModel>();
        private static int _guestCount = 0;

        private static string GetString(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine() ?? string.Empty;
            return output;
        }

        private static int GetInt(string message)
        {
            bool isValidNumber;
            int output;
            do
            {
                Console.Write(message);
                isValidNumber = int.TryParse(Console.ReadLine(), out output) && output > 0;

                if (isValidNumber == false)
                {
                    Console.WriteLine("That is invalid number. Please try again!");
                }
            } while (isValidNumber == false);

            return output;
        }

        public static void GetGuestInfo()
        {
            string moreGuestsComing;
            do
            {
                GuestModel guest = new GuestModel();

                guest.FirstName = GetString("What is your first name: ");
                guest.LastName = GetString("What is your last name: ");
                guest.MessageToHost = GetString("What would you like to tell to your host: ");
                guest.PartyNumber = GetInt("How many people are in your party: ");

                _guestCount += guest.PartyNumber;
                _guests.Add(guest);

                moreGuestsComing = GetString("\nAre there more guests coming (yes/no): ");
                Console.Clear();
            } while (moreGuestsComing.ToLower() == "yes");
        }

        public static void PrintGuestBook()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine();
            foreach (GuestModel guest in _guests)
            {
                Console.WriteLine(guest.GuestInfo);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"The total number of guests: {_guestCount}");

            Console.WriteLine();
            Console.WriteLine("*******************************");
        }

    }
}
