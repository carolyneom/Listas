using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Cliente clientes = new Cliente();

            foreach (Cliente cliente in clientes.GetListaClientes())
            {
                Console.WriteLine("ID: " + cliente.id);
                Console.WriteLine("ID_EMPRESA: " + cliente.id_empresa);
                Console.WriteLine("NOME: " + cliente.nome);
                Console.WriteLine("TELEFONE: " + cliente.telefone);
                Console.WriteLine("EMAIL: " + cliente.email);
                Console.WriteLine("DOCUMENTO: " + cliente.GetDocumento());
                Console.WriteLine("DATA_CADASTRO: " + cliente.data_cadastro);
                Console.WriteLine("-------------------");
            }
            Console.ReadLine();


            Funcionario funcionarios = new Funcionario();

            foreach (Funcionario funcionario in funcionarios.GetListaFuncionarios())
            {
                Console.WriteLine("ID: " + funcionario.id);
                Console.WriteLine("ID_EMPRESA: " + funcionario.id_empresa);
                Console.WriteLine("NOME: " + funcionario.nome);
                Console.WriteLine("EMAIL: " + funcionario.email);
                Console.WriteLine("NIVEL: " + funcionario.nivel);
                Console.WriteLine("SENHA: " + funcionario.GetSenha());
                Console.WriteLine("DATA_CADASTRO: " + funcionario.data_cadastro);
                Console.WriteLine("-------------------");
            }
            Console.ReadLine();
        }
    }
}
