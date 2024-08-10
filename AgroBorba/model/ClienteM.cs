using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace PiCliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Cliente(){}

        public Cliente(string nome, string cpf, string telefone, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;

            ListClientes.Criar(this);
        }

        public static List<Cliente> Sincronizar()
        {
            return ListClientes.Sincronizar();
        }

        public static List<Cliente> ListarClientes()
        {
            return ListClientes.ListaClientes();
        }

        public static void AlterarCliente
        (
            int indice,
            string nome,
            string cpf,
            string telefone,
            string email
        )
        {
            ListClientes.AtualizarCliente(indice ,  nome , cpf , telefone , email);
        }

        public static void DeletarCliente(int indice)
        {
            ListClientes.Deletar(indice);
        }
    }
}