package com.example.apcaminhosmarte;

public class Movimento {
    private int origem;
    private int destino;
    private ValoresDoCaminho valores;

     public Movimento(int orig,int dest, ValoresDoCaminho val)
     {
         setOrigem(orig);
         setDestino(dest);
         setValores(val);
     }

    public int getOrigem() {
        return origem;
    }

    public void setOrigem(int origem) {
        this.origem = origem;
    }

    public int getDestino() {
        return destino;
    }

    public void setDestino(int destino) {
        this.destino = destino;
    }

    public ValoresDoCaminho getValores() {
        return valores;
    }

    public void setValores(ValoresDoCaminho valores) {
        this.valores = valores;
    }
}
