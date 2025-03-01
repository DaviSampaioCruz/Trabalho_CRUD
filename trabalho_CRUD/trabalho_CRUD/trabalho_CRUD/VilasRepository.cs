using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using trabalho_CRUD;

namespace trabalho_CRUD
{
    internal class VilasRepository
    {
        private readonly string _connectionString;

        public VilasRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Vilas> ObterTodasVilas()
        {
            List<Vilas> vilas = new List<Vilas>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM vilas";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vilas.Add(new Vilas
                        {
                            Nome = reader.GetString("nome"),
                            TipoHabitantes = reader.GetString("tipo_habitantes"),
                            TipoHabitat = reader.GetString("tipo_habitat"),
                            localizacao = reader.GetString("localizacao")

                        });
                    }


                }
            }
            return vilas;
        }


        public int InserirVila(Vilas vila)
        {
            int affectedRows = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO vilas (nome, tipo_habitantes, tipo_habitat, localizacao )  VALUES(@nome, @tipo_habitantes, @localizacao, @tipo_habitat)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", vila.Nome);
                    command.Parameters.AddWithValue("@tipo_habitantes", vila.TipoHabitantes);
                    command.Parameters.AddWithValue("@localizacao", vila.localizacao);
                    command.Parameters.AddWithValue("@tipo_habitat", vila.TipoHabitat);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }


        public int AtualizarVilas(Vilas vila)
        {
            
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                   

                    

                string query = "UPDATE vilas SET nome = @nome, tipo_habitantes = @tipo_habitantes, tipo_habitat = @tipo_habitat, localizacao = @localizacao WHERE nome = @nome";
                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@nome", vila.Nome);
                    command.Parameters.AddWithValue("@tipo_habitantes", vila.TipoHabitantes);
                    command.Parameters.AddWithValue("@localizacao", vila.localizacao);
                    command.Parameters.AddWithValue("@tipo_habitat", vila.TipoHabitat);

                    affectedRows = command.ExecuteNonQuery();
                    
                }

            }
            return affectedRows;



        }

        public int RemoverVila(string nome)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM vilas WHERE nome = @nome";
                using (var command = new MySqlCommand(query, connection))
                {
                    CanibaisRepository canibal = new CanibaisRepository(_connectionString);
                    canibal.RemoverCanibalPorVila(nome);

                    command.Parameters.AddWithValue("@nome", nome);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }


       // provavelmente irei apagar isso:
        /*public List<Canibais> VerificarSeTipoCanibalExiste(string tipo, string localizacao)
        {
            List<Canibais> canibais = new List<Canibais>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT C.id_canibal, C.tipo FROM canibais C, vilas V WHERE {localizacao} = c.localizacao AND {tipo} = v.tipo_habitantes";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@c.localizacao", localizacao);
                    command.Parameters.AddWithValue("@v.tipo_habitantes", tipo);

                    using (var reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            canibais.Add(new Canibais
                            {
                                IdCanibal = reader.GetInt32("id_canibal"),
                                Tipo = reader.GetString("tipo")
                            });
                        }
                    }
                }
            }
            return canibais;
        }*/
    }

    
}
