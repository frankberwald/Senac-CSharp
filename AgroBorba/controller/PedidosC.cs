using Crud_estoque;
using PiCliente;
using Pi_junção;
namespace PiPedidos
{
    public class ControllerPedidos
    {
        public static void Sincronizar()
        {
            Pedido.Sincronizar();
        }

        public static void CriarPedido
        (
            string datapedido,
            string quantidade,
            string precounitario,
            string valortotal,
            string observacoes
        )
        {
            new Pedido
            (
                datapedido,
                quantidade,
                precounitario,
                valortotal,
                observacoes
            );
        }

        public static List<Pedido> ListarPedidos()
        {
            return Pedido.ListarPedidos();
        }

        public static void AlterarPedido
        (
            int indice,
            string datapedido,
            string quantidade,
            string precounitario,
            string valortotal,
            string observacoes
        )
        {
            Pedido.AlterarPedido
            (
                indice,
                datapedido,
                quantidade,
                precounitario,
                valortotal,
                observacoes
            );
        }
        
        public static void DeletarPedido(int indice)
        {
            List<Pedido> pedidos = ListarPedidos();

            if (indice >= 0 && indice < pedidos.Count)
            {
                Pedido.DeletarPedido(indice);
            }
        }
    }
}