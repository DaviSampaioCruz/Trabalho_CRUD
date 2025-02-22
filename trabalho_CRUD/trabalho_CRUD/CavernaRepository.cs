using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class CavernaRepository
    {
        private readonly string _connectionString;

        public CavernaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Caverna> ObterTodasCavernas()
        {
            List<Caverna> cavernas = new List<Caverna>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM casa";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cavernas.Add(new Caverna
                        {
                            Nome = reader.GetString("nome"),
                            Tipo = reader.GetString("tipo"),
                            Caracteristica = reader.GetString("caracteristicas")
                           
                        });
                    }
                }
            }
            return cavernas;
        }
    }
}
