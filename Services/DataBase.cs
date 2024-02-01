using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Project.Services
{

    public class DataBase
    {
        private readonly string _connectionString;
        public DataBase(string connectionString){
            _connectionString = connectionString;
        }
        public List<string> Read(string SQL){

            MySqlConnection con = new MySqlConnection(_connectionString);
            List<string> users = new List<string>();
            
            try{
                
                
                con.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, con);
                MySqlDataReader reader =  cmd.ExecuteReader();

                while (reader.Read()){
                    users.Add(reader.GetString(0));
                }
                con.Close();
                return users;

            } catch (Exception e){
                List<string> error = new List<string>();
                System.Console.WriteLine("An error occured", e.ToString());
                con.Close();
                return users;
            }

            
        }
    }
}