using Crud_estoque;
using Pi_junção;
using PiPedidos;
namespace PiCliente
{
    public class ControllerClientes
    {
        public static void Sincronizar()
        {
            Cliente.Sincronizar();
        }
        
        public static void CriarCliente
        (
            string nome,
            string cpf,
            string telefone,
            string email
        )
        {
            new Cliente
            (
                nome,
                cpf,
                telefone,
                email
            );
        }
        
        public static List<Cliente> ListarClientes()
        {
            return Cliente.ListarClientes();
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
            Cliente.AlterarCliente
            (
                indice,
                nome,
                cpf,
                telefone,
                email
            );
        }
        
        public static void DeletarCliente(int indice)
        {
            List<Cliente> clientes = ListarClientes();

            if(indice >= 0 && indice < clientes.Count)
            {
                Cliente.DeletarCliente(indice);
            }
        }
    }
}