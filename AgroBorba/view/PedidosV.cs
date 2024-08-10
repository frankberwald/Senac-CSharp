using System.Drawing.Drawing2D;
using Crud_estoque;
using PiCliente;
using PiPedidos;
namespace Pi_junção
{
    /// ////////////// PEDIDOS ////////////////
public class PedidosV : Form
    {
        // Forms Strip Menu Superior //
        // private readonly ToolStripMenuItem programaToolStripMenuItem;
        // private readonly ToolStripMenuItem minimizarToolStripMenuItem;
        // private readonly ToolStripMenuItem maximizarToolStripMenuItem;
        // private readonly ToolStripMenuItem fecharToolStripMenuItem;
        // private readonly ToolStripMenuItem visãoGeralDeEstoqueToolStripMenuItem;
        // private readonly ToolStripMenuItem abrirEmUmaNovaJanelaToolStripMenuItem;
        // private readonly ToolStripMenuItem fecharToolStripMenuItem1;
        private readonly MenuStrip menuStrip1; 
        private readonly Label InformativoRodape;      
       // PEDIDOS //
        private readonly Label Informativo2;
        private readonly Label LabelDataPedido;
        private readonly Label LabelQuantidade;
        private readonly Label LabelPrecoUnitario;
        private readonly Label LabelValorTotal;
        private readonly Label LabelObservacoes;
        private readonly TextBox InputDataPedido;

        private readonly TextBox InputQuantidade;
        private readonly TextBox InputPrecoUnitario;
        private readonly TextBox InputValorTotal;
        private readonly TextBox InputObservacoes;
        private readonly Button ButtonCriarPedidos;
        private readonly Button ButtonListarPedido;
        private readonly Button ButtonAlterarPedidos;
        private readonly Button ButtonDeletarPedidos;
        private readonly DataGridView DGVPedidos;

        // PEDIDOS //
        // CLIENTE ABAIXO //

        private readonly Label LabelNome;
        private readonly Label LabelCpf;
        private readonly Label LabelTelefone;
        private readonly Label LabelEmail;
        //private readonly Label Informativo1; // Titulo Cadastrar Clientes
        private readonly TextBox InputNome;
        private readonly TextBox InputCpf;
        private readonly TextBox InputTelefone;
        private readonly TextBox InputEmail;
        private readonly Button ButtonCriarCLiente;
        private readonly Button ButtonAlterarCLiente;
        private readonly Button ButtonDeletarCLiente;
        private readonly Button ButtonListarClientes;
        private readonly Button ButtonAbrirEstoque;
        private readonly DataGridView DGVClientes;

        // CLIENTE ACIMA //              

        public PedidosV()
        {
            // FORM UNICO ABAIXO //
            ControllerPedidos.Sincronizar();            
            ControllerClientes.Sincronizar();

            // FORM UNICO ACIMA //

            // PEDIDOS ABAIXO //

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 514);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.Alpha;
            Text = "Agropecuária Borba";
            ResumeLayout(false);
            PerformLayout();

            // Informativo2
            Label Informativo2 = new Label()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(442, 20),
                Name = "Informativo2",
                Size = new Size(197, 25),
                TabIndex = 29,
                Text = "Registrar novo pedido"
            };

            LabelDataPedido = new Label
            {
                AutoSize = true,
                Location = new Point(364, 114),
                Name = "LabelDataPedido",
                Size = new Size(31, 13),
                TabIndex = 34,
                Text = "Data"
            };
            LabelQuantidade = new Label
            {
                Text = "Quantidade:",
                Size = new Size(68, 17),
                Location = new Point(340, 77)
                
                };

            LabelPrecoUnitario = new Label
            {
                Text = "Preço Unitário:",
                Size = new Size(83,20),
                Location = new Point(567, 85)
            };

            LabelValorTotal = new Label
            {
                AutoSize = true,
                Location = new Point(567, 114),
                Name = "labelValorTotal",
                Size = new Size(61, 13),
                TabIndex = 38,
                Text = "Valor Total"
            };

