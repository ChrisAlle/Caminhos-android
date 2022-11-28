package com.example.apcaminhosmarte;

public class Grafo {
    class Grafo {

        private const int NUM_VERTICES = 200;

        private Vertice[] vertices;

        // matriz das conex�es das cidades (a matriz de adjac�ncias)
        private Rota[,] adjMatrix;

        int numVerts;

        DataGridView dgv;

        //  para exibir a matriz de adjac�ncia num formul�rio
        //  DJIKSTRA
        DistOriginal[] percurso;

        int infinity = 1000000;

        int verticeAtual;

        //  global usada para indicar o v�rtice atualmente sendo visitado
        int doInicioAteAtual;

        //  global usada para ajustar menor caminho com Djikstra
        int precoDoInicioAteAtual;

        //  global usada para ajustar menor preco com Djikstra
        // C�digo utilizado no projeto
        // Construtor vazio
        public Grafo() {
            this.dgv = null;
            this.vertices = new Vertice[NUM_VERTICES];
            this.adjMatrix = new Rota[NUM_VERTICES];
            NUM_VERTICES;
            this.numVerts = 0;
            for (int j = 0; (j < NUM_VERTICES); j++) {
                for (int k = 0; (k < NUM_VERTICES); k++) {
                    this.adjMatrix[j, k] = new Rota();
                    //  instancia sem passar par�metros, o qual instancia com atributos com o valor de infinity
                }

            }

            this.percurso = new DistOriginal[NUM_VERTICES];
        }

        // Adiciona um v�rtice no vetor
        public final void NovoVertice(string label) {
            // Define que a primeira posi��o livre do vetor ser� um novo v�rtice, passando o nome da cidade como par�metro
            this.vertices[this.numVerts] = new Vertice(label);
            this.numVerts++;
            if ((this.dgv != null)) {
                //  se realiza o seu ajuste para a quantidade de v�rtices
                this.dgv.RowCount = (this.numVerts + 1);
                this.dgv.ColumnCount = (this.numVerts + 1);
                this.dgv.Columns[this.numVerts].Width = 45;
            }

        }

        public final void NovaAresta(string origem, string destino, int distancia, int preco, ArvoreDeBusca<Cidade> arvore) {
            int inicial = -1;
            int final = -1;
            // Verifica se a cidade de origem existe
            if (arvore.Existe(new Cidade(origem))) {
                // Caso exista, pega sua posi��o no vetor
                inicial = arvore.Atual.PosicaoNoVetor;
                // Verifica se a cidade de destino existe
                if (arvore.Existe(new Cidade(destino))) {
                    // Caso exista, pega sua posi��o no vetor
                    final = arvore.Atual.PosicaoNoVetor;
                    // Verifica se n�o existe um caminho entre as cidades
                    if ((this.adjMatrix[inicial, final].distancia != this.infinity)) {
                        throw new Exception("Caminho j� cadastrado!");
                    }

                    this.adjMatrix[inicial, final].distancia = distancia;
                    this.adjMatrix[inicial, final].preco = preco;
                }

                // Caso a cidade de destino n�o exista, lan�a uma exce��o
                throw new Exception((destino + " n�o existe!"));
            }

            // Caso a cidade de origem n�o exista, lan�a uma exce��o
            throw new Exception((origem + " n�o existe!"));
        }

        // M�todo para remover um v�rtice
        public final void removerVertice(string vertice, ArvoreDeBusca<Cidade> arvore) {
            int vert = -1;
            // Verifica se o v�rtice existe
            if (arvore.Existe(new Cidade(vertice))) {
                // Pega a posi��o armazenada no n� da �rvore
                vert = arvore.Atual.PosicaoNoVetor;
                // Verifica se n�o foi o �tlimo v�rtice inserido
                if ((vert
                        != (this.numVerts - 1))) {
                    for (int j = vert; (j
                            < (this.numVerts - 1)); j++) {
                        this.vertices[j] = this.vertices[(j + 1)];
                        this.vertices[(j + 1)] = null;
                    }

                    // Loop para limpar todas as conex�es da cidade
                    for (int i = 0; (i < this.numVerts); i++) {
                        this.adjMatrix[vert, i] = new Rota();
                        this.adjMatrix[i, vert] = new Rota();
                    }

                    //  remove v�rtice da matriz
                    for (int row = vert; (row < this.numVerts); row++) {
                        this.moverLinhas(row, (this.numVerts - 1));
                    }

                    for (int col = vert; (col < this.numVerts); col++) {
                        this.moverColunas(col, (this.numVerts - 1));
                    }

                }

                // Define que o n�mero de v�rtices diminuiu em 1
                this.numVerts--;
            }
            else {
                throw new Exception((vertice + " n�o existe!"));
            }

        }

