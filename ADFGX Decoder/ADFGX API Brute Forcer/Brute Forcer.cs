using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Net;

namespace ADFGXDecoder
{
    public partial class Decoder : Form
    {
        #region Data Types
        public struct DecodedWords
        {
            //Store the decoded words along with the keysquare used to generate them
            public List<string> words;
            public char[,] KeySquare;
        }
        #endregion

        #region Constructors & Global Members
        bool ProcessorThreadRunning;
        bool MessageThreadRunning;
        List<string> UniqueKeypairs;
        List<string> MessagesToPrint = new List<string>();
        List<int> ThreadIDs = new List<int>();
        object mylock = new object();
        Thread thrLongWay;
        
        public Decoder()
        {
            //Construct the initial form
            InitializeComponent();
            ProcessorThreadRunning = false;
            MessageThreadRunning = false;
            txtOutput.SelectionTabs = new int[] { 90, 180, 270, 360 };
        }
        
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //End the whole application - including background threads or un-closed forms
            Application.Exit();
        }
                
        private void cmdLongWay_Click(object sender, EventArgs e)
        {
            //Is the processing thread already running?
            if (!ProcessorThreadRunning)
            {
                GetUniqueKeyPairs();
                
                MessageThreadRunning = true;
                Thread MessageThread = new Thread(MessagePrinter);
                MessageThread.Start();

                    //Kick off the brute forcer background thread.
                    ProcessorThreadRunning = true;
                    thrLongWay = new Thread(LongWay);
                    thrLongWay.Start();                
                    cmdBruteForcer.Text = "Stop Brute Forcer";
                    lblSafeToQuit.Text = "Not Safe to quit";
                    cmdQuit.Enabled = false;
            }
            else
            {
                //Then you must want it to stop...
                ProcessorThreadRunning = false;
                MessageThreadRunning = false;  
                thrLongWay.Join();

                cmdBruteForcer.Text = "Start Brute Forcer";
                lblSafeToQuit.Text = "Safe to quit";
                cmdQuit.Enabled = true;
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void cmdSaveToFile_Click(object sender, EventArgs e)
        {
            string FilePath = Directory.GetCurrentDirectory();
            string FileName = Path.Combine(FilePath, string.Format("ADFGXDecoder.{0}.txt", DateTime.Now.ToString("yyyyMMdd")));
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                sw.WriteLine(txtOutput.Text);
                sw.Close();
            }
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Form Update Methods

        private void PopulateKeySquare(string Letters)
        {
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { PopulateKeySquare(Letters); });
            }
            else
            {
                Letters = Letters.ToUpper();
                if (Letters.Trim().Length == 25)
                {
                    //Put the results onto the form 
                    txtKey1.Text = Letters[0].ToString();
                    txtKey2.Text = Letters[1].ToString();
                    txtKey3.Text = Letters[2].ToString();
                    txtKey4.Text = Letters[3].ToString();
                    txtKey5.Text = Letters[4].ToString();
                    txtKey6.Text = Letters[5].ToString();
                    txtKey7.Text = Letters[6].ToString();
                    txtKey8.Text = Letters[7].ToString();
                    txtKey9.Text = Letters[8].ToString();
                    txtKey10.Text = Letters[9].ToString();
                    txtKey11.Text = Letters[10].ToString();
                    txtKey12.Text = Letters[11].ToString();
                    txtKey13.Text = Letters[12].ToString();
                    txtKey14.Text = Letters[13].ToString();
                    txtKey15.Text = Letters[14].ToString();
                    txtKey16.Text = Letters[15].ToString();
                    txtKey17.Text = Letters[16].ToString();
                    txtKey18.Text = Letters[17].ToString();
                    txtKey19.Text = Letters[18].ToString();
                    txtKey20.Text = Letters[19].ToString();
                    txtKey21.Text = Letters[20].ToString();
                    txtKey22.Text = Letters[21].ToString();
                    txtKey23.Text = Letters[22].ToString();
                    txtKey24.Text = Letters[23].ToString();
                    txtKey25.Text = Letters[24].ToString();
                }
            }
        }
        
        public void AddMessage(string Message)
        {
            //Add a message to the messages queue
            MessagesToPrint.Add(Message);
        }

        public void PrintMessage(string Message)
        {
            if (txtOutput.InvokeRequired)
            {
                //is this a thread, you can't update the main form from a thread
                //invoke the main thread or go home
                Invoke((MethodInvoker)delegate { PrintMessage(Message); });
            }
            else
            {
                //Since you're on the main thread now just update with the newest string
                txtOutput.AppendText(Environment.NewLine + Message);

                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        public void TidyOutput()
        {
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { TidyOutput(); });
            }
            else
            {
                if (chkTidyOutput.Checked)
                {
                    if (txtOutput.Lines.Count() > 960)
                    {
                        txtOutput.Clear();
                    }
                }
            }
        }
        #endregion

