using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace Pi_junção;
public class ViewEstoque : Form
{

  private readonly Label Lbltipoproduto;
  private readonly TextBox Inptipoproduto;
  private readonly Label Lblmarcaproduto;
  private readonly TextBox Inpmarcaproduto;
  private readonly Label Lblnomeproduto;
  private readonly TextBox Inpnomeproduto;
  private readonly Label Lblprecoproduto;
  private readonly TextBox Inpprecoproduto;
  private readonly Label Lblquantidade;
  private readonly TextBox Inpquantidade;
  private readonly Button BtnEntradaEstoque;
  private readonly Button BtnListar;
  private readonly Button BtnAlterarEstoque;
  private readonly Button BtnSaidaEstoque;
  private readonly DataGridView DGVEstoque;

  public ViewEstoque()
  {
    ControllerEstoque.Sincronizar();

          AutoScaleDimensions = new SizeF(6F, 13F);
          AutoScaleMode = AutoScaleMode.Font;
          //BackgroundImage = ((Image)(resources.GetObject("$this.BackgroundImage")));
          //BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          ClientSize = new Size(554, 437);
          StartPosition = FormStartPosition.CenterScreen;
          Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));          
          Text = "Visão geral de estoque";
          ResumeLayout(false);
          PerformLayout();

      Lbltipoproduto = new Label{
          AutoSize = true,
          Location = new Point(290, 19),
          MinimumSize = new Size(55, 20),
          Name = "TipoProduto",
          Size = new Size(55, 20),
          TabIndex = 9,
          Text = "Tipo",
          TextAlign = ContentAlignment.MiddleCenter,
          Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))

      };
      Inptipoproduto = new TextBox{
          Location = new Point(365, 19),
          Name = "InpTipo",
          Size = new Size(115, 20),
          TabIndex = 13,
      };

      Lblmarcaproduto = new Label{
          AutoSize = true,
          Location = new Point(48, 50),
          MinimumSize = new Size(55, 20),
          Name = "MarcaProduto",
          Size = new Size(55, 20),
          TabIndex = 8,
          Text = "Marca",
          TextAlign = ContentAlignment.MiddleCenter,
          Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
      };
      Inpmarcaproduto = new TextBox{
         Location = new Point(109, 51),
         Name = "InpMarca",
         Size = new Size(100, 20),
         TabIndex = 12
      };

      Lblnomeproduto = new Label{
        AutoSize = true,
        Location = new Point(48, 19),
        MinimumSize = new Size(55, 20),
        Name = "NomeProduto",
        Size = new Size(55, 20),
        TabIndex = 5,
        Text = "Nome",
        TextAlign = ContentAlignment.MiddleCenter,
        Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
      };
      Inpnomeproduto = new TextBox{
        Location = new Point(109, 20),
        Name = "InpNome",
        Size = new Size(160, 20),
        TabIndex = 10
      };

      Lblprecoproduto = new Label{
        AutoSize = true,
        Location = new Point(48, 81),
        MinimumSize = new Size(55, 20),
        Name = "PreçoProduto",
        Size = new Size(55, 20),
        TabIndex = 7,
        Text = "Preço",
        TextAlign = ContentAlignment.MiddleCenter,
        Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))

      };
      Inpprecoproduto = new TextBox{
        Location = new Point(109, 82),
        Name = "InpPreço",
        Size = new Size(100, 20),
        TabIndex = 11
      };

      Lblquantidade = new Label{
          AutoSize = true,
          Location = new System.Drawing.Point(285, 81),
          MinimumSize = new System.Drawing.Size(55, 20),
          Name = "QuantidadeLBL",
          Size = new System.Drawing.Size(62, 20),
          TabIndex = 15,
          Text = "Quantidade",
          TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
          Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
      };
      Inpquantidade = new TextBox{
        Location = new Point(365, 82),
        Name = "QuantidadeInp",
        Size = new Size(100, 20),
        TabIndex = 16
      };

      BtnEntradaEstoque = new Button{
          Location = new Point(51, 119),
          Name = "EntradaEstoque",
          Size = new Size(106, 33),
          TabIndex = 1,
          Text = "Registrar",
          UseVisualStyleBackColor = true
      };
      BtnEntradaEstoque.Click += ClickEntradaEstoque;
      BtnSaidaEstoque = new Button{
          Location = new Point(275, 119),
          Name = "DELETADOESTOQUE",
          Size = new Size(106, 33),
          TabIndex = 3,
          Text = "Deletar",
          UseVisualStyleBackColor = true
      };
      BtnSaidaEstoque.Click += ClickSaidaEstoque;

      BtnListar = new Button{
          Location = new Point(387, 119),
          Name = "ListarEstoque",
          Size = new Size(106, 33),
          TabIndex = 4,
          Text = "Listar Estoque",
          UseVisualStyleBackColor = true
      };
      BtnListar.Click += ClickListar;

      DGVEstoque = new DataGridView{
         ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
         Location = new Point(51, 158),
         Name = "DGVEstoque",
         Size = new Size(442, 237),
         TabIndex = 0
      };

        Controls.Add(Lbltipoproduto);
        Controls.Add(Lblmarcaproduto);
        Controls.Add(Lblnomeproduto);
        Controls.Add(Lblprecoproduto);
        Controls.Add(Lblquantidade);
        Controls.Add(Inptipoproduto);
        Controls.Add(Inpmarcaproduto);
        Controls.Add(Inpnomeproduto);
        Controls.Add(Inpprecoproduto);
        Controls.Add(Inpquantidade);
        Controls.Add(BtnEntradaEstoque);
        Controls.Add(BtnListar);
        Controls.Add(BtnSaidaEstoque);
        Controls.Add(BtnAlterarEstoque);
        Controls.Add(DGVEstoque);
        ListarEstoque();
        }


        private void ClickEntradaEstoque(object? sender, EventArgs e) {
                if(Inptipoproduto.Text == "") {
                    return;
                }
                ControllerEstoque.Entrada(Inptipoproduto.Text, Inpmarcaproduto.Text, Inpnomeproduto.Text, Inpprecoproduto.Text, Inpquantidade.Text);
                ListarEstoque();
            }

        private void ClickAlterarEstoque(object? sender, EventArgs e) {
            int index = DGVEstoque.SelectedRows[0].Index;
            if(Inptipoproduto.Text == "") {
                return;
            }
            ControllerEstoque.AlterarEstoque(index, Inptipoproduto.Text, Inpmarcaproduto.Text, Inpnomeproduto.Text, Inpprecoproduto.Text, Inpquantidade.Text);
            ListarEstoque();
        }
        private void ClickListar (object? sender, EventArgs e){
                ListarEstoque();
            }

        private void ListarEstoque() {
            List<EstoqueBorba> estoques = ControllerEstoque.ListarEstoque();
            DGVEstoque.Columns.Clear();
            DGVEstoque.AutoGenerateColumns = false;
            DGVEstoque.DataSource = estoques;
            
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "IdProdutos",
                HeaderText = "Id"
            });
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Nome",
                HeaderText = "Nome"
            });
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo"
            });
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Marca",
                HeaderText = "Marca"
            });
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Preco",
                HeaderText = "Preco"
            });
            DGVEstoque.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Quantidade",
                HeaderText = "Quantidade"
            });
        }
        private void ClickSaidaEstoque(object? sender, EventArgs e) {
            int index = DGVEstoque.SelectedRows[0].Index;
            ControllerEstoque.Saida(index);
            ListarEstoque();
        }
      }

