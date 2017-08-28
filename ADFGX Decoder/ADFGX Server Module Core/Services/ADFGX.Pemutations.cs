using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ADFGX_SERVER_MODULE_CORE
{
    public class ADFGX_PERMUTATIONS : ADFGX_SERVICE_INTERFACE
    {
        private MySqlConnection _MySql;
        private string LastGenerated;
        
        public override void Run(MySqlConnection DBConnection)
        {
            try
            {
                SetRunState(1);
                SetServiceName("PERMUTATIONS");

                _MySql = DBConnection;
                LastGenerated = GetLastGenerated();

                string[] AllChars = new string[25] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                CalculatePermutations(string.Empty, AllChars);

                SetRunState(0);
            }
            catch (Exception ex)
            {
                SetException(ex);
                SetRunState(-1);
            }
        }

        public override void Stop()
        {
            SetRunState(-2);
        }

        private string GetLastGenerated()
        {
            string webData = "-1";

            //Get Last generated from MySQL
            MySqlCommand command = new MySqlCommand("SELECT perm_keysquare FROM ADFGX_Permutations ORDER BY perm_keysquare DESC LIMIT 1", _MySql);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    webData = $"{reader["perm_keysquare"]}";
                }
            }

            if (webData == "-1")
                return null;
            else
                return webData;
        }

        private void CalculatePermutations(string CurrentString, string[] AllowedChars)
        {
            if (CurrentString.Length == AllowedChars.Length)
            {
                if (CurrentString != LastGenerated)
                {
                    //We're at the end
                    //Submit this to the database
                    //Console.WriteLine(CurrentString);
                    try
                    {
                        MySqlCommand command = new MySqlCommand(string.Format("INSERT INTO ADFGX_Permutations (perm_keysquare, perm_status, perm_last_updated) VALUES ('{0}', 0,NOW())", CurrentString), _MySql);
                        command.ExecuteScalar();

                        LastGenerated = string.Empty; //reset this since we should be up to date now
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        //Console.WriteLine("Failed to save keysquare {0}", CurrentString);
                        SetRunState(-1);
                        SetException(ex);
                        throw ex;
                    }
                }
                else
                {
                    //The string we generated is the last one in the DB, so we just want to move past it
                    LastGenerated = string.Empty;
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
                    if (GetRunState() < 0) break;
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
                    if (GetRunState() < 0) break;
                }
            }
        }

    }
}