        // M�todo para rearranjar a matriz de adjac�ncias ap�s a remo��o de um v�rtice
        private final void moverLinhas(int row, int length) {
            if ((row
                    != (this.numVerts - 1))) {
                for (int col = 0; (col < length); col++) {
                    this.adjMatrix[row, col] = this.adjMatrix[(row + 1), col];
                    //  desloca para excluir
                    this.adjMatrix[(row + 1), col] = new Rota();
                }

            }

        }

        // M�todo para rearranjar a matriz de adjac�ncias ap�s a remo��o de um v�rtice
        private final void moverColunas(int col, int length) {
            if ((col
                    != (this.numVerts - 1))) {
                for (int row = 0; (row < length); row++) {
                    this.adjMatrix[row, col] = this.adjMatrix[row, (col + 1)];
                    //  desloca para excluir
                    this.adjMatrix[row, (col + 1)] = new Rota();
                }

            }

        }

        // Remo��o do controle de windows forms, pois s� � necess�rio retornar o texto do caminho
        public final string Caminho(string inicio, string final, ArvoreDeBusca<Cidade> arvore) {
            int inicioDoPercurso = -1;
            int finalDoPercurso = -1;
            // Verifica se a cidade de in�cio existe
            if (arvore.Existe(new Cidade(inicio))) {
                // Salva em inicioDoPercurso a posi��o do vetor
                inicioDoPercurso = arvore.Atual.PosicaoNoVetor;
                // Verifica se a cidade final existe
                if (arvore.Existe(new Cidade(final))) {
                    // Salva em finalDoPercurso a posi��o do vetor
                    finalDoPercurso = arvore.Atual.PosicaoNoVetor;
                    // Define que nenhum v�rtice foi visitado
                    for (int j = 0; (j < this.numVerts); j++) {
                        this.vertices[j].FoiVisitado = false;
                    }

                    for (int j = 0; (j < this.numVerts); j++) {
                        //  anotamos no vetor percurso a dist�ncia e o pre�o entre o inicioDoPercurso e cada v�rtice
                        //  se n�o h� liga��o direta, o valor da dist�ncia ser� infinity
                        int tempDist = this.adjMatrix[inicioDoPercurso, j].distancia;
                        int tempPrec = this.adjMatrix[inicioDoPercurso, j].preco;
                        this.percurso[j] = new DistOriginal(inicioDoPercurso, tempPrec, tempDist);
                    }

                    for (int nTree = 0; (nTree < this.numVerts); nTree++) {
                        //  Procuramos a sa�da n�o visitada do v�rtice inicioDoPercurso com a menor dist�ncia
                        int indiceDoMenor = this.ObterMenor();
                        //  o v�rtice com a menor dist�ncia passa a ser o v�rtice atual
                        //  para compararmos com a dist�ncia calculada em AjustarMenorCaminho()
                        this.verticeAtual = indiceDoMenor;
                        this.doInicioAteAtual = this.percurso[indiceDoMenor].distancia;
                        this.precoDoInicioAteAtual = this.percurso[indiceDoMenor].preco;
                        //  visitamos o v�rtice com a menor dist�ncia desde o inicioDoPercurso
                        this.vertices[this.verticeAtual].FoiVisitado = true;
                        this.AjustarMenorCaminho();
                    }

                    return this.ExibirPercursos(inicioDoPercurso, finalDoPercurso);
                }
            else {
                    return ("Cidade "
                            + (final + " n�o foi cadastrada!"));
                }

            }
            else {
                return ("Cidade "
                        + (inicio + " n�o foi cadastrada!"));
            }

        }

