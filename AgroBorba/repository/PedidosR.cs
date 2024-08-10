using System.Xml.Serialization;
using MySqlConnector;
using Crud_estoque;
using PiCliente;
using PiPedidos;

namespace PiPedidos
{
    public class ListaPedidos
    {
        private static MySqlConnection conexao;

        static List<Pedido> pedidos = new List<Pedido>();

        public static List<Pedido> ListPedidos()
        {
            return pedidos;
        }

        public static Pedido? GetPedido(int index)
        {
            if (index < 0 || index >= pedidos.Count)
            {
                return null;
            }else
            {
                return pedidos[index];
            }
        }

        public static void IniciarConexao()
        {
            string info = "server=localhost;database=borbagatoforever;user id=root;password=''";
            conexao = new MySqlConnection(info);

            try
            {
                conexao.Open();
            }catch(Exception e)
            {
                MessageBox.Show("Conexão não inicializada" + e.Message);
            }
        }

        public static void EncerrarConexao()
        {
            conexao.Close();
        }

        public static List<Pedido> Sincronizar()
        {
            IniciarConexao();
            string query = "SELECT * FROM pedidos";
            MySqlCommand command = new MySqlCommand(query , conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.IdPedido = Convert.ToInt32(reader["idPedido"].ToString());
                pedido.dataPedido = reader["dataPedido"].ToString();
                pedido.Quantidade = reader["quantidade"].ToString();
                pedido.precoUnitario = reader["precoUnitario"].ToString();
                pedido.valorTotal = reader["valorTotal"].ToString();
                pedido.Observacoes = reader["observacoes"].ToString();

                pedidos.Add(pedido);
            }
            EncerrarConexao();
            return pedidos;
        }

        public static void Criar(Pedido pedido)
        {
            IniciarConexao();
            string insert = "INSERT INTO pedidos (dataPedido, quantidade, precoUnitario, valorTotal, observacoes) VALUES (@DataPedido, @Quantidade, @PrecoUnitario, @ValorTotal, @Observacoes)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try
            {
                if(pedido.dataPedido == null || pedido.Quantidade == null || pedido.precoUnitario == null || pedido.valorTotal == null || pedido.Observacoes == null)
                {
                    MessageBox.Show("Obviamente não funcionou kkkkkk otário");
                }else
                {
                    command.Parameters.AddWithValue("@DataPedido", pedido.dataPedido);
                    command.Parameters.AddWithValue("@Quantidade", pedido.Quantidade);
                    command.Parameters.AddWithValue("@PrecoUnitario", pedido.precoUnitario);
                    command.Parameters.AddWithValue("@ValorTotal", pedido.valorTotal);
                    command.Parameters.AddWithValue("@Observacoes", pedido.Observacoes);

                    int rowsAffected = command.ExecuteNonQuery();
                    pedido.IdPedido = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0)
                    {
                        MessageBox.Show("Pedido registrado com sucesso");
                    }else
                    {
                        MessageBox.Show("Não foi possível registrar o pedido kkkkk");
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("Houve um erro ao executar o programa: " + e.Message);
            }
            EncerrarConexao();
        }

        public static void AtualizarPedido
        (
            int indice,
            string datapedido,
            string quantidade,
            string precounitario,
            string valortotal,
            string observacoes
        )
        {
            IniciarConexao();
            string alterar = "UPDATE pedidos SET dataPedido = @DataPedido, quantidade = @Quantidade, precoUnitario = @PrecoUnitario, valorTotal = @ValorTotal, observacoes = @Observacoes WHERE IdPedido = @IdPedido";
            MySqlCommand command = new MySqlCommand(alterar, conexao);
            Pedido pedido = pedidos[indice];
            try
            {
                if(datapedido != null || quantidade != null || precounitario != null || valortotal != null || observacoes != null)
                {
                    command.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                    command.Parameters.AddWithValue("@DataPedido", datapedido);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    command.Parameters.AddWithValue("@PrecoUnitario", precounitario);
                    command.Parameters.AddWithValue("@ValorTotal", valortotal);
                    command.Parameters.AddWithValue("@Observacoes", observacoes);

                    int rowsAffected = command.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        pedido.dataPedido = datapedido;
                        pedido.Quantidade = quantidade;
                        pedido.precoUnitario = precounitario;
                        pedido.valorTotal = valortotal;
                        pedido.Observacoes = observacoes;
                    }else
                    {
                        MessageBox.Show("Pedido não encontrado");
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar o comando: " + ex.Message);
            }
            EncerrarConexao();
        }

        public static void Deletar(int index)
        {
            IniciarConexao();
            string delete = "DELETE FROM pedidos WHERE idPedido = @IdPedido";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@IdPedido", pedidos[index].IdPedido);
    
            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0) {
                pedidos.RemoveAt(index);
                MessageBox.Show("Pedido excluído com êxito");
            } else {
                MessageBox.Show("Pedido não encontrado");
            }
            EncerrarConexao();
        }
    }
}