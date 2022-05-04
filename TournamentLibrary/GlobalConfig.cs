﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.DataAccess;

namespace TournamentLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; }
        public static void InitializeConnection()
        {
            SqlConnector sql = new SqlConnector();
            Connections.Add(sql);
        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}