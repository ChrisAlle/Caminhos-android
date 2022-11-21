//Christovam Alves Lemos    18192
//Gustavo Mendes Oliveira   20136

using System;
using System.Collections.Generic;
using System.Text;


class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>
{
    //Variável que vai armazenar a posição do nó no vetor de cidades lido do arquivo-texto
    int posicaoNoVetor;

    private Dado info;
    private NoArvore<Dado> esq;
    private NoArvore<Dado> dir;
    private int altura;
    private bool estaMarcadoParaMorrer;
    public Dado Info { get => info; set => info = value; }
    internal NoArvore<Dado> Esq { get => esq; set => esq = value; }
    internal NoArvore<Dado> Dir { get => dir; set => dir = value; }
    public int Altura { get => altura; set => altura = value; }
    public int PosicaoNoVetor { get => posicaoNoVetor; set => posicaoNoVetor = value; }
    public bool EstaMarcadoParaMorrer
    { get => estaMarcadoParaMorrer; set => estaMarcadoParaMorrer = value; }
    public NoArvore(Dado dados)
    {
        this.Info = dados;
        this.Esq = null;
        this.Dir = null;
        this.Altura = 0;
        posicaoNoVetor = -1;
    }
    public NoArvore(Dado dados, NoArvore<Dado> esquerdo, NoArvore<Dado> direito,
    int altura)
    {
        this.Info = dados;
        this.Esq = esquerdo;
        this.Dir = direito;
        this.Altura = altura;
        posicaoNoVetor = -1;
    }

    public int CompareTo(NoArvore<Dado> o)
    {
        return Info.CompareTo(o.Info);
    }
    public bool Equals(NoArvore<Dado> o)
    {
        return this.Info.Equals(o.Info);
    }
}




    

