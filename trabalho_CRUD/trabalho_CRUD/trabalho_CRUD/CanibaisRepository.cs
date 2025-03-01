using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class CanibaisRepository
    {
        private readonly string _connectionString;

        public CanibaisRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Canibais> ObterTodosCanibais()
        {
            List<Canibais> canibais = new List<Canibais>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM canibais";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        canibais.Add(new Canibais
                        {
                            Tipo = reader.GetString("tipo"),
                            Localizacao = reader.GetString("localizacao"),
                            Caracteristicas = reader.GetString("caracteristicas"),
                            Especialidade = reader.GetString("especialidade"),
                            IdCanibal = reader.GetInt32("id_canibal")

                        });
                    }


                }
            }
            return canibais;
        }


        public int InserirCanibal(Canibais canibal)
        {
            int affectedRows = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();


                //Talvez no futuro lançe uma exeção aqui, por não inserir o id, mesmo ele sendo AUTO_INCREMENT
                string query = "INSERT INTO canibais (tipo, localizacao, especialidades, caracteristicas, id_canibal)  VALUES(@tipo, @localizacao, @especialidades, @caracteristicas, @id_canibal)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tipo", canibal.Tipo);
                    command.Parameters.AddWithValue("@localizacao", canibal.Localizacao);
                    command.Parameters.AddWithValue("@especialidades", canibal.Especialidade);
                    command.Parameters.AddWithValue("@caracteristicas", canibal.Caracteristicas);
                    command.Parameters.AddWithValue("@id_canibal", canibal.IdCanibal);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }


        public int AtualizarCanibais(Canibais canibal)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE canibais Set Tipo = @Tipo, Localizacao = @Localizacao, especialidades = @especialidades, Caracteristicas = @Caracteristicas WHERE id_canibal = @id_Canibal";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tipo", canibal.Tipo);
                    command.Parameters.AddWithValue("@especialidades", canibal.Especialidade);
                    command.Parameters.AddWithValue("@Localizacao", canibal.Localizacao);
                    command.Parameters.AddWithValue("@Caracteristicas", canibal.Caracteristicas);
                    command.Parameters.AddWithValue("@id_Canibal", canibal.IdCanibal);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }
        public int RemoverCanibal(int id_canibal)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM canibais WHERE id_canibal = @id_canibal";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_canibal", id_canibal);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }

        public Canibais ObterTodosCanibaisPorVila(string nome)
        {
            Canibais canibal = new Canibais();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT tipo, especialidades, localizacao, id_canibal,caracteristicas  FROM canibais   WHERE localizacao = @localizacao";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@localizacao", nome);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            canibal.Tipo = reader.GetString("tipo");
                            canibal.Especialidade = reader.GetString("especialidades");
                            canibal.Localizacao = reader.GetString("localizacao");
                            canibal.IdCanibal = reader.GetInt32("id_canibal");
                            canibal.Caracteristicas = reader.GetString("caracteristicas");

                        }


                    }
                }
                return canibal;
            }
        }
            public int RemoverCanibalPorVila(string localizacao)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM canibais WHERE localizacao = @localizacao";
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

    
