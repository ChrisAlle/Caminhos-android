package com.example.apcaminhosmarte;

public class CaminhosEntreCidades {
    private String origem;
    private String destino;
    private int distancia;
    private int tempo;
    private int custo;

    public CaminhosEntreCidades(String origem, String destino, int distancia, int tempo, int custo)
    {
        setOrigem(origem);
        setDestino(destino);
        setDistancia(distancia);
        setTempo(tempo);
        setCusto(custo);
    }

    public String getOrigem() {
        return origem;
    }

    public void setOrigem(String origem) {
        this.origem = origem;
    }

    public String getDestino() {
        return destino;
    }

    public void setDestino(String destino) {
        this.destino = destino;
    }

    public int getTempo() {
        return tempo;
    }

    public void setTempo(int tempo) {
        this.tempo = tempo;
    }

    public int getCusto() {
        return custo;
    }

    public void setCusto(int custo) {
        this.custo = custo;
    }

    public int getDistancia() {
        return distancia;
    }

    public void setDistancia(int distancia) {
        this.distancia = distancia;
    }
}