        // Remo��o do controle de windows forms, pois s� � necess�rio retornar o texto do caminho
        public final int ObterMenor() {
            int distanciaMinima = this.infinity;
            int indiceDaMinima = 0;
            for (int j = 0; (j < this.numVerts); j++) {
                if ((!this.vertices[j].FoiVisitado
                        && (this.percurso[j].distancia < distanciaMinima))) {
                    distanciaMinima = this.percurso[j].distancia;
                    indiceDaMinima = j;
                }

            }

            return indiceDaMinima;
        }

        // Remo��o do controle de windows forms, pois s� � necess�rio retornar o texto do caminho
        public final void AjustarMenorCaminho() {
            for (int coluna = 0; (coluna < this.numVerts); coluna++) {
                if (!this.vertices[coluna].FoiVisitado) {
                    //  acessamos a dist�ncia desde o v�rtice atual (pode ser infinity) e seu pre�o
                    int atualAteMargem = this.adjMatrix[this.verticeAtual, coluna].distancia;
                    int precoAteMargem = this.adjMatrix[this.verticeAtual, coluna].preco;
                    //  calculamos a dist�ncia desde inicioDoPercurso passando por vertice atual at�
                    //  esta sa�da e o pre�o
                    int doInicioAteMargem = (this.doInicioAteAtual + atualAteMargem);
                    int precoDoInicioAteMargem = (this.precoDoInicioAteAtual + precoAteMargem);
                    //  quando encontra uma dist�ncia menor, marca o v�rtice a partir do
                    //  qual chegamos no v�rtice de �ndice coluna, e a soma da dist�ncia
                    //  percorrida para nele chegar
                    int distanciaDoCaminho = this.percurso[coluna].distancia;
                    if ((doInicioAteMargem < distanciaDoCaminho)) {
                        this.percurso[coluna].verticePai = this.verticeAtual;
                        this.percurso[coluna].distancia = doInicioAteMargem;
                        this.percurso[coluna].preco = precoDoInicioAteMargem;
                    }

                }

            }

        }

        // Remo��o do controle de windows forms, pois s� � necess�rio retornar o texto do caminho
        public final string ExibirPercursos(int inicioDoPercurso, int finalDoPercurso) {
            string resultado = "";
            int onde = finalDoPercurso;
            Stack<string> pilha = new Stack<string>();
            int distancia = this.percurso[onde].distancia;
            int preco = this.percurso[onde].preco;
            int cont = 0;
            while ((onde != inicioDoPercurso)) {
                onde = this.percurso[onde].verticePai;
                pilha.Push(this.vertices[onde].Rotulo);
                this.vertices[onde].EhCaminho = true;
                cont++;
            }

            while ((pilha.Count != 0)) {
                resultado = (resultado + pilha.Pop());
                if ((pilha.Count != 0)) {
                    resultado += " --> ";
                }

            }

            if (((cont == 1)
                    && (this.percurso[finalDoPercurso].distancia == this.infinity))) {
                resultado = "N�o h� caminho";
            }
            else {
                resultado = (resultado + (" --> " + this.vertices[finalDoPercurso].Rotulo));
                this.vertices[finalDoPercurso].EhCaminho = true;
                resultado = (resultado
                        + (Environment.NewLine + ("Dist�ncia: "
                        + (distancia + " km"))));
                resultado = (resultado
                        + (Environment.NewLine + ("Tempo estimado de viagem: "
                        + ((distancia / 12)
                        + " horas"))));
                if (((distancia % 12)
                        != 0)) {
                    resultado = (resultado + (" e "
                            + (Math.Truncate((((distancia / 12)
                            - Math.Truncate((distancia / 12)))
                            * 60)) + " minutos")));
                }

                resultado = (resultado
                        + (Environment.NewLine + ("Pre�o: "
                        + (preco + " �"))));
            }

            return resultado;
        }

