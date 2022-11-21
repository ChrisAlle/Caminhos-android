//Christovam Alves Lemos    18192
//Gustavo Mendes Oliveira   20136

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using apRotasMarte;
using System.IO;

class Grafo
{
    private const int NUM_VERTICES = 200;
    private Vertice[] vertices;
    //matriz das conexões das cidades (a matriz de adjacências)
    private Rota[,] adjMatrix;
    int numVerts;
    DataGridView dgv;   // para exibir a matriz de adjacência num formulário

    // DJIKSTRA
    DistOriginal[] percurso;
    int infinity = 1000000;
    int verticeAtual;   // global usada para indicar o vértice atualmente sendo visitado 
    int doInicioAteAtual;   // global usada para ajustar menor caminho com Djikstra
    int precoDoInicioAteAtual;   // global usada para ajustar menor preco com Djikstra

    //Código utilizado no projeto

    //Construtor vazio
    public Grafo()
    {
        this.dgv = null;
        vertices = new Vertice[NUM_VERTICES];
        adjMatrix = new Rota[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;

        for (int j = 0; j < NUM_VERTICES; j++)      // instancia toda a matriz
        {
            for (int k = 0; k < NUM_VERTICES; k++)
            {
                adjMatrix[j, k] = new Rota(); // instancia sem passar parâmetros, o qual instancia com atributos com o valor de infinity
            }
        }

        percurso = new DistOriginal[NUM_VERTICES];
    }

    //Adiciona um vértice no vetor
    public void NovoVertice(string label)
    {
        //Define que a primeira posição livre do vetor será um novo vértice, passando o nome da cidade como parâmetro
        vertices[numVerts] = new Vertice(label);
        numVerts++;
        if (dgv != null)  // se foi passado como parâmetro um dataGridView para exibição
        {              // se realiza o seu ajuste para a quantidade de vértices
            dgv.RowCount = numVerts + 1;
            dgv.ColumnCount = numVerts + 1;
            dgv.Columns[numVerts].Width = 45;
        }
    }

    public void NovaAresta(string origem, string destino, int distancia, int preco, ArvoreDeBusca<Cidade> arvore)
    {
        int inicial = -1;
        int final = -1;

        //Verifica se a cidade de origem existe
        if (arvore.Existe(new Cidade(origem)))
        {
            //Caso exista, pega sua posição no vetor
            inicial = arvore.Atual.PosicaoNoVetor;

            //Verifica se a cidade de destino existe
            if (arvore.Existe(new Cidade(destino)))
            {
                //Caso exista, pega sua posição no vetor
                final = arvore.Atual.PosicaoNoVetor;

                //Verifica se não existe um caminho entre as cidades
                if (adjMatrix[inicial, final].distancia != infinity)
                    //Caso exista, lança uma exceção
                    throw new Exception("Caminho já cadastrado!");

                //Caso não exista, salva a distância e o preço
                adjMatrix[inicial, final].distancia = distancia;
                adjMatrix[inicial, final].preco = preco;
            }
            //Caso a cidade de destino não exista, lança uma exceção
            else
                throw new Exception(destino + " não existe!");
        }
        //Caso a cidade de origem não exista, lança uma exceção
        else
            throw new Exception(origem + " não existe!");
    }

    //Método para remover um vértice
    public void removerVertice(string vertice, ArvoreDeBusca<Cidade> arvore)
    {
        int vert = -1;

        //Verifica se o vértice existe
        if (arvore.Existe(new Cidade(vertice)))
        {
            //Pega a posição armazenada no nó da árvore
            vert = arvore.Atual.PosicaoNoVetor;
            /*if (dgv != null)
            {
                MessageBox.Show("Matriz de Adjacências antes de remover vértice " +
                              Convert.ToString(vert));
                ExibirAdjacencias();
            }*/

            //Verifica se não foi o útlimo vértice inserido
            if (vert != numVerts - 1)
            {
                for (int j = vert; j < numVerts - 1; j++)   // remove vértice do vetor
                {
                    vertices[j] = vertices[j + 1];
                    vertices[j + 1] = null;
                }

                //Loop para limpar todas as conexões da cidade
                for(int i = 0; i < numVerts; i++)
                {
                    adjMatrix[vert, i] = new Rota();
                    adjMatrix[i, vert] = new Rota();
                }

                // remove vértice da matriz
                for (int row = vert; row < numVerts; row++)
                    moverLinhas(row, numVerts - 1);
                for (int col = vert; col < numVerts; col++)
                    moverColunas(col, numVerts - 1);
            }
            //Define que o número de vértices diminuiu em 1
            numVerts--;
        }
        else
            //Caso não tenha encontrado o vértice
            throw new Exception(vertice + " não existe!");
    }

    //Método para rearranjar a matriz de adjacências após a remoção de um vértice
    private void moverLinhas(int row, int length)
    {
        if (row != numVerts - 1)
            for (int col = 0; col < length; col++)
            {
                adjMatrix[row, col] = adjMatrix[row + 1, col];  // desloca para excluir
                adjMatrix[row + 1, col] = new Rota();
            }
    }

    //Método para rearranjar a matriz de adjacências após a remoção de um vértice
    private void moverColunas(int col, int length)
    {
        if (col != numVerts - 1)
            for (int row = 0; row < length; row++)
            {
                adjMatrix[row, col] = adjMatrix[row, col + 1]; // desloca para excluir
                adjMatrix[row, col + 1] = new Rota();
            }
    }

    //Remoção do controle de windows forms, pois só é necessário retornar o texto do caminho
    public string Caminho(string inicio, string final, ArvoreDeBusca<Cidade> arvore)
    {
        int inicioDoPercurso = -1;
        int finalDoPercurso = -1;

        //Verifica se a cidade de início existe
        if (arvore.Existe(new Cidade(inicio)))
        {
            //Salva em inicioDoPercurso a posição do vetor
            inicioDoPercurso = arvore.Atual.PosicaoNoVetor;

            //Verifica se a cidade final existe
            if (arvore.Existe(new Cidade(final)))
            {
                //Salva em finalDoPercurso a posição do vetor
                finalDoPercurso = arvore.Atual.PosicaoNoVetor;

                //Define que nenhum vértice foi visitado
                for (int j = 0; j < numVerts; j++)
                    vertices[j].FoiVisitado = false;

                for (int j = 0; j < numVerts; j++)
                {
                    // anotamos no vetor percurso a distância e o preço entre o inicioDoPercurso e cada vértice
                    // se não há ligação direta, o valor da distância será infinity
                    int tempDist = adjMatrix[inicioDoPercurso, j].distancia;
                    int tempPrec = adjMatrix[inicioDoPercurso, j].preco;

                    percurso[j] = new DistOriginal(inicioDoPercurso, tempPrec, tempDist);
                }

                for (int nTree = 0; nTree < numVerts; nTree++)
                {
                    // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                    int indiceDoMenor = ObterMenor();

                    // o vértice com a menor distância passa a ser o vértice atual
                    // para compararmos com a distância calculada em AjustarMenorCaminho()
                    verticeAtual = indiceDoMenor;
                    doInicioAteAtual = percurso[indiceDoMenor].distancia;
                    precoDoInicioAteAtual = percurso[indiceDoMenor].preco;

                    // visitamos o vértice com a menor distância desde o inicioDoPercurso
                    vertices[verticeAtual].FoiVisitado = true;
                    AjustarMenorCaminho();
                }

                return ExibirPercursos(inicioDoPercurso, finalDoPercurso);
            }
            else
                return "Cidade " + final + " não foi cadastrada!";
        }
        else
            return "Cidade " + inicio + " não foi cadastrada!";
    }

    //Remoção do controle de windows forms, pois só é necessário retornar o texto do caminho
    public int ObterMenor()
    {
        int distanciaMinima = infinity;
        int indiceDaMinima = 0;
        for (int j = 0; j < numVerts; j++)
            if (!(vertices[j].FoiVisitado) && (percurso[j].distancia < distanciaMinima))
            {
                distanciaMinima = percurso[j].distancia;
                indiceDaMinima = j;
            }
        return indiceDaMinima;
    }

    //Remoção do controle de windows forms, pois só é necessário retornar o texto do caminho
    public void AjustarMenorCaminho()
    {
        for (int coluna = 0; coluna < numVerts; coluna++)
            if (!vertices[coluna].FoiVisitado)       // para cada vértice ainda não visitado
            {
                // acessamos a distância desde o vértice atual (pode ser infinity) e seu preço
                int atualAteMargem = adjMatrix[verticeAtual, coluna].distancia;
                int precoAteMargem = adjMatrix[verticeAtual, coluna].preco;

                // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                // esta saída e o preço
                int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                int precoDoInicioAteMargem = precoDoInicioAteAtual + precoAteMargem;

                // quando encontra uma distância menor, marca o vértice a partir do
                // qual chegamos no vértice de índice coluna, e a soma da distância
                // percorrida para nele chegar
                int distanciaDoCaminho = percurso[coluna].distancia;

                if (doInicioAteMargem < distanciaDoCaminho)
                {
                    percurso[coluna].verticePai = verticeAtual;
                    percurso[coluna].distancia = doInicioAteMargem;
                    percurso[coluna].preco = precoDoInicioAteMargem;
                }
            }
    }

    //Remoção do controle de windows forms, pois só é necessário retornar o texto do caminho
    public string ExibirPercursos(int inicioDoPercurso, int finalDoPercurso)
    {
        string resultado = "";
        int onde = finalDoPercurso;
        Stack<string> pilha = new Stack<string>();
        int distancia = percurso[onde].distancia;
        int preco = percurso[onde].preco;

        int cont = 0;
        while (onde != inicioDoPercurso)
        {
            onde = percurso[onde].verticePai;
            pilha.Push(vertices[onde].Rotulo);
            vertices[onde].EhCaminho = true;
            cont++;
        }

        while (pilha.Count != 0)
        {
            resultado += pilha.Pop();
            if (pilha.Count != 0)
                resultado += " --> ";
        }

        if ((cont == 1) && (percurso[finalDoPercurso].distancia == infinity))
            resultado = "Não há caminho";
        else
        {
            resultado += " --> " + vertices[finalDoPercurso].Rotulo;
            vertices[finalDoPercurso].EhCaminho = true;
            resultado += Environment.NewLine + "Distância: " + distancia + " km";
            resultado += Environment.NewLine + "Tempo estimado de viagem: " + distancia / 12 + " horas";
            if (distancia % 12.0 != 0)
            {
                resultado += " e " + Math.Truncate(((distancia / 12.0) - Math.Truncate(distancia / 12.0)) * 60) + " minutos";
            }
            resultado += Environment.NewLine + "Preço: " + preco + " €";
        }

        return resultado;
    }

    //Método para desenhar as conexões
    //Pede a árvore de busca com os vértices e suas informações, o controlador da imagem e a imagem
    public void DesenharConexoes(ArvoreDeBusca<Cidade> arvore, Graphics tela, PictureBox imagem)
    {
        //Loop para verificar todas as conexões
        for (int j = 0; j < numVerts; j++)
        {
            //Verifica se a cidade da posição j existe na árvore, definindo o atributo atual de arvore como sendo a cidade procurada
            Cidade atual = new Cidade(vertices[j].Rotulo);
            if (arvore.Existe(atual))
            {
                //Pega as informações da cidade e salva em atual
                atual = arvore.Atual.Info;
                //Ponto da localização da cidade
                Point ponto1 = new Point((int)(atual.CoordenadaX * imagem.Width), (int)(atual.CoordenadaY * imagem.Height));

                //Loop para verificar todas as conexões das cidades à frente de atual, para não verificar duas vezes a mesma conexão
                for (int k = j + 1; k < numVerts; k++)
                {
                    //Caso haja uma conexão
                    if (adjMatrix[j, k].distancia != infinity)
                    {
                        //Mesmo passo da cidade anterior, mas para a cidade da posição k
                        atual = new Cidade(vertices[k].Rotulo);
                        if (arvore.Existe(atual))
                        {
                            atual = arvore.Atual.Info;

                            Pen caneta;

                            //Verifica se os vértices formam um caminho usado na última busca do usuário
                            if (vertices[j].EhCaminho && vertices[k].EhCaminho)
                            {
                                //Instancia a caneta que fará a linha da conexão buscada, de cor preta
                                caneta = new Pen(Color.Red);
                                caneta.Width = 4;
                            }
                            else
                            {
                                //Instancia a caneta que fará a linha da conexão não buscada, de cor preta
                                caneta = new Pen(Color.Black);
                                caneta.Width = 2;
                            }

                            //Define o ponto da segunda cidade
                            Point ponto2 = new Point((int)(atual.CoordenadaX * imagem.Width), (int)(atual.CoordenadaY * imagem.Height));
                            //Desenha a conexão
                            tela.DrawLine(caneta, ponto1, ponto2);
                        }
                    }
                }
            }
        }
    }

    //Método para limpar a rota encontrada no mapa
    public void LimparCaminho()
    {
        //Define o atributo ehCaminho de todos os vértices como falso
        for (int j = 0; j < numVerts; j++)
        {
            vertices[j].EhCaminho = false;
        }
    }

    //Método para salvar as conexões num arquivo texto
    public void SalvarGrafo(string enderecoArquivo)
    {
        //Abre o arquivo com o endereço passado
        StreamWriter arquivo = new StreamWriter(enderecoArquivo);

        //Loop para verificar todas as cidades
        for (int i = 0; i < numVerts; i++)
        {
            //Loop para verificar todas as cidades, exceto as verificadas no loop anterior
            for (int j = i + 1; j < numVerts; j++)
            {
                //Verifica se há uma conexão entre as cidades
                if (adjMatrix[i, j].distancia != infinity)
                {
                    //Caso tenha, escreve as informações da conexão no arquivo
                    arquivo.WriteLine(vertices[i].Rotulo.PadRight(15) + vertices[j].Rotulo.PadRight(15) + adjMatrix[i, j].distancia.ToString().PadLeft(4) + adjMatrix[i, j].preco.ToString().PadLeft(5));
                }
            }
        }

        //Fecha o arquivo
        arquivo.Close();
    }

    //Código não utilizado que foi passado em aula

    public Grafo(DataGridView dgv)
    {
        this.dgv = dgv;
        vertices = new Vertice[NUM_VERTICES];
        adjMatrix = new Rota[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;

        for (int j = 0; j < NUM_VERTICES; j++)      // zera toda a matriz
            for (int k = 0; k < NUM_VERTICES; k++)
            {
                adjMatrix[j, k] = new Rota(); // instancia sem passar parâmetros, o qual instancia com atributos com o valor de infinity
            }

        percurso = new DistOriginal[NUM_VERTICES];
    }

    public void NovaAresta(string origem, string destino)
    {
        int inicial = -1;
        int final = -1;
        //Loop para procurar os vértices que estão se relacionando
        for (int i = 0; i < numVerts; i++)
        {
            //Verifica se encontrou um vértice com o nome do vértice de origem
            if (vertices[i].Rotulo.CompareTo(origem) == 0)
            {
                //Salva a posição encontrada
                inicial = i;
            }
            //Verifica se encontrou um vértice com o nome do vértice de destino
            if (vertices[i].Rotulo.CompareTo(destino) == 0)
            {
                //Salva a posição encontrada
                final = i;
            }
            //Caso tenha achado os dois vértices, encerra o loop
            if (inicial != -1 && final != -1)
                break;
        }
        //Caso não tenha encontrado um dos dois vértices, alerta o usuário
        if (inicial == -1)
            throw new Exception("Origem não existe!");

        if (final == -1)
            throw new Exception("Destino não existe!");

        adjMatrix[inicial, final].distancia = 1;
    }

    public void ExibirVertice(int v)
    {
        Console.Write(vertices[v].Rotulo + " ");
    }

    public void ExibirVertice(int v, TextBox txt)
    {
        txt.Text += vertices[v].Rotulo + " ";
    }

    public int SemSucessores() 	// encontra e retorna a linha de um vértice sem sucessores
    {
        bool temAresta;
        for (int linha = 0; linha < numVerts; linha++)
        {
            temAresta = false;
            for (int col = 0; col < numVerts; col++)
                if (adjMatrix[linha, col].distancia != infinity)
                {
                    temAresta = true;
                    break;
                }
            if (!temAresta)
                return linha;
        }
        return -1;
    }

    public void ExibirAdjacencias()
    {
        dgv.RowCount = numVerts + 1;
        dgv.ColumnCount = numVerts + 1;
        for (int j = 0; j < numVerts; j++)
        {
            dgv[0, j + 1].Value = vertices[j].Rotulo;
            dgv[j + 1, 0].Value = vertices[j].Rotulo;
            for (int k = 0; k < numVerts; k++)
            {
                if (adjMatrix[j, k].distancia != infinity)
                {
                    dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.Yellow;
                    dgv[k + 1, j + 1].Value = Convert.ToString(adjMatrix[j, k]);
                }
                else
                {
                    dgv[k + 1, j + 1].Value = "";
                    dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.White;
                }

            }
        }
    }

    //Como removerVertice agora usa a árvore de busca, foi necessária a adição de arvore
    public String OrdenacaoTopologica(ArvoreDeBusca<Cidade> arvore)
    {
        if (dgv != null)
            ExibirAdjacencias();
        Stack<String> gPilha = new Stack<String>(); // para guardar a sequência de vértices
        int origVerts = numVerts;
        while (numVerts > 0)
        {
            int currVertex = SemSucessores();
            if (currVertex == -1)
                return "Erro: grafo possui ciclos.";

            gPilha.Push(vertices[currVertex].Rotulo);   // empilha vértice
            removerVertice(vertices[currVertex].Rotulo, arvore);
        }
        String resultado = "Sequência da Ordenação Topológica: ";
        while (gPilha.Count > 0)
            resultado += gPilha.Pop() + " ";    // desempilha para exibir

        return resultado;
    }

    private int ObterVerticeAdjacenteNaoVisitado(int v)
    {
        for (int j = 0; j <= numVerts - 1; j++)
            if ((adjMatrix[v, j].distancia != infinity) && (!vertices[j].FoiVisitado))
                return j;
        return -1;
    }

    public void PercursoEmProfundidade(TextBox txt)
    {
        txt.Clear();
        Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
        vertices[0].FoiVisitado = true;
        ExibirVertice(0, txt);
        gPilha.Push(0);
        int v;
        while (gPilha.Count > 0)
        {
            v = ObterVerticeAdjacenteNaoVisitado(gPilha.Peek());
            if (v == -1)
                gPilha.Pop();
            else
            {
                vertices[v].FoiVisitado = true;
                ExibirVertice(v, txt);
                gPilha.Push(v);
            }
        }
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
    }

    void ProcessarNo(int i, TextBox txt)
    {
        txt.Text += vertices[i].Rotulo;
    }

    public void PercursoEmProfundidadeRec(int[,] adjMatrix, int numVerts, int part, TextBox txt)
    {
        int i;
        ProcessarNo(part, txt);
        vertices[part].FoiVisitado = true;
        for (i = 0; i < numVerts; ++i)
            if (adjMatrix[part, i] != infinity && !vertices[i].FoiVisitado)
                PercursoEmProfundidadeRec(adjMatrix, numVerts, i, txt);
    }

    public void percursoPorLargura(TextBox txt)
    {
        txt.Clear();
        Queue<int> gQueue = new Queue<int>();
        vertices[0].FoiVisitado = true;
        ExibirVertice(0, txt);
        gQueue.Enqueue(0);
        int vert1, vert2;
        while (gQueue.Count >0 )
        {
            vert1 = gQueue.Dequeue();
            vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
            while (vert2 != -1)
            {
                vertices[vert2].FoiVisitado = true;
                ExibirVertice(vert2, txt);
                gQueue.Enqueue(vert2);
                vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
            }
        }
        for (int i = 0; i < numVerts; i++)
            vertices[i].FoiVisitado = false;
    }

    public void ArvoreGeradoraMinima(int primeiro, TextBox txt)
    {
        txt.Clear();
        Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
        vertices[primeiro].FoiVisitado = true;
        gPilha.Push(primeiro);
        int currVertex, ver;
        while (gPilha.Count > 0)
        {
            currVertex = gPilha.Peek();
            ver = ObterVerticeAdjacenteNaoVisitado(currVertex);
            if (ver == -1)
                gPilha.Pop();
            else
            {
                vertices[ver].FoiVisitado = true;
                gPilha.Push(ver);
                ExibirVertice(currVertex, txt);
                txt.Text += "-->";
                ExibirVertice(ver, txt);
                txt.Text += "  ";
            }
        }
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
    }
}
