using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace PiPedidos
{
    public class Pedido
    {
        // mesmos nomes da tabela no banco de dados
        public int IdPedido { get; set; }
        public string dataPedido { get; set; }
        public string Quantidade { get; set; }
        public string precoUnitario { get; set; }
        public string valorTotal { get; set; }
        public string Observacoes { get; set; }

        public Pedido(){}

        public Pedido(string datapedido, string quantidade, string precounitario, string valortotal, string observacoes)
        {
            this.dataPedido = datapedido;
            Quantidade = quantidade;
            precoUnitario = precounitario;
            valorTotal = valortotal;
            Observacoes = observacoes;

            //nome da classe do repositorio
            ListaPedidos.Criar(this);            
        }

        public static List<Pedido> Sincronizar()
        {
            return ListaPedidos.Sincronizar();
        }

        public static List<Pedido> ListarPedidos()
        {
            return ListaPedidos.ListPedidos();
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
            ListaPedidos.AtualizarPedido(indice, datapedido, quantidade, precounitario, valortotal, observacoes);
        }

        public static void DeletarPedido(int indice)
        {
            ListaPedidos.Deletar(indice);
        }
    }
}