        // M�todo para desenhar as conex�es
        // Pede a �rvore de busca com os v�rtices e suas informa��es, o controlador da imagem e a imagem
        public final void DesenharConexoes(ArvoreDeBusca<Cidade> arvore, Graphics tela, PictureBox imagem) {
            // Loop para verificar todas as conex�es
            for (int j = 0; (j < this.numVerts); j++) {
                // Verifica se a cidade da posi��o j existe na �rvore, definindo o atributo atual de arvore como sendo a cidade procurada
                Cidade atual = new Cidade(this.vertices[j].Rotulo);
                if (arvore.Existe(atual)) {
                    // Pega as informa��es da cidade e salva em atual
                    atual = arvore.Atual.Info;
                    // Ponto da localiza��o da cidade
                    Point ponto1 = new Point(((int)((atual.CoordenadaX * imagem.Width))), ((int)((atual.CoordenadaY * imagem.Height))));
                    // Loop para verificar todas as conex�es das cidades � frente de atual, para n�o verificar duas vezes a mesma conex�o
                    for (int k = (j + 1); (k < this.numVerts); k++) {
                        // Caso haja uma conex�o
                        if ((this.adjMatrix[j, k].distancia != this.infinity)) {
                            // Mesmo passo da cidade anterior, mas para a cidade da posi��o k
                            atual = new Cidade(this.vertices[k].Rotulo);
                            if (arvore.Existe(atual)) {
                                atual = arvore.Atual.Info;
                                Pen caneta;
                                // Verifica se os v�rtices formam um caminho usado na �ltima busca do usu�rio
                                if ((this.vertices[j].EhCaminho && this.vertices[k].EhCaminho)) {
                                    // Instancia a caneta que far� a linha da conex�o buscada, de cor preta
                                    caneta = new Pen(Color.Red);
                                    caneta.Width = 4;
                                }
                                else {
                                    // Instancia a caneta que far� a linha da conex�o n�o buscada, de cor preta
                                    caneta = new Pen(Color.Black);
                                    caneta.Width = 2;
                                }

                                // Define o ponto da segunda cidade
                                Point ponto2 = new Point(((int)((atual.CoordenadaX * imagem.Width))), ((int)((atual.CoordenadaY * imagem.Height))));
                                // Desenha a conex�o
                                tela.DrawLine(caneta, ponto1, ponto2);
                            }

                        }

                    }

                }

            }

        }

        // M�todo para limpar a rota encontrada no mapa
        public final void LimparCaminho() {
            // Define o atributo ehCaminho de todos os v�rtices como falso
            for (int j = 0; (j < this.numVerts); j++) {
                this.vertices[j].EhCaminho = false;
            }

        }

        // M�todo para salvar as conex�es num arquivo texto
        public final void SalvarGrafo(string enderecoArquivo) {
            // Abre o arquivo com o endere�o passado
            StreamWriter arquivo = new StreamWriter(enderecoArquivo);
            // Loop para verificar todas as cidades
            for (int i = 0; (i < this.numVerts); i++) {
                // Loop para verificar todas as cidades, exceto as verificadas no loop anterior
                for (int j = (i + 1); (j < this.numVerts); j++) {
                    // Verifica se h� uma conex�o entre as cidades
                    if ((this.adjMatrix[i, j].distancia != this.infinity)) {
                        // Caso tenha, escreve as informa��es da conex�o no arquivo
                        arquivo.WriteLine((this.vertices[i].Rotulo.PadRight(15)
                                + (this.vertices[j].Rotulo.PadRight(15)
                                + (this.adjMatrix[i, j].distancia.ToString().PadLeft(4) + this.adjMatrix[i, j].preco.ToString().PadLeft(5)))));
                    }

                }

            }

            // Fecha o arquivo
            arquivo.Close();
        }

        // C�digo n�o utilizado que foi passado em aula
        public Grafo(DataGridView dgv) {
            this.dgv = this.dgv;
            this.vertices = new Vertice[NUM_VERTICES];
            this.adjMatrix = new Rota[NUM_VERTICES];
            NUM_VERTICES;
            this.numVerts = 0;
            for (int j = 0; (j < NUM_VERTICES); j++) {
                for (int k = 0; (k < NUM_VERTICES); k++) {
                    this.adjMatrix[j, k] = new Rota();
                    //  instancia sem passar par�metros, o qual instancia com atributos com o valor de infinity
                }

            }

            this.percurso = new DistOriginal[NUM_VERTICES];
        }

