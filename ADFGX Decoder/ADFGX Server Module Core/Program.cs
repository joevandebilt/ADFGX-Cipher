using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;

using System.Threading;

namespace ADFGX_SERVER_MODULE_CORE
{
    class Program
    {
        static string ConnectionString = "server=localhost;port=3306;database=ADFGX;user=ADFGX;password=0a9hw6IskmUZ2myf@";
        static MySqlConnection _MySql;

        //Services
        static ADFGX_SERVICE_INTERFACE Permutations;
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting Application");
                Console.WriteLine("Connecting to MySQL Database");

                //Init Database
                _MySql = GetConnection();
                if (!_MySql.Ping())
                {
                    //cannot ping server, this is a problem and you should probably debug it
                    Console.WriteLine("Cannot ping MySQL Database. That's a problem.");
                    Console.WriteLine(ConnectionString);
                    _MySql.Open();
                }
                else
                {
                    _MySql.Open();
                }

                //Init Services
                Permutations = new ADFGX_PERMUTATIONS();

                //Start User Input
                Console.WriteLine("Connection Established - awaiting input");
                Console.Write("\n>");
                
                string Input = CommandClean(Console.ReadLine());
                while (Input != "QUIT")
                {
                    if (Input.StartsWith("START SERVICE"))
                    {
                        string ServiceName = Input.Replace("START SERVICE", "").Trim();
                        ADFGX_SERVICE_INTERFACE ChosenService = getService(ServiceName);
                        
                        if (ChosenService != null)
                        {
                            if (ChosenService.GetRunState() <= 0)
                            {
                                Thread DoSomeWork = new Thread(thr => ChosenService.Run(_MySql));
                                DoSomeWork.Start();
                            }
                            else
                            {
                                Console.WriteLine("Service is already Running.");
                            }
                        }                        
                    }
                    else if (Input.StartsWith("STOP SERVICE"))
                    {
                        string ServiceName = Input.Replace("STOP SERVICE", "").Trim();
                        ADFGX_SERVICE_INTERFACE ChosenService = getService(ServiceName);

                        if (ChosenService != null)
                        {
                            if (ChosenService.GetRunState() > 0)
                            {
                                ChosenService.Stop();
                            }
                            else
                            {
                                Console.WriteLine("Service is not running.");
                            }
                        }
                    }
                    else if (Input.StartsWith("RESTART SERVICE"))
                    {
                        string ServiceName = Input.Replace("RESTART SERVICE", "").Trim();
                        ADFGX_SERVICE_INTERFACE ChosenService = getService(ServiceName);

                        if (ChosenService != null)
                        {
                            if (ChosenService.GetRunState() > 0)
                            {
                                ChosenService.Stop();
                                Thread.Sleep(5000);
                                Thread DoSomeWork = new Thread(thr => ChosenService.Run(_MySql));
                                DoSomeWork.Start();
                            }
                            else if (ChosenService.GetRunState() <= 0)
                            {
                                Thread DoSomeWork = new Thread(thr => ChosenService.Run(_MySql));
                                DoSomeWork.Start();
                            }
                        }
                    }
                    else if (Input.StartsWith("SERVICE STATUS"))
                    {
                        string ServiceName = Input.Replace("SERVICE STATUS", "").Trim();
                        ADFGX_SERVICE_INTERFACE ChosenService = getService(ServiceName);

                        switch (ChosenService.GetRunState())
                        {
                            case 1:
                                Console.WriteLine("The service is currently running.");
                                break;
                            case 0:
                                Console.WriteLine("The service is currently not running.");
                                break;
                            case -1:
                                Console.WriteLine("The service is currently in an error state.");
                                Exception ex = ChosenService.GetException();
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.StackTrace);
                                break;
                            case -2:
                                Console.WriteLine("The service is stopping.");
                                break;
                        }
                    }
                    else if (Input.Contains("HELP"))
                    {
                        Console.WriteLine("--- Available Commands ---");
                        Console.WriteLine("START SERVICE <Service Name>");
                        Console.WriteLine("STOP SERVICE <Service Name>");
                        Console.WriteLine("RESTART SERVICE <Service Name>");
                        Console.WriteLine("SERVICE STATUS <Service Name>");
                        Console.WriteLine("QUIT");

                        Console.WriteLine("--- Available Services ---");
                        Console.WriteLine("PERMUTATIONS - Caluclates Keysquare permutations");
                    }

                    Console.Write("\n>");
                    Input = CommandClean(Console.ReadLine());
                }
                _MySql.Close();

                Console.WriteLine("\n\nClosing Application");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            finally
            {
                //Cleanup MySQL
                if (_MySql != null && _MySql.State != System.Data.ConnectionState.Closed)
                {
                    _MySql.Close();
                }
                else if (_MySql != null)
                {
                    _MySql.Dispose();
                }
            }
        }

        static string CommandClean(string Input)
        {
            string Output = Input.Trim().ToUpper();
            return Output;
        }

        static ADFGX_SERVICE_INTERFACE getService(string ServiceName)
        {
            ADFGX_SERVICE_INTERFACE ChosenService = null;
            if (ServiceName == "PERMUTATIONS")
            {
                ChosenService = Permutations;
            }
            else
            {
                Console.WriteLine("Unable to find chosen service");
            }
            return ChosenService;
        }

        static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
