package com.example.apcaminhosmarte;

public class PilhaVetor extends IStack<Dado>{
    Dado[] p;

    int topo;

    public PilhaVetor(int maximo) {
        this.p = new Dado[maximo];
        this.topo = -1;
        //  pois acabamos de criar a pilha, VAZIA
    }

    public PilhaVetor() {
        this(500);


    }

    public int Tamanho;

    public boolean EstaVazia;

    public final void Empilhar(Dado dado) {
        if ((this.Tamanho == this.p.Length)) {
            throw new Exception("`Pilha cheia (Stack Overflow)!");
        }

        this.topo = (this.topo + 1);
        //  ou apenas
        this.p[this.topo] = dado;
        //  p[++topo] = dado;
    }

    public final Dado Desempilhar() {
        if (this.EstaVazia) {
            throw new Exception("Pilha vazia (Stack Underflow)!");
        }

        Dado dadoEmpilhado = this.p[this.topo];
        //  ou
        this.topo = (this.topo - 1);
        //  Dado dadoEmpilhado = p[topo--];
        return dadoEmpilhado;
    }

    public final Dado OTopo() {
        if (this.EstaVazia) {
            throw new Exception("Pilha vazia (Stack Underflow)!");
        }

        Dado dadoEmpilhado = this.p[this.topo];
        //  copia o conte�do da posi��o topo
        //  e n�o altera o valor do �ndice topo
        //  ou seja, mant�m o estado da pilha,
        //  apenas consultou o dado empilhado
        //  no topo da pilha
        return dadoEmpilhado;
    }

    public final List<Dado> DadosDaPilha() {
        List<Dado> lista = new List<Dado>();
        for (int indice = 0; (indice <= this.topo); indice++) {
            lista.Add(this.p[indice]);
        }

        return lista;
    }
}
