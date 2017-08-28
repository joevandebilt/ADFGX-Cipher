using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADFGX_SERVER_MODULE_CORE
{
    public abstract class ADFGX_SERVICE_INTERFACE
    {
        //-2 = Stop, -1 = Error, 0 = Not Running, 1 = Runnning
        int RunState = 0;
        Exception LatestException = null;
        string ServiceName = string.Empty;

        public void SetServiceName(string Name)
        {
            ServiceName = Name;
        }
        public string GetServiceName()
        {
            return ServiceName;
        }

        public void SetRunState(int state)
        {
            RunState = state;
        }
        public int GetRunState()
        {
            return RunState;
        }

        public void SetException(Exception ex)
        {
            LatestException = ex;
        }
        public Exception GetException()
        {
            return LatestException;
        }

        public abstract void Run(MySqlConnection mySqlConnection);
        public abstract void Stop();
    }
}
