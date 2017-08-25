using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace AlphabetPermutations
{
    class Program
    {
        static string LastGenerated = string.Empty;
        static bool isError = false;

        private static string _EndPoint = "https://adfgx.nkode.uk/webrequest.php";

        static void Main(string[] args)
        {
            Console.WriteLine("Calculating some shit");
            Console.WriteLine();

            LastGenerated = GetLastGenerated();

            string[] AllChars = new string[25] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            CalculatePermutations(string.Empty, AllChars);

            //Send Email notification service stopped?
            SendMail();

            Console.WriteLine("\n\nClosing Application");
        }

        private string constructURL(Dictionary<string, string> arguments)
        {
            string URI = _EndPoint;
            if (arguments.Count > 0)
            {
                URI = string.Format("{0}?", URI);
                foreach (var entry in arguments)
                {
                    URI = string.Format("{0}&{1}={2}", URI, entry.Key, entry.Value);
                }
            }
            return URI;
        }

        static string GetLastGenerated()
        {
            string URL = "https://adfgx.nkode.uk/webrequest.php?GetLastPermutation=true";
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString(URL);

            if (webData == "-1")
                return null;
            else
                return webData;
        }

        static void CalculatePermutations(string CurrentString, string[] AllowedChars)
        {
            if (CurrentString.Length == AllowedChars.Length)
            {
                //We're at the end
                //Submit this to the database
                Console.WriteLine(CurrentString);
                try
                {   
                    string URL = string.Format("https://adfgx.nkode.uk/webrequest.php?KeySquare={0}", CurrentString);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    LastGenerated = string.Empty; //reset this since we should be up to date now
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Failed to save keysquare {0}", CurrentString);
                    isError = true;
                }
            }
            else if (string.IsNullOrEmpty(CurrentString))
            {
                //We're just getting started
                foreach (string AllowedCharacter in AllowedChars)
                {
                    if (!string.IsNullOrEmpty(LastGenerated))
                    {
                        char NextChar = LastGenerated[0];
                        if (AllowedCharacter[0] >= NextChar)
                        {
                            CalculatePermutations(AllowedCharacter, AllowedChars);
                        }
                    }
                    else
                    {
                        //The last Generated was null - we're the first entry :) 
                        CalculatePermutations(AllowedCharacter, AllowedChars);
                    }
                    if (isError) break;
                }
            }
            else
            {
                //Tack a new letter on the end and keep going
                foreach (string AllowedCharacter in AllowedChars)
                {
                    if (!string.IsNullOrEmpty(LastGenerated))
                    {
                        char NextChar = LastGenerated[CurrentString.Length];
                        if (AllowedCharacter[0] >= NextChar && !CurrentString.Contains(AllowedCharacter))
                        {
                            CalculatePermutations(CurrentString + AllowedCharacter, AllowedChars);
                        }
                    }
                    else if (!CurrentString.Contains(AllowedCharacter))
                    {
                        CalculatePermutations(CurrentString + AllowedCharacter, AllowedChars);
                    }
                    if (isError) break;
                }
            }
        }

        static void SendMail()
        {
            string To = "joe.vandebilt@nkode.uk";
            string From = "ADFGX@nkode.uk";
            MailMessage message = new MailMessage(From, To);
            message.Subject = "Permutation service has stopped running";
            if (isError)
                message.Body = "The service has stopped running, the isError status is currently set to true.";
            else
                message.Body = "The service has stopped running, the isError status is currently set to false.";

            SmtpClient client = new SmtpClient("mail.nkode.uk");

            try 
            {
                client.Send(message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", 
                ex.ToString() );
                Console.ReadLine();
            }
        }
    }
}