            LabelObservacoes = new Label
            {
                AutoSize = true,
                Location = new Point(459, 144),
                Name = "LabelObservacoesPedido",
                Size = new Size(204, 13),
                TabIndex = 37,
                Text = "Itens do pedido e observações abaixo."
            };

            InputDataPedido = new TextBox
            {
                Location = new Point(407, 111),
                Name = "InpDataPedido",
                Size = new Size(70, 22),
                TabIndex = 35
            };

            InputQuantidade = new TextBox
            {
                Name = "Quantidade",
                Location = new Point(407, 77),
                Size = new Size(70, 20)
            };

            InputPrecoUnitario = new TextBox
            {
                Name = "Preço unitário",
                Location = new Point(649, 80),

                Size = new Size(70, 22)
            };

            InputValorTotal = new TextBox
            {
                Location = new Point(645, 111),
                Name = "InputValorTotal",
                Size = new Size(70, 22),
                TabIndex = 39
            };

            InputObservacoes = new TextBox
            {
                Location = new Point(407, 160),
                MinimumSize = new Size(200, 12),
                Name = "InputObservacoes",
                Size = new Size(308, 13),
                TabIndex = 36
            };

            ButtonCriarPedidos = new Button
            {
                Location = new Point(407, 432),
                Name = "CriarPedido",
                Size = new Size(91, 35),
                TabIndex = 41,
                Text = "Criar Pedido",
                UseVisualStyleBackColor = true,
            };
            ButtonCriarPedidos.Click += ClickCriarPedido;

            ButtonListarPedido = new Button 
            {
                Location = new Point(624, 432),
                Name = "Listarpedido",
                Size = new Size(91, 35),
                TabIndex = 42,
                Text = "Listar Pedidos",
                UseVisualStyleBackColor = true
            };
            ButtonListarPedido.Click += ClickListarPedidos;

            ButtonAlterarPedidos = new Button
            {
                Text = "Alterar Pedido",
                Size = new Size(91,35),
                Location = new Point(407, 470)
            };
            ButtonAlterarPedidos.Click += ClickAlterarPedidos;

            ButtonDeletarPedidos = new Button
            {
                Location = new Point(516, 432),
                Name = "deletarPedido",
                Size = new Size(91, 35),
                TabIndex = 43,
                Text = "Deletar Pedido",
                UseVisualStyleBackColor = true
            };
            ButtonDeletarPedidos.Click += ClickDeletarPedido;

            ButtonAbrirEstoque = new Button{
              Location = new Point(300,470),
              Name = "Estoque",
              Size = new Size(91,35),
              Text = "Estoque"  
            };
            ButtonAbrirEstoque.Click += ClickAbrirEstoque;

