using MySqlConnector;
using Crud_estoque;
using PiCliente;
using PiPedidos;

namespace PiCliente
{
    public class ListClientes
    {
        private static MySqlConnection conexao;

        static List<Cliente> clientes = new List<Cliente>();

        public static List<Cliente> ListaClientes()
        {
            return clientes;
        }

        public static Cliente? GetCliente(int index)
        {
            if(index < 0 || index >= clientes.Count)
            {
                return null;
            }else
            {
                return clientes[index];
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

        public static List<Cliente> Sincronizar()
        {
            IniciarConexao();
            string query = "SELECT * FROM cliente";
            MySqlCommand command = new MySqlCommand(query , conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(reader["idCliente"].ToString());
                cliente.Nome = reader["nome"].ToString();
                cliente.Cpf = reader["cpf"].ToString();
                cliente.Telefone = reader["telefone"].ToString();
                cliente.Email = reader["email"].ToString();                
                clientes.Add(cliente);
            }
            EncerrarConexao();
            return clientes;
        }

        public static void Criar(Cliente cliente)
        {
            IniciarConexao();
            string insert = "INSERT INTO cliente (nome, cpf, telefone, email) VALUES (@Nome, @Cpf, @Telefone, @Email)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try
            {
                if(cliente.Nome == null || cliente.Cpf == null || cliente.Telefone == null || cliente.Email == null)
                {
                    MessageBox.Show("A casa caiu.");
                }else
                {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@Email", cliente.Email);

                    int rowsAffected = command.ExecuteNonQuery();
                    cliente.Id = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0 )
                    {
                        MessageBox.Show("Cliente cadastrado com êxito");
                        clientes.Add(cliente);
                    } else {
                        MessageBox.Show("Não foi possível cadastrar o cliente");
                    }
                }
            }catch(Exception e) {
                MessageBox.Show("Houve um erro ao executar o programa: " + e.Message);
            }
            EncerrarConexao();
        }

        public static void AtualizarCliente(
            int indice,
            string nome,
            string cpf,
            string telefone,
            string email
        )
        {
            IniciarConexao();
            string alterar = "UPDATE cliente SET nome = @Nome, cpf = @Cpf, telefone = @Telefone, email = @Email WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(alterar, conexao);
            Cliente cliente = clientes[indice];

            try
            {
                if(nome != null || cpf != null || telefone != null || email != null)
                {
                    command.Parameters.AddWithValue("@Id", cliente.Id);
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@Email", cliente.Email);

                   int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected > 0 )
                    {
                        cliente.Nome = nome;
                        cliente.Cpf = cpf;
                        cliente.Telefone = telefone;
                        cliente.Email = email;
                    }else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                    
                }
            }catch (Exception e) {
                MessageBox.Show("Houve um erro ao executar o programa: " + e.Message);
            }
            EncerrarConexao();
        }

        public static void Deletar(int index)
        {
            IniciarConexao();
            string delete = "DELETE FROM cliente WHERE IdCliente = @IdCliente";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@IdCliente", clientes[index].Id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                clientes.RemoveAt(index);
                MessageBox.Show("Cadastro apagado com sucesso");
            }
            else
            {
                MessageBox.Show("Cliente não encontrado");
            }
            EncerrarConexao();
        }
    }
}