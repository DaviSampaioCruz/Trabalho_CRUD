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
                string query = "SELECT * FROM cavernas";
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

        public int InserirCaverna(Caverna caverna)
        {
            int affectedRows = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO cavernas (nome, tipo, caracteristicas)  VALUES(@nome, @tipo, @caracteristicas)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", caverna.Nome);
                    command.Parameters.AddWithValue("@tipo", caverna.Tipo);
                    command.Parameters.AddWithValue("@caracteristicas", caverna.Caracteristica);
                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }

        public int AtualizarCaverna(Caverna caverna)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE cavernas Set nome = @nome, tipo = @tipo, caracteristicas = @caracteristicas WHERE nome = @nome";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", caverna.Nome);
                    command.Parameters.AddWithValue("@tipo", caverna.Tipo);
                    command.Parameters.AddWithValue("@caracteristicas", caverna.Caracteristica);

                    affectedRows = command.ExecuteNonQuery();
        
                    ItensRepository itens = new ItensRepository(_connectionString);


                }

            }
            return affectedRows;
        }

        public int RemoverCaverna(string nome)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM cavernas WHERE nome = @nome";
                using (var command = new MySqlCommand(query, connection))
                {

                    ItensRepository item = new ItensRepository(_connectionString);
                    MutantesRepository mutantes = new MutantesRepository(_connectionString);
                    item.RemoverItemCaverna(nome);
                    mutantes.RemoverMutanteCaverna(nome);
                    command.Parameters.AddWithValue("@nome", nome);

                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }

    }
}

