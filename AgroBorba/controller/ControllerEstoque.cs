using Pi_junção;
using PiCliente;
using PiPedidos;
namespace Crud_estoque{

    public class ControllerEstoque
    {

        public static void Sincronizar(){
           EstoqueBorba.Sincronizar();
        }
         public static void Entrada(string tipo, string marca, string nome, string preco, string quantidade) {
             new EstoqueBorba(tipo, marca, nome, preco, quantidade);
        }
        public static List<EstoqueBorba> ListarEstoque() {
            return EstoqueBorba.ListarEstoque();
        }

           public static void AlterarEstoque(int indice, string tipo, string marca, string nome, string preco, string quantidade) {
            EstoqueBorba.AlterarEstoque(indice, tipo, marca, nome, preco, quantidade);
        }
             public static void Saida(int indice) {
            List<EstoqueBorba> estoques = ListarEstoque();

            if(indice >= 0 && indice < estoques.Count){
                EstoqueBorba.SaidaEstoque(indice);
            } else {
                Console.WriteLine("Indice inválido");
    }
}

    }
}