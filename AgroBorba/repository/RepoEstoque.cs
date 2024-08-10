using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace Crud_estoque{
    public class RepoEstoque{
        private static List<EstoqueBorba> estoquesborba = new List<EstoqueBorba>();

        public static List<EstoqueBorba> ListEstoque(){
            return estoquesborba;
        }

        private static MySqlConnection conexao;
        public static void InitConexao(){
            string info = "server=localhost;database=borbagatoforever;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Impossível se conectar com o banco de dados.");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
        public static List<EstoqueBorba> Sincronizar(){
           

            InitConexao();

            string query = "SELECT * FROM produtos";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                EstoqueBorba estoque = new EstoqueBorba();
                estoque.IdProdutos = Convert.ToInt32(reader["IdProdutos"].ToString());
                estoque.Tipo = reader["tipo"].ToString();
                estoque.Marca = reader["marca"].ToString();
                estoque.Nome = reader["nome"].ToString();
                estoque.Preco = reader["preco"].ToString();
                estoque.Quantidade = reader ["quantidade"].ToString();
                estoquesborba.Add(estoque);
            }
            CloseConexao();
            return estoquesborba;
            
        }
        
        public static void Entrada(EstoqueBorba estoque) {
            InitConexao();
            
            string query = "INSERT INTO produtos (tipo,marca,nome,preco,quantidade) VALUES (@Tipo, @Marca, @Nome, @Preco, @Quantidade)";
            MySqlCommand command = new MySqlCommand(query, conexao);

                if(estoque.Tipo == null || estoque.Marca == null || estoque.Nome == null || estoque.Preco == null || estoque.Quantidade == null){
                    MessageBox.Show("Preencha todos os campos para continuar.");
                }else {
                    command.Parameters.AddWithValue("@Tipo", estoque.Tipo);
                    command.Parameters.AddWithValue("@Marca", estoque.Marca);
                    command.Parameters.AddWithValue("@Nome", estoque.Nome);
                    command.Parameters.AddWithValue("@Preco", estoque.Preco);
                    command.Parameters.AddWithValue("@Quantidade", estoque.Quantidade);

                    int rowsAffected = command.ExecuteNonQuery();
                    estoque.IdProdutos = Convert.ToInt32(command.LastInsertedId);

                    if(rowsAffected > 0){
                        MessageBox.Show("Produto cadastrado com sucesso");
                        estoquesborba.Add(estoque);
                    } else {
                        MessageBox.Show("Falha ao cadastrar produto.");
                    } CloseConexao();
        }
    }

        public static void UpdateEstoque(int indice, string tipo, string marca, string nome, string preco, string quantidade){
            InitConexao();
            MessageBox.Show("Atualizando");
            string query = "UPDATE produtos SET tipo = @Tipo, marca = @Marca, nome = @Nome, preco = @Preco, quantidade = @Quantidade WHERE IdProdutos = @IdProdutos";
            MySqlCommand command = new MySqlCommand(query, conexao);
            EstoqueBorba estoque = estoquesborba[indice];
            try {
                if(tipo == null || marca == null || nome == null || preco == null || quantidade == null) {                    
                    command.Parameters.AddWithValue("@IdProdutos", estoque.IdProdutos);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@Marca", marca);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Preco", preco);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        estoque.Tipo = tipo;
                        estoque.Marca = marca;
                        estoque.Nome = nome;
                        estoque.Preco = preco;
                        estoque.Quantidade = quantidade;
                    }
                    else {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                }else {
                    MessageBox.Show("Produto não encontrado");
                }
            }catch (Exception ex){
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();            
        }

        public static void Saida(int index) {
            InitConexao();
            string delete = "DELETE FROM produtos WHERE IdProdutos = @IdProdutos";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@IdProdutos", estoquesborba[index].IdProdutos);
            // executar
            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0) {
                estoquesborba.RemoveAt(index);
                MessageBox.Show("Produto deletado com sucesso.");
            } else {
                MessageBox.Show("Produto não encontrado.");
            }
            CloseConexao();
            }
        }
    }
