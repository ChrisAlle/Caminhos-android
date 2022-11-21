using System;
class Vertice
{
    private bool foiVisitado;
    private string rotulo;
    private bool estaAtivo;

    //Atributo usado para definir se a cidade faz parte da rota entre as cidades buscadas pelo usuário
    private bool ehCaminho;

    public bool FoiVisitado { get => foiVisitado; set => foiVisitado = value; }
    public string Rotulo { get => rotulo; set => rotulo = value; }
    public bool EstaAtivo { get => estaAtivo; set => estaAtivo = value; }
    public bool EhCaminho { get => ehCaminho; set => ehCaminho = value; }

    public Vertice(string label)
    {
        Rotulo = label;
        FoiVisitado = false;
        estaAtivo = true;
        EhCaminho = false;
    }
}

