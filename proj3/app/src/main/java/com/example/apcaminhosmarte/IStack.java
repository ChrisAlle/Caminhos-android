package com.example.apcaminhosmarte;

public interface IStack<Dado>  {

    void Empilhar(Dado dado);

    //  empilha o objeto "dado"
    Dado Desempilhar();

    //  remove e retorna o objeto do topo
    Dado OTopo();

    //  retorna o objeto do topo sem remov�-lo
    int Tamanho {
        get;
    }

    //  informa a quantidade de itens empilhados
    boolean EstaVazia {
        get;
    }
}