            DGVPedidos = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(407, 200),
                Name = "DGVPedidos",
                Size = new Size(308, 230),
                TabIndex = 44
            };
            // PEDIDOS ACIMA //
            // CLIENTES ABAIXO //
            Label Informativo1 = new Label()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(61, 25),
                Name = "Informativo1",
                Size = new Size(182, 25),
                TabIndex = 28,
                Text = "Cadastro de clientes"
            };
            
            LabelNome = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                AutoSize = true,
                Location = new Point(23, 80),
                Name = "LabelNome",
                Size = new Size(37, 13),
                TabIndex = 5,
                Text = "Nome"
            };

            LabelCpf = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                AutoSize = true,
                Location = new Point(23, 108),
                Name = "LabelCpf",
                Size = new Size(26, 13),
                TabIndex = 10,
                Text = "CPF"
            };

            LabelTelefone = new Label
            {
                AutoSize = true,
                Location = new Point(142, 108),
                Name = "LabelTelefone",
                Size = new Size(19, 13),
                TabIndex = 11,
                Text = "☎"
            };

            LabelEmail = new Label
            {
                AutoSize = true,
                Location = new Point(23, 144),
                Name = "LabelEmail",
                Size = new Size(19, 13),
                TabIndex = 12,
                Text = "✉"
            };

            InputNome = new TextBox
            {
                Location = new Point(66, 77),
                Name = "InputNome",
                Size = new Size(200, 22),
                TabIndex = 5
                //TextChanged += new System.EventHandler(this.textBox1_TextChanged)

            };

            InputCpf = new TextBox
            {
                Location = new Point(66, 105),
                Name = "InputCpf",
                Size = new Size(70, 22),
                TabIndex = 7
                //TextChanged += new System.EventHandler(this.textBox2_TextChanged);            
            };

            InputTelefone = new TextBox
            {
                Location = new Point(169, 105),
                Name = "InputTelefone",
                Size = new Size(97, 22),
                TabIndex = 6
            };

            InputEmail = new TextBox
            {
                Location = new Point(50, 135),
                Name = "InputEmail",
                Size = new Size(216, 22),
                TabIndex = 8
            };

            ButtonCriarCLiente = new Button
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(26, 176),
                Name = "ButtonCriar",
                Size = new Size(73, 28),
                TabIndex = 0,
                Text = "Cadastrar",
                UseVisualStyleBackColor = true
            };
            ButtonCriarCLiente.Click += ClickCriarCLiente;

            ButtonAlterarCLiente = new Button
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(105, 176),
                Name = "ButtonAlterar",
                Size = new Size(82, 28),
                TabIndex = 2,
                Text = "Modificar",
                UseVisualStyleBackColor = true
            };
            ButtonAlterarCLiente.Click += ClickAlterarCLiente;

            ButtonDeletarCLiente = new Button
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(193, 176),
                Name = "ButtonDeletar",
                Size = new Size(73, 28),
                TabIndex = 3,
                Text = "Remover",
                UseVisualStyleBackColor = true
            };
            ButtonDeletarCLiente.Click += ClickDeletarCLiente;

            ButtonListarClientes = new Button
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(26, 210),
                Name = "ButtonListar",
                Size = new Size(240, 28),
                TabIndex = 13,
                Text = "Atualizar Lista de Clientes",
                UseVisualStyleBackColor = true
            };
            ButtonListarClientes.Click += ClickListarClientes;

            DGVClientes = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(26, 244),
                Name = "DGVClientes",
                Size = new Size(240, 258),
                TabIndex = 1
            };

            // Menu Superior //
        //    ToolStripMenuItem programaToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "programaToolStripMenuItem",
        //         Size = new Size(71, 20),
        //         Text = "Programa"
        //     };

        //     ToolStripMenuItem minimizarToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "minimizarToolStripMenuItem",
        //         Size = new Size(129, 22),
        //         Text = "Minimizar"
        //     };
        //     minimizarToolStripMenuItem.Click += ClickMinimizar;

        //     ToolStripMenuItem maximizarToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "maximizarToolStripMenuItem",
        //         Size = new Size(129, 22),
        //         Text = "Maximizar"
        //     };
        //     maximizarToolStripMenuItem.Click += ClickMaximizar;

        //     ToolStripMenuItem fecharToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "fecharToolStripMenuItem",
        //         Size = new Size(129, 22),
        //         Text = "Fechar"
        //     };
        //     fecharToolStripMenuItem.Click += ClickFechar;

        //     ToolStripMenuItem visaoGeralDeEstoqueToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "visaoGeralDeEstoqueToolStripMenuItem",
        //         Size = new Size(137, 20),
        //         Text = "Visão geral de estoque"
        //     };            

        //     ToolStripMenuItem abrirEmUmaNovaJanelaToolStripMenuItem = new ToolStripMenuItem
        //     {
        //         Name = "abrirEmUmaNovaJanelaToolStripMenuItem",
        //         Size = new Size(210, 22),
        //         Text = "Abrir em uma nova janela"
        //     };
        //     abrirEmUmaNovaJanelaToolStripMenuItem.Click += ClickAbrirEstoque;

        //     ToolStripMenuItem fecharToolStripMenuItem1 = new ToolStripMenuItem
        //     {
        //         Name = "fecharToolStripMenuItem1",
        //         Size = new Size(210, 22),
        //         Text = "Fechar"
        //     };

        //     // Add drop-down items to programaToolStripMenuItem
        //     programaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        //     {
        //         minimizarToolStripMenuItem,
        //         maximizarToolStripMenuItem,
        //         fecharToolStripMenuItem
        //     });

        //     // Add drop-down items to visaoGeralDeEstoqueToolStripMenuItem
        //     visaoGeralDeEstoqueToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        //     {
        //         abrirEmUmaNovaJanelaToolStripMenuItem,
                
        //     });

        //     // Add menu items to menuStrip1
        //     menuStrip1.Items.AddRange(new ToolStripItem[]
        //     {
        //         programaToolStripMenuItem,
        //         visaoGeralDeEstoqueToolStripMenuItem
        //     });

            InformativoRodape = new Label {
                AutoSize = true,
                BackColor = Color.Wheat,
                Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(553, 477),
                Name = "InformativoRodape",
                Size = new Size(233, 25),
                TabIndex = 40,
                Text = "AgropecuáriaBorbaGato©"
            };

                    //CLIENTES ACIMA//


            // Menu Superior //
            Controls.Add(menuStrip1);
            Controls.Add(InformativoRodape);
            // PEDIDOS Abaixo //

            Controls.Add(LabelDataPedido);
            Controls.Add(LabelQuantidade);
            Controls.Add(LabelPrecoUnitario);
            Controls.Add(LabelValorTotal);
            Controls.Add(LabelObservacoes);
            Controls.Add(Informativo2);
            Controls.Add(InputDataPedido);
            Controls.Add(InputQuantidade);
            Controls.Add(InputPrecoUnitario);
            Controls.Add(InputValorTotal);
            Controls.Add(InputObservacoes);
            Controls.Add(ButtonCriarPedidos);
            Controls.Add(ButtonListarPedido);
            Controls.Add(ButtonAlterarPedidos);
            Controls.Add(ButtonDeletarPedidos);
            Controls.Add(ButtonAbrirEstoque);
            Controls.Add(DGVPedidos);
            ListarPedidos();
             // PEDIDOS ACIMA //          

            // CLIENTES ABAIXO //
            Controls.Add(Informativo1);
            Controls.Add(LabelNome);
            Controls.Add(LabelCpf);
            Controls.Add(LabelTelefone);
            Controls.Add(LabelEmail);
            Controls.Add(InputNome);
            Controls.Add(InputCpf);
            Controls.Add(InputTelefone);
            Controls.Add(InputEmail);
            Controls.Add(ButtonCriarCLiente);
            Controls.Add(ButtonListarClientes);
            Controls.Add(ButtonAlterarCLiente);
            Controls.Add(ButtonDeletarCLiente);
            Controls.Add(DGVClientes); 
            ClickListarCliente();
            // CLIENTES ACIMA //
        }

    // PEDIDOS ABAIXO //
        private void  ListarPedidos()
        {
            List<Pedido> pedidos = ControllerPedidos.ListarPedidos();
            DGVPedidos.Columns.Clear();
            DGVPedidos.AutoGenerateColumns = false;
            DGVPedidos.DataSource = pedidos;

            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdPedido",
                HeaderText = "Id"
            });
            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataPedido",
                HeaderText = "Data"
            });
            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantidade",
                HeaderText = "Quantidade"
            });
            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecoUnitario",
                HeaderText = "Preço Unitário"
            });
            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorTotal",
                HeaderText = "Valor Total"
            });
            DGVPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Observacoes",
                HeaderText = "Observações"
            });
        }

        private void ClickListarPedidos(object? sender, EventArgs e){
            ListarPedidos();
        }

        private void ClickCriarPedido(object? sender, EventArgs e)
        {
            if(InputDataPedido.Text.Length < 1){
                MessageBox.Show("O campo [Data] não pode ser vazio");
                return;
            }
            if(InputQuantidade.Text.Length < 1){
                MessageBox.Show("O campo [Quantidade] não pode ser vazio");
                return;
            }
            if(InputPrecoUnitario.Text.Length < 1){
                MessageBox.Show("O campo [Preço Unitário] não pode ser vazio");
                return;
            }
            if(InputValorTotal.Text.Length < 1){
                MessageBox.Show("O campo [Valor Total] não pode ser vazio");
                return;
            }
            if(InputObservacoes.Text == ""){
                MessageBox.Show("O campo Observações] não pode ser vazio");
                return;
            }
            

            ControllerPedidos.CriarPedido(InputDataPedido.Text, InputQuantidade.Text, InputPrecoUnitario.Text, InputValorTotal.Text, InputObservacoes.Text);

            InputDataPedido.Clear();
            InputQuantidade.Clear();
            InputPrecoUnitario.Clear();
            InputValorTotal.Clear();
            InputObservacoes.Clear();
            ListarPedidos();
            

            
        }

        private void ClickAlterarPedidos(object? sender, EventArgs e)
        {
            int index = DGVPedidos.SelectedRows[0].Index;
            ControllerPedidos.AlterarPedido(index, InputDataPedido.Text, InputQuantidade.Text, InputPrecoUnitario.Text, InputValorTotal.Text, InputObservacoes.Text);
            MessageBox.Show("Pedido atualizado com sucesso");
            
            InputDataPedido.Clear();
            InputQuantidade.Clear();
            InputPrecoUnitario.Clear();
            InputValorTotal.Clear();
            InputObservacoes.Clear();
            ListarPedidos();
        }

        private void ClickDeletarPedido(object? sender, EventArgs e)
        {
            int index = DGVPedidos.SelectedRows[0].Index;
            ControllerPedidos.DeletarPedido(index);
            ListarPedidos();
        }  
    // PEDIDOS ACIMA //
    //CLIENTE ABAIXO//
        private void ClickListarCliente()
        {
            List<Cliente> clientes = ControllerClientes.ListarClientes();
            DGVClientes.Columns.Clear();
            DGVClientes.AutoGenerateColumns = false;
            DGVClientes.DataSource = clientes;

            DGVClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Id"
            });
            DGVClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome"
            });
            DGVClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cpf",
                HeaderText = "Cpf"
            });
            DGVClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefone",
                HeaderText = "Telefone"
            });
            DGVClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });
        }
        private void ClickListarClientes(object? sender, EventArgs e){
            ClickListarCliente();
        }

        private void ClickCriarCLiente(object? sender, EventArgs e)
        {
            if (InputNome.Text.Length < 1)
            {
                MessageBox.Show("O campo [Nome] não pode ser vazio");
                return;
            }
            if (InputCpf.Text.Length < 1)
            {
                MessageBox.Show("O campo [Cpf] não pode ser vazio");
                return;
            }
            if (InputTelefone.Text == "")
            {
                MessageBox.Show("O campo [Telefone] não pode ser vazio");
                return;
            }
            ControllerClientes.CriarCliente(InputNome.Text, InputCpf.Text, InputTelefone.Text, InputEmail.Text);

            InputNome.Clear();
            InputCpf.Clear();
            InputTelefone.Clear();
            InputEmail.Clear();

            ClickListarCliente();
        }

        private void ClickAlterarCLiente(object? sender, EventArgs e)
        {
            int index = DGVClientes.SelectedRows[0].Index;
        
            ControllerClientes.AlterarCliente(index, InputNome.Text, InputCpf.Text, InputTelefone.Text, InputEmail.Text);
            MessageBox.Show("Cliente atualizado com sucesso!");
            
            InputNome.Clear();
            InputCpf.Clear();
            InputTelefone.Clear();
            InputEmail.Clear();

            ClickListarCliente();
        }

        private void ClickDeletarCLiente(object? sender, EventArgs e)
        {
            int index = DGVClientes.SelectedRows[0].Index;
            ControllerClientes.DeletarCliente(index);
            ClickListarCliente();
        }
        private void ClickMinimizar(object? sender, EventArgs e){
            WindowState = FormWindowState.Normal;
        }
        private void ClickMaximizar(object? sender, EventArgs e){
            WindowState = FormWindowState.Maximized;
        }
        private void ClickFechar(object? sender, EventArgs e){
            Close();
        }
        private void ClickAbrirEstoque(object? sender, EventArgs e){
            ViewEstoque viewEstoque = new ViewEstoque();
            viewEstoque.Show();
        }
    }
}
// CLIENTES ACIMA //
