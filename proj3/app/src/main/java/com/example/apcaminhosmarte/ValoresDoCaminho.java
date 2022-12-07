package com.example.apcaminhosmarte;

public class ValoresDoCaminho {
    private int origem;
    private int destino;
    private int distancia;
    private int tempo;
    private int custo;

    public ValoresDoCaminho(int orig, int dest, int dist, int t, int c)
    {
        origem = orig;
        destino = dest;
        distancia = dist;
        tempo = t;
        custo = c;
    }

    public int getOrigem() {
        return origem;
    }

    public int getDestino() {
        return destino;
    }

    public int getDistancia() {
        return distancia;
    }

    public int getTempo() {
        return tempo;
    }

    public int getCusto() {
        return custo;
    }
}
