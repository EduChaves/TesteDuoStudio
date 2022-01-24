using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace API.Persistence
{
    public static class Service
    {
        public static Indicator DatabaseConfiguration(string query)
        {
            using (var connection = new MySqlConnection("SERVER=localhost; UID=root; DATABASE=bd_duostudio; PWD=;"))
            {
                var adapter = new MySqlDataAdapter(query, connection);
                var dataTable = new DataTable();
                var value = new Indicator();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    connection.Close();
                    
                    DataRow row = dataTable.Rows[0];
                    
                    value.InstitutionOrTraningnName = row[0].ToString();
                    value.Latitude = row[1].ToString();
                    value.Longitude = row[2].ToString();
                    
                    return value;
                }
                catch
                {
                    connection.Close();
                    return null;
                }
            }
        }
    }
}
