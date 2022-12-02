package com.example.apcaminhosmarte;

public class Vertice {
    private boolean foiVisitado;
    private String rotulo;
    private boolean estaAtivo;
    private boolean ehCaminho;


    public Vertice(boolean foiVisitado, String rotulo, boolean estaAtivo, boolean ehCaminho)
    {
        setFoiVisitado(foiVisitado);
        setRotulo(rotulo);
        setEstaAtivo(estaAtivo);
        setEhCaminho(ehCaminho);
    }

    public boolean FoiVisitado() {
        return foiVisitado;
    }

    public void setFoiVisitado(boolean foiVisitado) {
        this.foiVisitado = foiVisitado;
    }

    public String getRotulo() {
        return rotulo;
    }

    public void setRotulo(String rotulo) {
        this.rotulo = rotulo;
    }

    public boolean EstaAtivo() {
        return estaAtivo;
    }

    public void setEstaAtivo(boolean estaAtivo) {
        this.estaAtivo = estaAtivo;
    }

    public boolean EhCaminho() {
        return ehCaminho;
    }

    public void setEhCaminho(boolean ehCaminho) {
        this.ehCaminho = ehCaminho;
    }
}
