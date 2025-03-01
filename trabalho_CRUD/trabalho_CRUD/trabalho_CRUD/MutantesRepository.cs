using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class MutantesRepository
    {
        private readonly string _connectionString;

        public MutantesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Mutantes> ObterTodosMutantes()
        {
            List<Mutantes> mutantes = new List<Mutantes>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM mutantes";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mutantes.Add(new Mutantes
                        {
                            Caracteristicas = reader.GetString("caracteristicas"),
                            Especialidades = reader.GetString("especialidades"),
                            Localizacao = reader.GetString("localizacao"),
                            IdMutante = reader.GetInt32("id_mutante")
                        });
                    }


                }
            }
            return mutantes;
        }

        public int InserirMutante(Mutantes mutante)
        {
            int affectedRows = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();


                //Talvez no futuro lançe uma exeção aqui, por não inserir o id, mesmo ele sendo AUTO_INCREMENT
                string query = "INSERT INTO mutantes (caracteristicas, especialidades, localizacao, id_mutante)  VALUES(@caracteristicas, @especialidades, @localizacao, @id_mutante)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_mutante", mutante.IdMutante);
                    command.Parameters.AddWithValue("@localizacao", mutante.Localizacao);
                    command.Parameters.AddWithValue("@especialidades", mutante.Especialidades);
                    command.Parameters.AddWithValue("@caracteristicas", mutante.Caracteristicas);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }

        public int AtualizarMutantes(Mutantes mutante)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE mutantes Set  localizacao = @localizacao, especialidades = @especialidades, caracteristicas = @caracteristicas WHERE id_mutante = @id_mutante";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@especialidades", mutante.Especialidades);
                    command.Parameters.AddWithValue("@localizacao", mutante.Localizacao);
                    command.Parameters.AddWithValue("@caracteristicas", mutante.Caracteristicas);
                    command.Parameters.AddWithValue("@id_mutante", mutante.IdMutante);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }

        public int RemoverMutante(int id_mutante)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM mutantes WHERE id_mutante = @id_mutante";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_mutante", id_mutante);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }

        public int RemoverMutanteCaverna(string localizacao)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM mutantes WHERE localizacao = @localizacao";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@localizacao", localizacao);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }


 


    }
}