        #region Thread Methods
        private void LongWay()
        {
            //Get the keysquare
            DecodedWords Words = new DecodedWords();
            
            ThreadIDs.Add(Thread.CurrentThread.ManagedThreadId);
            AddMessage(string.Format("[{0}] Starting Processing", Thread.CurrentThread.ManagedThreadId));

            while (ProcessorThreadRunning)
            {
                //Get the next keysquare pattern from the server
                string KeySquare = GetKeySquareFromServer();
                if (!string.IsNullOrEmpty(KeySquare))
                {
                    PopulateKeySquare(KeySquare);

                    if (Words.words != null) Words.words.Clear();

                    //Grab the decoded words and keysquare from the random generated one
                    Words.words = DecodeCypher(true, out Words.KeySquare);

                    string UploadURL = "http://adfgx.vandebilt.co/webrequest.php?DecodedKeySquare=" + KeySquare;

                    for (int i = 0; i < Words.words.Count; i++)
                    {
                        //For each of the 48 decoded texts
                        string val = Words.words[i].Substring(0, 34);
                        UploadURL = string.Format("{0}&val{1}={2}", UploadURL, i + 1, val);

                        AddMessage(string.Format("[Message] Output: {0}\tKeySquare: {1}", val, KeySquare));
                    }
                    SendDecodedData(UploadURL);
                }
                else
                {
                    AddMessage("No KeySquare permuations to calculate, waiting for update");
                    Thread.Sleep(1000);
                }
            }

            //is the thread kill? Tell the user. 
            AddMessage(string.Format("[{0}] Thread Closing", Thread.CurrentThread.ManagedThreadId));
        }

        public void MessagePrinter()
        {
            string[] tempMessages = new string[20];
            while (MessageThreadRunning)
            {
                int Max = 20;
                if (MessagesToPrint.Count < 20) Max = MessagesToPrint.Count;
                for (int i = 0; i < Max; i++)
                {
                    //Only get up to 20 messages at once
                    tempMessages[i] = MessagesToPrint[i];
                }

                //If you leave this un-managed, the thread takes on way too much data and overloads

                lock (mylock)
                {
                    //Now that we have the messages we want to print, remove them from the queue
                    //Lock the list, we don't want people adding to it while we delete from it
                    MessagesToPrint.RemoveRange(0, Max);
                }

                for (int i = 0; i < Max; i++)
                {
                    //Now print the messages we have collected
                    if (!string.IsNullOrEmpty(tempMessages[i])) PrintMessage(tempMessages[i]);
                    
                }
                TidyOutput();
                Thread.Sleep(10);
            }
            PrintMessage("Message thread is kill");
        }

        #endregion

        #region Decoding Methods
        public char FindCharacter(char Row, char Column, char[,] letters)
        {
            char letter = '-';
            int RowNum = 0;
            int ColNum = 0;
            string Letters = "ADFGX";

            if (Letters.Contains(Row) && Letters.Contains(Column))
            {
                switch (Row)
                {
                    case 'A':
                        RowNum = 0;
                        break;
                    case 'D':
                        RowNum = 1;
                        break;
                    case 'F':
                        RowNum = 2;
                        break;
                    case 'G':
                        RowNum = 3;
                        break;
                    case 'X':
                        RowNum = 4;
                        break;
                }

                switch (Column)
                {
                    case 'A':
                        ColNum = 0;
                        break;
                    case 'D':
                        ColNum = 1;
                        break;
                    case 'F':
                        ColNum = 2;
                        break;
                    case 'G':
                        ColNum = 3;
                        break;
                    case 'X':
                        ColNum = 4;
                        break;
                }
                letter = letters[RowNum, ColNum];   //Get the letter from the char array of letters
            }
            return letter;
        }