        public final void NovaAresta(string origem, string destino) {
            int inicial = -1;
            int final = -1;
            // Loop para procurar os v�rtices que est�o se relacionando
            for (int i = 0; (i < this.numVerts); i++) {
                // Verifica se encontrou um v�rtice com o nome do v�rtice de origem
                if ((this.vertices[i].Rotulo.CompareTo(origem) == 0)) {
                    // Salva a posi��o encontrada
                    inicial = i;
                }

                // Verifica se encontrou um v�rtice com o nome do v�rtice de destino
                if ((this.vertices[i].Rotulo.CompareTo(destino) == 0)) {
                    // Salva a posi��o encontrada
                    final = i;
                }

                // Caso tenha achado os dois v�rtices, encerra o loop
                if (((inicial != -1)
                        && (final != -1))) {
                    break;
                }

            }

            // Caso n�o tenha encontrado um dos dois v�rtices, alerta o usu�rio
            if ((inicial == -1)) {
                throw new Exception("Origem n�o existe!");
            }

            if ((final == -1)) {
                throw new Exception("Destino n�o existe!");
            }

            this.adjMatrix[inicial, final].distancia = 1;
        }

        public final void ExibirVertice(int v) {
            Console.Write((this.vertices[v].Rotulo + " "));
        }

        public final void ExibirVertice(int v, TextBox txt) {
            txt.Text = (txt.Text
                    + (this.vertices[v].Rotulo + " "));
        }

        public final int SemSucessores() {
            boolean temAresta;
            for (int linha = 0; (linha < this.numVerts); linha++) {
                temAresta = false;
                for (int col = 0; (col < this.numVerts); col++) {
                    if ((this.adjMatrix[linha, col].distancia != this.infinity)) {
                        temAresta = true;
                        break;
                    }

                }

                if (!temAresta) {
                    return linha;
                }

            }

            return -1;
        }

        public final void ExibirAdjacencias() {
            this.dgv.RowCount = (this.numVerts + 1);
            this.dgv.ColumnCount = (this.numVerts + 1);
            for (int j = 0; (j < this.numVerts); j++) {
                this.dgv[0, (j + 1)].Value = this.vertices[j].Rotulo;
                this.dgv[(j + 1), 0].Value = this.vertices[j].Rotulo;
                for (int k = 0; (k < this.numVerts); k++) {
                    if ((this.adjMatrix[j, k].distancia != this.infinity)) {
                        this.dgv[(k + 1), (j + 1)].Style.BackColor = System.Drawing.Color.Yellow;
                        this.dgv[(k + 1), (j + 1)].Value = Convert.ToString(this.adjMatrix[j, k]);
                    }
                else {
                        this.dgv[(k + 1), (j + 1)].Value = "";
                        this.dgv[(k + 1), (j + 1)].Style.BackColor = System.Drawing.Color.White;
                    }

                }

            }

        }

        // Como removerVertice agora usa a �rvore de busca, foi necess�ria a adi��o de arvore
        public final String OrdenacaoTopologica(ArvoreDeBusca<Cidade> arvore) {
            if ((this.dgv != null)) {
                this.ExibirAdjacencias();
            }

            Stack<String> gPilha = new Stack<String>();
            //  para guardar a sequ�ncia de v�rtices
            int origVerts = this.numVerts;
            while ((this.numVerts > 0)) {
                int currVertex = this.SemSucessores();
                if ((currVertex == -1)) {
                    return "Erro: grafo possui ciclos.";
                }

                gPilha.Push(this.vertices[currVertex].Rotulo);
                //  empilha v�rtice
                this.removerVertice(this.vertices[currVertex].Rotulo, arvore);
            }

            String resultado = "Sequ�ncia da Ordena��o Topol�gica: ";
            while ((gPilha.Count > 0)) {
                resultado = (resultado
                        + (gPilha.Pop() + " "));
            }

            //  desempilha para exibir
            return resultado;
        }

