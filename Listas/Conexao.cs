﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Conexao
    {
        private string ConexaoWebConfig = "MySql";

        private string Server = "localhost";
        private string Database = "linha_producao1";
        private string Usuario = "root";
        private string Senha = "";

        public MySqlConnection connection;

        public string connectionString;

        public Conexao()
        {
            Initialize(Server, Database, Usuario, Senha);
        }

        private void Initialize(string server, string database, string uid, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Abre a conexão com o banco de dados
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Trate a exceção de conexão aqui
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Fecha a conexão com o banco de dados
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                // Trate a exceção de fechamento aqui
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Exemplo de consulta ao banco de dados
        public void ExecuteQuery(string query)
        {
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Execute sua consulta aqui
                    cmd.ExecuteNonQuery();
                }

                CloseConnection();
            }
        }

        public void ExecuteQueryWithParameters(string query, params MySqlParameter[] parameters)
        {
            try
            {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddRange(parameters);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Processar os resultados, se necessário.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}
