using System.Collections.Generic;
using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace Crud_estoque{
    public class EstoqueBorba {
        public int IdProdutos { get; set; }
        public string Tipo { get; set;}
        public string Marca { get; set;}
        public string Nome { get; set;}
        public string Preco { get;set;}
        public string Quantidade {get; set;}



    public EstoqueBorba() {}
        public EstoqueBorba(string tipo, string marca, string nome, string preco, string quantidade){

            this.Tipo = tipo;
            this.Marca = marca;
            this.Nome = nome;
            this.Preco = preco;
            this.Quantidade = quantidade;

            RepoEstoque.Entrada(this);
        }       
        public static List<EstoqueBorba> Sincronizar() {
            return RepoEstoque.Sincronizar();
            }

        public static List<EstoqueBorba> ListarEstoque() {
            return RepoEstoque.ListEstoque();
        }

        public static void AlterarEstoque(int indice, string tipo, string marca, string nome, string preco, string quantidade){
            AlterarEstoque(indice, tipo, marca, nome, preco, quantidade);
        }
        public static void SaidaEstoque(int indice) {
            RepoEstoque.Saida(indice);

            
            }
        }
    }
