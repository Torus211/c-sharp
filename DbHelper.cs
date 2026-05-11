using Npgsql;
using System;
using System.Configuration;

namespace WindowsFormsApp1
{
    public static class DbHelper
    {
        public static string GetConnectionString()
        {
            return "Host=localhost;Port=5432;Database=azaryan_db;Username=postgres;Password=password;";
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(GetConnectionString());
        }
    }
}