using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Cliente : Conexao
    {
        public int id;

        public int id_empresa;

        public string nome;

        public string telefone;

        private string documento;

        public string email;

        public DateTime data_cadastro;
         
        public void SetDocumento(string documento)
        {
            this.documento = documento;
        }

        public string GetDocumento()
        {
            return this.documento;
        }

            public List<Cliente> GetListaClientes()
            {
                List<Cliente> clientes = new List<Cliente>();

                try
                {

                    OpenConnection();

                    string query = "SELECT * FROM clientes";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                Cliente novoCliente = new Cliente();

                                novoCliente.id               = Convert.ToInt32(reader.GetString("id"));
                                novoCliente.id_empresa       = Convert.ToInt32(reader.GetString("id_empresa"));
                                novoCliente.nome             = reader.GetString("nome");
                                novoCliente.telefone         = reader.GetString("telefone");
                                novoCliente.email            = reader.GetString("email");
                                novoCliente.data_cadastro    = DateTime.Parse(reader.GetString("data_cadastro"));

                                novoCliente.SetDocumento(reader.GetString("documento"));

                                clientes.Add(novoCliente);
                            }

                        }

                    }

                    CloseConnection();
                    
                }catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return clientes;
            }
        }
    }
