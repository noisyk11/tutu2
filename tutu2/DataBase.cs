using Npgsql;
using System.Data;

namespace tutu2
{
    public class Database
    {
        private NpgsqlConnection conn;

        public Database()
        {
            string connString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=sham2";
            conn = new NpgsqlConnection(connString);
        }

        public void OpenConnection()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void CloseConnection()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }

        public NpgsqlConnection GetConnection()
        {
            return conn;
        }
    }
}