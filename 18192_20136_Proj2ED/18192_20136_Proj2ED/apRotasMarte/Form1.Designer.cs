
namespace apRotasMarte
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlgArquivoCidades = new System.Windows.Forms.OpenFileDialog();
            this.dlgArquivoCaminhos = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestinoInserir = new System.Windows.Forms.TextBox();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.txtOrigemInserir = new System.Windows.Forms.TextBox();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.ptbMapa = new System.Windows.Forms.PictureBox();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.lbCaminho = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNomeExcluir = new System.Windows.Forms.TextBox();
            this.btnExcluirCidade = new System.Windows.Forms.Button();
            this.ptbMapaCidades = new System.Windows.Forms.PictureBox();
            this.labelCoordenadaY = new System.Windows.Forms.Label();
            this.labelCoordenadaX = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.txtCoordenadaX = new System.Windows.Forms.TextBox();
            this.txtCoordenadaY = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ptbArvore = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMapa)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMapaCidades)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgArquivoCidades
            // 
            this.dlgArquivoCidades.FileName = "openFileDialog1";
            // 
            // dlgArquivoCaminhos
            // 
            this.dlgArquivoCaminhos.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(4, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 487);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPreco);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtDestinoInserir);
            this.tabPage1.Controls.Add(this.txtDistancia);
            this.tabPage1.Controls.Add(this.txtOrigemInserir);
            this.tabPage1.Controls.Add(this.btnIncluirCaminho);
            this.tabPage1.Controls.Add(this.ptbMapa);
            this.tabPage1.Controls.Add(this.txtCaminho);
            this.tabPage1.Controls.Add(this.lbCaminho);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtDestino);
            this.tabPage1.Controls.Add(this.txtOrigem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Caminhos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            this.txtPreco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreco.Location = new System.Drawing.Point(406, 81);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(117, 20);
            this.txtPreco.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Preço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Distância:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Destino:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Origem:";
            // 
            // txtDestinoInserir
            // 
            this.txtDestinoInserir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinoInserir.Location = new System.Drawing.Point(405, 29);
            this.txtDestinoInserir.Name = "txtDestinoInserir";
            this.txtDestinoInserir.Size = new System.Drawing.Size(117, 20);
            this.txtDestinoInserir.TabIndex = 86;
            this.txtDestinoInserir.TextChanged += new System.EventHandler(this.txtDestinoInserir_TextChanged);
            // 
            // txtDistancia
            // 
            this.txtDistancia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDistancia.Location = new System.Drawing.Point(405, 55);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(117, 20);
            this.txtDistancia.TabIndex = 87;
            // 
            // txtOrigemInserir
            // 
            this.txtOrigemInserir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigemInserir.Location = new System.Drawing.Point(405, 3);
            this.txtOrigemInserir.Name = "txtOrigemInserir";
            this.txtOrigemInserir.Size = new System.Drawing.Size(117, 20);
            this.txtOrigemInserir.TabIndex = 85;
            this.txtOrigemInserir.TextChanged += new System.EventHandler(this.txtOrigemInserir_TextChanged);
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Location = new System.Drawing.Point(260, 33);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(87, 27);
            this.btnIncluirCaminho.TabIndex = 90;
            this.btnIncluirCaminho.Text = "Incluir Caminho";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            this.btnIncluirCaminho.Click += new System.EventHandler(this.btnIncluirCaminho_Click);
            // 
            // ptbMapa
            // 
            this.ptbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbMapa.ErrorImage = null;
            this.ptbMapa.InitialImage = null;
            this.ptbMapa.Location = new System.Drawing.Point(3, 126);
            this.ptbMapa.Name = "ptbMapa";
            this.ptbMapa.Size = new System.Drawing.Size(512, 256);
            this.ptbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMapa.TabIndex = 84;
            this.ptbMapa.TabStop = false;
            // 
            // txtCaminho
            // 
            this.txtCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminho.Location = new System.Drawing.Point(6, 401);
            this.txtCaminho.Multiline = true;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.ReadOnly = true;
            this.txtCaminho.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCaminho.Size = new System.Drawing.Size(625, 57);
            this.txtCaminho.TabIndex = 22;
            // 
            // lbCaminho
            // 
            this.lbCaminho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCaminho.AutoSize = true;
            this.lbCaminho.Location = new System.Drawing.Point(3, 385);
            this.lbCaminho.Name = "lbCaminho";
            this.lbCaminho.Size = new System.Drawing.Size(48, 13);
            this.lbCaminho.TabIndex = 21;
            this.lbCaminho.Text = "Caminho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Para";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "De";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(39, 56);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.Location = new System.Drawing.Point(39, 30);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(124, 20);
            this.txtDestino.TabIndex = 17;
            // 
            // txtOrigem
            // 
            this.txtOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigem.Location = new System.Drawing.Point(39, 6);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(124, 20);
            this.txtOrigem.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtNomeExcluir);
            this.tabPage2.Controls.Add(this.btnExcluirCidade);
            this.tabPage2.Controls.Add(this.ptbMapaCidades);
            this.tabPage2.Controls.Add(this.labelCoordenadaY);
            this.tabPage2.Controls.Add(this.labelCoordenadaX);
            this.tabPage2.Controls.Add(this.labelNome);
            this.tabPage2.Controls.Add(this.txtCoordenadaX);
            this.tabPage2.Controls.Add(this.txtCoordenadaY);
            this.tabPage2.Controls.Add(this.txtCidade);
            this.tabPage2.Controls.Add(this.btnIncluir);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cidades";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Nome:";
            // 
            // txtNomeExcluir
            // 
            this.txtNomeExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeExcluir.Location = new System.Drawing.Point(401, 39);
            this.txtNomeExcluir.Name = "txtNomeExcluir";
            this.txtNomeExcluir.Size = new System.Drawing.Size(117, 20);
            this.txtNomeExcluir.TabIndex = 86;
            this.txtNomeExcluir.TextChanged += new System.EventHandler(this.txtNomeExcluir_TextChanged);
            // 
            // btnExcluirCidade
            // 
            this.btnExcluirCidade.Location = new System.Drawing.Point(401, 6);
            this.btnExcluirCidade.Name = "btnExcluirCidade";
            this.btnExcluirCidade.Size = new System.Drawing.Size(87, 27);
            this.btnExcluirCidade.TabIndex = 87;
            this.btnExcluirCidade.Text = "Excluir Cidade";
            this.btnExcluirCidade.UseVisualStyleBackColor = true;
            this.btnExcluirCidade.Click += new System.EventHandler(this.btnExcluirCidade_Click);
            // 
            // ptbMapaCidades
            // 
            this.ptbMapaCidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMapaCidades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbMapaCidades.ErrorImage = null;
            this.ptbMapaCidades.InitialImage = null;
            this.ptbMapaCidades.Location = new System.Drawing.Point(6, 202);
            this.ptbMapaCidades.Name = "ptbMapaCidades";
            this.ptbMapaCidades.Size = new System.Drawing.Size(512, 256);
            this.ptbMapaCidades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMapaCidades.TabIndex = 85;
            this.ptbMapaCidades.TabStop = false;
            // 
            // labelCoordenadaY
            // 
            this.labelCoordenadaY.AutoSize = true;
            this.labelCoordenadaY.Location = new System.Drawing.Point(6, 94);
            this.labelCoordenadaY.Name = "labelCoordenadaY";
            this.labelCoordenadaY.Size = new System.Drawing.Size(17, 13);
            this.labelCoordenadaY.TabIndex = 43;
            this.labelCoordenadaY.Text = "Y:";
            // 
            // labelCoordenadaX
            // 
            this.labelCoordenadaX.AutoSize = true;
            this.labelCoordenadaX.Location = new System.Drawing.Point(6, 68);
            this.labelCoordenadaX.Name = "labelCoordenadaX";
            this.labelCoordenadaX.Size = new System.Drawing.Size(17, 13);
            this.labelCoordenadaX.TabIndex = 42;
            this.labelCoordenadaX.Text = "X:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(6, 42);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(38, 13);
            this.labelNome.TabIndex = 41;
            this.labelNome.Text = "Nome:";
            // 
            // txtCoordenadaX
            // 
            this.txtCoordenadaX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoordenadaX.Location = new System.Drawing.Point(50, 65);
            this.txtCoordenadaX.Name = "txtCoordenadaX";
            this.txtCoordenadaX.Size = new System.Drawing.Size(121, 20);
            this.txtCoordenadaX.TabIndex = 38;
            this.txtCoordenadaX.TextChanged += new System.EventHandler(this.txtCoordenadaX_TextChanged);
            // 
            // txtCoordenadaY
            // 
            this.txtCoordenadaY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoordenadaY.Location = new System.Drawing.Point(50, 91);
            this.txtCoordenadaY.Name = "txtCoordenadaY";
            this.txtCoordenadaY.Size = new System.Drawing.Size(121, 20);
            this.txtCoordenadaY.TabIndex = 39;
            this.txtCoordenadaY.TextChanged += new System.EventHandler(this.txtCoordenadaY_TextChanged);
            // 
            // txtCidade
            // 
            this.txtCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCidade.Location = new System.Drawing.Point(50, 39);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(121, 20);
            this.txtCidade.TabIndex = 37;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(50, 6);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(85, 27);
            this.btnIncluir.TabIndex = 40;
            this.btnIncluir.Text = "Incluir Cidade";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.ptbArvore);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(525, 461);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Árvore";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ptbArvore
            // 
            this.ptbArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbArvore.Location = new System.Drawing.Point(4, 3);
            this.ptbArvore.Name = "ptbArvore";
            this.ptbArvore.Size = new System.Drawing.Size(646, 407);
            this.ptbArvore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbArvore.TabIndex = 0;
            this.ptbArvore.TabStop = false;
            this.ptbArvore.Click += new System.EventHandler(this.ptbArvore_Click);
            this.ptbArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbArvore_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 491);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Rotas de Marte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMapa)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMapaCidades)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dlgArquivoCidades;
        private System.Windows.Forms.OpenFileDialog dlgArquivoCaminhos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Label lbCaminho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label labelCoordenadaY;
        private System.Windows.Forms.Label labelCoordenadaX;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox txtCoordenadaX;
        private System.Windows.Forms.TextBox txtCoordenadaY;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox ptbArvore;
        private System.Windows.Forms.PictureBox ptbMapa;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestinoInserir;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.TextBox txtOrigemInserir;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.PictureBox ptbMapaCidades;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNomeExcluir;
        private System.Windows.Forms.Button btnExcluirCidade;
    }
}

