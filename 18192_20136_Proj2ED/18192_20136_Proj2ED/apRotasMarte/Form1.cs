using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace apRotasMarte
{
    public partial class Form1 : Form
    {
        //Grafo das rotas das cidades
        Grafo cidades;
        //Árovre de busca das cidades
        ArvoreDeBusca<Cidade> arvore;

        public Form1()
        {
            InitializeComponent();
        }

        //Ao carregar o formulário
        private void Form1_Load(object sender, EventArgs e)
        {
            //Pede o arquivo das cidades
            if (dlgArquivoCidades.ShowDialog() == DialogResult.OK)
            {
                //Pede o arquivo das rotas
                if (dlgArquivoCaminhos.ShowDialog() == DialogResult.OK)
                {
                    //Tenta ler os arquivos
                    try
                    {
                        //Vetor que vai armazenar as cidades temporariamente
                        Cidade[] cidadesParaAArvore = new Cidade[200];
                        int quantasCidades = 0;

                        //Pega o endereço do arquivo das cidades e o abre
                        string endereco = dlgArquivoCidades.FileName;
                        StreamReader arquivoCidades = new StreamReader(endereco);

                        //Loop para ler todo o arquivo
                        while (!arquivoCidades.EndOfStream)
                        {
                            //Lê a linha (uma cidade)
                            string linha = arquivoCidades.ReadLine();

                            //Instancia uma cidade, passando o nome sem espaços e
                            //as coordenadas X e Y
                            Cidade atual = new Cidade(linha.Substring(0, 15).TrimEnd(' '), double.Parse(linha.Substring(15, 6)), double.Parse(linha.Substring(15 + 6, 6)));

                            //Loop para verificar onde será indexada a cidade
                            for(int i = 0; i <= quantasCidades; i++)
                            {
                                //Se a posição atual for nula, significa que é o primeiro espaço vazio
                                //do vetor
                                if (cidadesParaAArvore[i] == null)
                                {
                                    //Aumenta quantasCidades em 1
                                    quantasCidades++;
                                    //Salva a cidade atual na posição
                                    cidadesParaAArvore[i] = atual;
                                    //Encerra o loop
                                    break;
                                }
                                //Caso a cidade já esteja inserida na posição i
                                else if(cidadesParaAArvore[i].CompareTo(atual) == 0)
                                {
                                    //Alerta o usuário
                                    MessageBox.Show("Cidade " + atual.Nome.TrimEnd(' ') + " já inserida! Avançando para a próxima!");
                                    //Encerra o loop
                                    break;
                                }
                                //Caso a cidade da posição atual venha depois
                                //da cidade á ser inserida
                                else if(cidadesParaAArvore[i].CompareTo(atual) > 0)
                                {
                                    //Auenta quantasCidades em 1
                                    quantasCidades++;
                                    //Move todas as cidades desde a da posição atual
                                    //uma casa pra frente
                                    for(int j = quantasCidades; j > i; j--)
                                    {
                                        //Define que a posição j vai armazenar
                                        //a cidade da posição anterior
                                        cidadesParaAArvore[j] = cidadesParaAArvore[j - 1];
                                    }
                                    //Salva a cidade na posição i
                                    cidadesParaAArvore[i] = atual;
                                    //Encerra o loop
                                    break;
                                }
                            }
                        }
                        //Fecha o arquivo das cidades
                        arquivoCidades.Close();

                        //Instancia o grafo e a árvore
                        cidades = new Grafo();
                        arvore = new ArvoreDeBusca<Cidade>();

                        //Lê o vetor de cidades na árvore de busca
                        arvore.LerVetor(cidadesParaAArvore, quantasCidades);

                        //Loop para ler todas as cideades
                        for (int i = 0; i < quantasCidades; i++)
                        {
                            //Adicionar o nome da cidade da posição i como um vértice do grafo
                            cidades.NovoVertice(cidadesParaAArvore[i].Nome.Substring(0, 15).TrimEnd(' '));
                        }

                        //Abre o arquivo das rotas
                        endereco = dlgArquivoCaminhos.FileName;
                        StreamReader arquivoCaminhos = new StreamReader(endereco);

                        //Enquanto não terminar de ler
                        while (!arquivoCaminhos.EndOfStream)
                        {
                            //Lê uma rota
                            string caminhoAtual = arquivoCaminhos.ReadLine();

                            //Chama o método NovaAresta, passando as informações da rota
                            //Esse método é chamado duas vezes para salvar a ida e a volta
                            cidades.NovaAresta(caminhoAtual.Substring(0, 15).TrimEnd(' '), caminhoAtual.Substring(15, 15).TrimEnd(' '), int.Parse(caminhoAtual.Substring(30, 4)), int.Parse(caminhoAtual.Substring(34, 5)), arvore);
                            cidades.NovaAresta(caminhoAtual.Substring(15, 15).TrimEnd(' '), caminhoAtual.Substring(0, 15).TrimEnd(' '), int.Parse(caminhoAtual.Substring(30, 4)), int.Parse(caminhoAtual.Substring(34, 5)), arvore);
                        }
                        //Fecha o arquivo de caminhos
                        arquivoCaminhos.Close();
                    }
                    catch (Exception err)
                    {
                        //Caso ocorra um erro, alerta o usuário e fecha o formulário
                        MessageBox.Show(err.Message);
                        this.Close();
                    }
                }
                //Caso o usuário não dê o arquivo de rotas, fecha o formulário
                else
                    this.Close();
            }
            //Caso o usuário não dê o arquivo de cidades, fecha o formulário
            else
                this.Close();

            //Caso ocorra tudo certo, posiciona lbCaminho e txtCaminho corretamente
            lbCaminho.Location = new Point(lbCaminho.Location.X, ptbMapa.Location.Y + ptbMapa.Height + 10);
            txtCaminho.Location = new Point(txtCaminho.Location.X, ptbMapa.Location.Y + ptbMapa.Height + 30);
        }


        //Ao apertar o botão btnBuscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Chama o método que vai limpar as cidades da última rota pedida
            cidades.LimparCaminho();

            //Pega o nome das cidades de origem e destino
            string ori = txtOrigem.Text.TrimEnd(' ').TrimStart(' ');
            string des = txtDestino.Text.TrimEnd(' ').TrimStart(' ');

            //Verifica se as duas cidades foram passadas
            if(ori == "")
                txtCaminho.Text = "Origem não foi declarada!";
            else if (des == "")
                txtCaminho.Text = "Destino não foi declarado!";
            //Caso sejam a mesma cidade, alerta no bloco de resultados
            else if (ori.CompareTo(des) == 0)
                txtCaminho.Text = "Mesma cidade!";
            else
                //Caso sejam cidades diferentes, chama o método Caminho do grafo
                txtCaminho.Text = cidades.Caminho(ori, des, arvore);

            //Atualiza a página
            this.Refresh();
        }

        //Tela de incluir cidades

        //Evento chamado ao carregar a imagem, seja a primeira vez ou ao alterar o tamanho
        //do formulário
        private void ptbMapaIncluir_Paint(object sender, PaintEventArgs e)
        {
            //Chama o método que vai limpar as cidades da última rota pedida
            cidades.LimparCaminho();

            //Desenha as conexões das rotas
            cidades.DesenharConexoes(arvore, e.Graphics, ptbMapaCidades);

            double coordenadaX;
            double coordenadaY;
            //Tenta pegar as coordenadas passadas pelo usuário
            try
            {
                coordenadaX = double.Parse(txtCoordenadaX.Text.Replace('.', ','));
                coordenadaY = double.Parse(txtCoordenadaY.Text.Replace('.', ','));
            }
            //Caso não consiga
            catch
            {
                //Sai do evento
                return;
            }
            //Verifica se as coordenadas são 0
            if (coordenadaX == 0 || coordenadaY == 0)
                //Caso alguma delas seja, sai do evento
                return;

            //Caso as coordenadas tenham sido lidas corretamente
            //Instancia um pincel de cor roxa
            SolidBrush pincel = new SolidBrush(Color.Purple);
            //Desenha um círculo na posição onde a cidade será inserida,
            //para o usuário poder ajustar as coordenadas com facilidade
            e.Graphics.FillEllipse(pincel, (float)coordenadaX * ptbMapaCidades.Width - 5, (float)coordenadaY * ptbMapaCidades.Height - 5, 10, 10);
        }

        //Ao clicar no botão de incluir cidade
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            //Pega o nome da cidade, removendo espaços antes e depois
            string nome = txtCidade.Text.TrimStart(' ').TrimEnd(' ');

            double coordenadaX;
            double coordenadaY;

            //Tenta pegar as coordenadas
            try
            {
                coordenadaX = double.Parse(txtCoordenadaX.Text.Replace('.',','));
                coordenadaY = double.Parse(txtCoordenadaY.Text.Replace('.', ','));
            }
            //Caso não consiga
            catch
            {
                //Alerta o usuário que as coordenadas são inválidas
                MessageBox.Show("Digite um número válido para as coordenadas!");

                //Sai do evento
                return;
            }

            //Caso não tenha passado um nome
            if (nome == "")
            {
                //Alerta o usuário
                MessageBox.Show("Digite o nome da cidade!");

                //Sai do evento
                return;
            }

            //Caso o nome tenha mais caracteres que o limite
            if (nome.Length > 15)
            {
                //Alerta o usuário
                MessageBox.Show("O nome da cidade pode ter, no máximo, 15 caracteres!");

                //Sai do evento
                return;
            }

            //Caso a coordenada X seja negativa ou maior que 1
            if (coordenadaX < 0 || coordenadaX > 1)
            {
                //Alerta o usuário
                MessageBox.Show("Digite uma coordenada entre 0 e 1!");

                //Sai do evento
                return;
            }

            //Mesma verificação, mas com a coordenada Y
            if (coordenadaY < 0 || coordenadaY > 1)
            {
                MessageBox.Show("Digite uma coordenada entre 0 e 1!");
                return;
            }

            //Tenta inserir a cidade
            try
            {
                //Instancia uma cidade com as informações passadas
                Cidade cidadeIncluida = new Cidade(nome, coordenadaX, coordenadaY);

                //Inclui a cidade na árvore
                arvore.Incluir(cidadeIncluida);
                //Inclui a cidade no grafo
                cidades.NovoVertice(nome);
            }
            //Caso ocorra um erro, alerta o usuário
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

            //No fim, recarrega o formulário
            this.Refresh();
        }

        //Evento chamado ao modificar o texto de txtCoordenadaX
        private void txtCoordenadaX_TextChanged(object sender, EventArgs e)
        {
            //Recarrega o formulário, assim chamando o evento paint da imagem
            this.Refresh();
        }

        //Mesmo evento que o de txtCoordenadaX
        private void txtCoordenadaY_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }


       

        //Tela de excluir cidades

        //Evento chamado ao carregar a imagem, seja a primeira vez ou ao alterar o tamanho
        //do formulário
        private void ptbMapaExcluirCidade_Paint(object sender, PaintEventArgs e)
        {
            //Chama o método que vai limpar as cidades da última rota pedida
            cidades.LimparCaminho();

            //Desenha as conexões das rotas
            cidades.DesenharConexoes(arvore, e.Graphics, ptbMapaCidades);

            //Pega o nome da cidade, removendo espaços antes e depois
            string cidadeTexto = txtNomeExcluir.Text.TrimStart(' ').TrimEnd(' ');

            //Instancia uma cidade com o nome passado e verifica se ela existe
            Cidade cidade = new Cidade(cidadeTexto);
            if (arvore.Existe(cidade))
            {
                //Caso exista, pega suas informaçãos
                cidade = arvore.Atual.Info;
                double coordenadaX = cidade.CoordenadaX;
                double coordenadaY = cidade.CoordenadaY;

                //Cria um pincel de cor vermelha
                SolidBrush pincel = new SolidBrush(Color.Red);

                //Desenha um círculo sobre a cidade que será excluída, para facilitar a visualização
                e.Graphics.FillEllipse(pincel, (float)coordenadaX * ptbMapaCidades.Width - 5, (float)coordenadaY * ptbMapaCidades.Height - 5, 10, 10);
            }
        }

        //Tela da árvore

        //Evento chamado ao carregar a imagem, seja a primeira vez ou ao alterar o tamanho
        //do formulário
        private void ptbArvore_Paint(object sender, PaintEventArgs e)
        {
            //Desenha a árvore na tela
            arvore.DesenharArvore(true, arvore.Raiz, ptbArvore.Width / 2, 0, Math.PI / 2, Math.PI / 2, 300, e.Graphics);
        }

        //Ao fechar o formulário
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Caso tenham sido passadas ambos os arquivos
            if (dlgArquivoCaminhos.FileName != "openFileDialog1")
            {
                //Salva as cidades no primeiro arquivo
                arvore.GravarArquivoDeRegistros(dlgArquivoCidades.FileName);
                //Salva as conexões no segundo arquivo
                cidades.SalvarGrafo(dlgArquivoCaminhos.FileName);
            }
        }

        private void ptbArvore_Click(object sender, EventArgs e)
        {

        }

        //Tela de caminhos

        //Ao clicar no botão de incuir caminho
        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            //Pega o nome das cidades de origem e de edstino
            string origem = txtOrigemInserir.Text.TrimStart(' ').TrimEnd(' ');
            string destino = txtDestinoInserir.Text.TrimStart(' ').TrimEnd(' ');
            int distancia;
            int preco;

            //Tenta pegar a distância
            try
            {
                distancia = int.Parse(txtDistancia.Text.TrimEnd(' ').TrimStart(' '));
            }
            catch
            {
                //Caso falhe, alerta o usuário e encerra o evento
                MessageBox.Show("Digite um número válido para a distância!");
                return;
            }
            //Tenta pegar o preço
            try
            {
                preco = int.Parse(txtPreco.Text.TrimEnd(' ').TrimStart(' '));
            }
            catch
            {
                //Caso falhe, alerta o usuário e encerra o evento
                MessageBox.Show("Digite um valor válido para o preço!");
                return;
            }

            //Veirica se as cidades foram passadas
            //Caso não tenham sido passadas, alerta o usuário e encerra o evento
            if (origem == "")
            {
                MessageBox.Show("Digite o nome da origem!");
                return;
            }

            if (destino == "")
            {
                MessageBox.Show("Digite o nome do destino!");
                return;
            }

            //Verifica se a distância é positiva e possui, no máximo, quatro caracteres
            if (distancia < 0 || distancia > 9999)
            {
                //Caso não, alerta o usuário e encerra o evento
                MessageBox.Show("A distância deve ser maior que 0 e ter, no máximo, 4 caracteres!");
                return;
            }

            //Verifica se o preço é positivo e possui, no máximo, cinco caracteres
            if (preco < 0 || preco > 99999)
            {
                //Caso não, alerta o usuário e encerra o evento
                MessageBox.Show("O preço deve ser maior que 0 e ter, no máximo, 5 caracteres!");
                return;
            }

            //Caso todas as informação estejam nos conformes
            try
            {
                //Adiciona a rota, ida e volta
                cidades.NovaAresta(origem, destino, distancia, preco, arvore);
                cidades.NovaAresta(destino, origem, distancia, preco, arvore);
            }
            //Caso ocorra um erro
            catch (Exception erro)
            {
                //Alerta o usuário qual foi o erro
                MessageBox.Show(erro.Message);
            }

            //Atualiza o formulário
            this.Refresh();
        }

        //Evento chamado ao modificar o texto de txtOrigemInserir
        private void txtOrigemInserir_TextChanged(object sender, EventArgs e)
        {
            //Recarrega o formulário, assim chamando o evento paint da imagem
            this.Refresh();
        }

        //Mesmo evento que o de txtOrigemInserir
        private void txtDestinoInserir_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            //Tenta excluir a cidade passada
            try
            {
                //Pega o nome, removendo espaços antes de depois
                string cidadeTexto = txtNomeExcluir.Text.TrimStart(' ').TrimEnd(' ');

                //Remove a cidade, passando a árvore
                cidades.removerVertice(cidadeTexto, arvore);

                //Cria uma cidade, passando o nome
                Cidade cidade = new Cidade(cidadeTexto);

                //Remove a cidade com o mesmo nome da árvore de busca
                arvore.Excluir(cidade);

                //Atualiza o formulário
                this.Refresh();
            }
            //Caso ocorra um erro, alerta o usuário
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //Evento chamado ao modificar o texto de txtNomeExcluir
        private void txtNomeExcluir_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void txtTempo_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        //Evento chamado ao carregar a imagem, seja a primeira vez ou ao alterar o tamanho
        //do formulário
        private void ptbMapa_paint(object sender, PaintEventArgs e)
        {
            //Posiciona lbCaminho e txtCaminho corretamente
            lbCaminho.Location = new Point(lbCaminho.Location.X, ptbMapa.Location.Y + ptbMapa.Height + 10);
            txtCaminho.Location = new Point(txtCaminho.Location.X, ptbMapa.Location.Y + ptbMapa.Height + 30);

            //Desenha as conexões das rotas
            cidades.DesenharConexoes(arvore, e.Graphics, ptbMapa);
        }
    }
}