        private char[,] GenerateKeySqaureArray()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl.Name.StartsWith("txtKey"))
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                    {
                        ctrl.Text = "*";
                    }
                }
            }

            //Compose a char array from the forms text boxes
            char[,] letters = new char[5, 5] 
            {   				
                {txtKey1.Text[0],txtKey2.Text[0],txtKey3.Text[0],txtKey4.Text[0],txtKey5.Text[0]},
                {txtKey6.Text[0],txtKey7.Text[0],txtKey8.Text[0],txtKey9.Text[0],txtKey10.Text[0]},
                {txtKey11.Text[0],txtKey12.Text[0],txtKey13.Text[0],txtKey14.Text[0],txtKey15.Text[0]},
                {txtKey16.Text[0],txtKey17.Text[0],txtKey18.Text[0],txtKey19.Text[0],txtKey20.Text[0]},
                {txtKey21.Text[0],txtKey22.Text[0],txtKey23.Text[0],txtKey24.Text[0],txtKey25.Text[0]}	
            };
            return letters;            
        }
                
        private List<string> GetUniqueKeyPairs()
        {
            string[] strKeyArray = txtKeywords.Text.Split(' ');
            int index;
            int rowlength;
            string keyword = string.Empty;
            string Input = txtInput.Text;
            char[,] table;
            char[] InputCharacters;
            char[] KeywordCharacters;
            char[] SortedKeyword;
            char[,] SortedTable;
            int counter;
            char temp;
            int row = 0;
            int column = 0;

            //Its a lengthy and poorly designed procedure,
            //Thats why we store it in the memory and dont bother doing the computations again
            if (UniqueKeypairs == null)
            {
                UniqueKeypairs = new List<string>();
                
                //For each of the unique keywords we have specified
                for (index = 0; index < strKeyArray.Length; index++)
                {
                    //How long is the keyword we have
                    rowlength = strKeyArray[index].Length;

                    //Create a table that will be able to hold the ciphertext
                    //The cipher is 12 rows by 6 columns
                    table = new char[12, 6];
                    SortedTable = new char[12, 6];
                    
                    //Get the full ciphertext including blank spaces
                    //Blank spaces denoted by '-'
                    InputCharacters = new char[Input.Length];
                    InputCharacters = Input.ToCharArray();
                    
                    //Grab the current keyword from the array
                    keyword = strKeyArray[index];
                    row = 0;
                    column = 0;

                    for (counter = 0; counter < Input.Length; counter++)    //add items into array of characters
                    {
                        table[row, column] = InputCharacters[counter];
                        column++;

                        //If we have filled up the row then drop onto the next line
                        if (column == rowlength)
                        {
                            column = 0;
                            row++;
                        }

                    }

                    KeywordCharacters = keyword.ToCharArray();
                    SortedKeyword = keyword.ToCharArray();
                    counter = 0;

                    //Take the keyword and arrange it into alphabetical order
                    while (counter < (KeywordCharacters.Length - 1))
                    {

                        if (Convert.ToInt32(SortedKeyword[counter]) > Convert.ToInt32(SortedKeyword[counter + 1]))
                        {
                            temp = SortedKeyword[counter];
                            SortedKeyword[counter] = SortedKeyword[counter + 1];
                            SortedKeyword[counter + 1] = temp;
                            counter = 0;
                        }
                        else counter++;
                    }

                    counter = 0;
                    while (counter < 6)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            //Find which position the sorted keyword is sorted to in the original word
                            if (SortedKeyword[i] == KeywordCharacters[counter])
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    //Transpose that column into the sorted table at that position
                                    SortedTable[j, counter] = table[j, i];
                                }

                            }
                        }
                        counter++;
                    }


                    //The SortedTable array should at this point contain the un-jumbled cipher
                    //According to the keyword
                    string output = string.Empty;
                    column = 0;
                    row = 0;

                    //Now we just need to turn it into a string 
                    for (counter = 0; counter < Input.Length; counter++)    //add items into array of characters
                    {
                        output = string.Concat(output, SortedTable[row, column]);
                        column++;

                        if (column == rowlength)
                        {
                            column = 0;
                            row++;
                        }
                    }

                    //Now we add this output into our list of Unique keypairs
                    UniqueKeypairs.Add(output);
                }
            }
            return UniqueKeypairs;
        }

        private List<string> DecodeCypher(bool DecodePairs, out char[,] KeySquareArray)
        {
            List<string> Words = new List<string>();
            int counter;
            KeySquareArray = new char[5, 5];

            //The unique combinations of unjumbled columns as fairly static,
            //No need to generate it more than once, if we already have it, keep it
            if (UniqueKeypairs == null) UniqueKeypairs = GetUniqueKeyPairs();

            //Does the user want us to translate using the keysquare?
            List<string> Outputs = new List<string>();
            List<string> TempList = UniqueKeypairs;     //Assign the list of keypairs to a local variable, cross threading resource sharing is a bitch. 
            foreach (string keypair in TempList)
            {
                //THE NEXT SECTION CHANGES PAIRS INTO CHARACTERS ACCORDING TO THE KEYSQUARE
                string output = string.Empty;
                KeySquareArray = GenerateKeySqaureArray();  //Grab the keysquare from the form
                for (counter = 0; counter < txtInput.Text.Length; counter = counter + 2)    //add items into array of characters
                {
                    //Generate a character from the array
                    char letter = FindCharacter(keypair[counter], keypair[counter + 1], KeySquareArray);
                    output = string.Concat(output, letter);
                        
                }
                //Add the string to our outputs
                Outputs.Add(output);
            }
            return Outputs;
        }

        public string GetKeySquareAsLine(char[,] KeySquare)
        {
            //Returns the keysquare on the form as one 25 character line to be printed. 
            string SquareAsLine = string.Empty;

            int Rows = KeySquare.GetLength(0);
            int Cols = KeySquare.GetLength(1);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    SquareAsLine = SquareAsLine + KeySquare[i, j].ToString();
                }
            }
            return SquareAsLine;
        }
        
        #endregion

        #region Web Methods

        public string GetKeySquareFromServer()
        {
            string URL = "http://adfgx.vandebilt.co/webrequest.php?NextKeySquare=true";
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString(URL);
            
            return webData;
        }

        public void SendDecodedData(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                AddMessage(string.Format("Failed to save with url: {0}", URL));
                AddMessage(ex.Message);
                ProcessorThreadRunning = false;
                MessageThreadRunning = false;
            }
        }

        #endregion      

    }
}
