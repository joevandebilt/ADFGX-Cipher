using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ADFGX_SERVER_MODULE_CORE
{
    public class ADFGX_WORD_PRUNER : ADFGX_SERVICE_INTERFACE
    {
        MySqlConnection _MySQL;
        public override void Run(MySqlConnection DBConnection)
        {
            try
            {
                SetRunState(1);
                SetServiceName("WORDPRUNER");

                _MySQL = DBConnection;
                
                while (GetRunState() > 0)
                {
                    ProcessNextWord();
                }

                SetRunState(0);
            }
            catch (Exception ex)
            {
                SetRunState(-1);
                SetException(ex);
            }
        }

        public override void Stop()
        {
            SetRunState(-2);
        }

        private void ProcessNextWord()
        {
            string KeySquare = string.Empty;
            string[] Permutations = new string[48];

            MySqlCommand command = new MySqlCommand("SELECT * FROM ADFGX_Permutations WHERE perm_status = 2 LIMIT 1", _MySQL);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    KeySquare = $"{reader["perm_keysquare"]}";
                    for (int i = 0; i < 48; i++)
                    {
                        string FieldName = string.Format("perm_combination_{0}", (i+1));
                        Permutations[i] = $"{reader[FieldName]}";
                    }                    
                }
            }

            if (string.IsNullOrEmpty(KeySquare))
            {
                return;
            }

            List<string> ValidStrings = WordScore(Permutations);
            if (ValidStrings.Count > 0)
            {
                //It's a possible solution so save it
                SaveKeySquare(KeySquare, ValidStrings);
            }

            //Now delete it from the main pool
            DeleteKeySquare(KeySquare);
        }
        
        private List<string> WordScore(string[] permutations)
        {
            List<string> ReturnWords = new List<string>();
            foreach (string perm in permutations)
            {
                MySqlCommand command = new MySqlCommand(string.Format("SELECT COUNT(FLW_VAL) AS Score FROM ADFGX_Double_Letter_Words WHERE '{0}' LIKE CONCAT('%', FLW_VAL ,'%')", perm), _MySQL);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Score = int.Parse($"{reader["Score"]}");
                        if (Score > 0)
                        {
                            ReturnWords.Add(perm);
                        }
                    }
                }
            }
            return ReturnWords;
        }

        private bool DeleteKeySquare(string KeySquare)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM ADFGX_Permutations WHERE perm_status = 2 AND perm_keysquare = '{0}'", KeySquare), _MySQL);
            command.ExecuteScalar();
            return true;
        }

        private bool SaveKeySquare(string KeySquare, List<string> ValidWords)
        {
            foreach (string val in ValidWords)
            {
                MySqlCommand command = new MySqlCommand(string.Format("INSERT INTO ADFGX_Valid (val_keysquare, val_phrase) VALUES ('{0}','{1}')", KeySquare, val), _MySQL);
                command.ExecuteScalar();
            }
            return true;
        }
    }
}
