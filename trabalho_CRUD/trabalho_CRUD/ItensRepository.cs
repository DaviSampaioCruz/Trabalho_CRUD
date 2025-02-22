using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
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
                            IdItens = reader.GetInt32("id_item"),
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

                string query = "INSERT INTO itens (nome, id_itens localizacao, TipoItem),  VALUES(@nome, @id_itens, @localizacao, @TipoItem)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@id_itens", item.IdItens);
                    command.Parameters.AddWithValue("@localizacao", item.Localizacao);
                    command.Parameters.AddWithValue("@TipoItem", item.TipoItem);

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

                string query = "UPDATE itens Set Nome = @Nome, TipoItem = @TipoItem, Localizacao = @Localizacao WHERE IdItens = @IdItens";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@TipoItem", item.TipoItem);
                    command.Parameters.AddWithValue("@caracteristica", item.Localizacao);
                    command.Parameters.AddWithValue("@IdItens", item.IdItens);

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

                string query = "DELETE FROM item WHERE id_item = @id_item";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_item", id_item);
                    affectedRows = command.ExecuteNonQuery();

                }
            }
            return affectedRows;
        }

        public List<Itens> ObterItensPorCavernas(string nome_caverna)
        {

            List<Itens> itens = new List<Itens>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM itens WHERE nome_caverna = @nome_caverna";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    command.Parameters.AddWithValue("@nome_caverna", nome_caverna);

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
        }




    }



}


