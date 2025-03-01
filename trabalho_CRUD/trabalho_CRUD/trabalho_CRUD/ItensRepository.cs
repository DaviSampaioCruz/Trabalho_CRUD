using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class ItensRepository
    {
        private readonly string _connectionString;

        public ItensRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Itens> ObterTodosItens()
        {
            List<Itens> itens = new List<Itens>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM itens";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itens.Add(new Itens
                        {
                            Nome = reader.GetString("nome"),
                            IdItens = reader.GetInt32("id_itens"),
                            Localizacao = reader.GetString("localizacao"),
                            TipoItem = reader.GetString("tipo_item")

                        });
                    }
                }
            }
            return itens;
        }


        public int InserirItem(Itens item)
        {
            int affectedRows = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO itens (nome, id_itens, localizacao, tipo_item)  VALUES(@nome, @id_itens, @localizacao, @tipo_item)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@id_itens", item.IdItens);
                    command.Parameters.AddWithValue("@localizacao", item.Localizacao);
                    command.Parameters.AddWithValue("@tipo_item", item.TipoItem);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }

        public int AtualizarItens(Itens item)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE itens Set nome = @nome, tipo_item = @tipo_item, localizacao = @localizacao WHERE id_itens = @id_itens";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@tipo_item", item.TipoItem);
                    command.Parameters.AddWithValue("@localizacao", item.Localizacao);
                    command.Parameters.AddWithValue("@id_itens", item.IdItens);

                    affectedRows = command.ExecuteNonQuery();

                }

            }
            return affectedRows;
        }

        public int RemoverItem(string id_item)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM itens WHERE id_itens = @id_itens";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_itens", id_item);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }

       /* public List<Itens> ObterItensPorCavernas(string nome_caverna)
        {

            List<Itens> itens = new List<Itens>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM itens I, cavernas C WHERE nome = @nome ";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    command.Parameters.AddWithValue("@nome", nome_caverna);

                    while (reader.Read())
                    {
                        itens.Add(new Itens
                        {
                            Nome = reader.GetString("nome"),
                            IdItens = reader.GetInt32("id_item"),
                            Localizacao = reader.GetString("localizacao"),
                            TipoItem = reader.GetString("TipoItem")
                        });
                    }

                }
            }
            return itens;
        } */

        public int RemoverItemCaverna(string localizacao)
        {
            int affectedRows = -1;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM itens WHERE localizacao = @localizacao ";
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


