package com.example.apcaminhosmarte;

public class Cidade {

    private String nome;
    private double coordenadaX;
    private double coordenadaY;

    public void setNome(String n)
    {
        this.nome = n;
    }

    public void setX(double x)
    {
        this.coordenadaX = x;
    }

    public void setY(double y)
    {
        this.coordenadaY = y;
    }



    public  Cidade()
    {
        nome = "";
        coordenadaX = 0;
        coordenadaY = 0;
    }

    public Cidade(String nome, double x, double y)
    {
        setNome(nome);
        setX(x);
        setY(y);
    }
}