        private final int ObterVerticeAdjacenteNaoVisitado(int v) {
            for (int j = 0; (j
                    <= (this.numVerts - 1)); j++) {
                if (((this.adjMatrix[v, j].distancia != this.infinity)
                        && !this.vertices[j].FoiVisitado)) {
                    return j;
                }

            }

            return -1;
        }

        public final void PercursoEmProfundidade(TextBox txt) {
            txt.Clear();
            Stack<int> gPilha = new Stack<int>();
            //  para guardar a sequ�ncia de v�rtices
            for (int j = 0; (j
                    <= (this.numVerts - 1)); j++) {
                this.vertices[j].FoiVisitado = false;
            }

            this.vertices[0].FoiVisitado = true;
            this.ExibirVertice(0, txt);
            gPilha.Push(0);
            int v;
            while ((gPilha.Count > 0)) {
                v = this.ObterVerticeAdjacenteNaoVisitado(gPilha.Peek());
                if ((v == -1)) {
                    gPilha.Pop();
                }
                else {
                    this.vertices[v].FoiVisitado = true;
                    this.ExibirVertice(v, txt);
                    gPilha.Push(v);
                }

            }

            for (int j = 0; (j
                    <= (this.numVerts - 1)); j++) {
                this.vertices[j].FoiVisitado = false;
            }

        }

        final void ProcessarNo(int i, TextBox txt) {
            txt.Text = (txt.Text + this.vertices[i].Rotulo);
        }

        public final void PercursoEmProfundidadeRec(int[,] adjMatrix, int numVerts, int part, TextBox txt) {
            int i;
            this.ProcessarNo(part, txt);
            this.vertices[part].FoiVisitado = true;
            for (i = 0; (i < this.numVerts); i++) {
                if (((this.adjMatrix[part, i] != this.infinity)
                        && !this.vertices[i].FoiVisitado)) {
                    this.PercursoEmProfundidadeRec(this.adjMatrix, this.numVerts, i, txt);
                }

            }

        }

        public final void percursoPorLargura(TextBox txt) {
            txt.Clear();
            Queue<int> gQueue = new Queue<int>();
            this.vertices[0].FoiVisitado = true;
            this.ExibirVertice(0, txt);
            gQueue.Enqueue(0);
            int vert2;
            int vert1;
            while ((gQueue.Count > 0)) {
                vert1 = gQueue.Dequeue();
                vert2 = this.ObterVerticeAdjacenteNaoVisitado(vert1);
                while ((vert2 != -1)) {
                    this.vertices[vert2].FoiVisitado = true;
                    this.ExibirVertice(vert2, txt);
                    gQueue.Enqueue(vert2);
                    vert2 = this.ObterVerticeAdjacenteNaoVisitado(vert1);
                }

            }

            for (int i = 0; (i < this.numVerts); i++) {
                this.vertices[i].FoiVisitado = false;
            }

        }

        public final void ArvoreGeradoraMinima(int primeiro, TextBox txt) {
            txt.Clear();
            Stack<int> gPilha = new Stack<int>();
            //  para guardar a sequ�ncia de v�rtices
            this.vertices[primeiro].FoiVisitado = true;
            gPilha.Push(primeiro);
            int ver;
            int currVertex;
            while ((gPilha.Count > 0)) {
                currVertex = gPilha.Peek();
                ver = this.ObterVerticeAdjacenteNaoVisitado(currVertex);
                if ((ver == -1)) {
                    gPilha.Pop();
                }
                else {
                    this.vertices[ver].FoiVisitado = true;
                    gPilha.Push(ver);
                    this.ExibirVertice(currVertex, txt);
                    txt.Text += "-->";
                    this.ExibirVertice(ver, txt);
                    txt.Text += "  ";
                }

            }

            for (int j = 0; (j
                    <= (this.numVerts - 1)); j++) {
                this.vertices[j].FoiVisitado = false;
            }

        }
}
