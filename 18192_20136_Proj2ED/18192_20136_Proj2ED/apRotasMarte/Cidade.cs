//Christovam Alves Lemos    18192
//Gustavo Mendes Oliveira   20136

using System;
using System.IO;
using System.Windows.Forms;

class Cidade : IComparable<Cidade>, IRegistro
{
    //Quantidade de caracteres do nome
    public const int tamanhoNome = 15;

    //Atributos de uma cidade
    private string nome;
    private double coordenadaX;
    private double coordenadaY;

    //Para pegar cada atributo
    public string Nome { get => nome.PadRight(tamanhoNome, ' '); set => nome = value; }
    public double CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
    public double CoordenadaY { get => coordenadaY; set => coordenadaY = value; }

    //Construtor vazio
    public Cidade()
    {
        Nome = "";
        coordenadaX = 0;
        coordenadaY = 0;
    }

    //Construtor com todos os atributos
    public Cidade(string nome, double x, double y)
    {
        this.Nome = nome;
        this.coordenadaX = x;
        this.coordenadaY = y;
    }

    //Construtor com o nome
    public Cidade(string nome)
    {
        this.nome = nome;
        coordenadaX = 0;
        coordenadaY = 0;
    }

    public int CompareTo(Cidade outraCidade)
    {
        //Retorna a comparação entre os nomes
        return nome.CompareTo(outraCidade.nome);
    }

    public override string ToString()
    {
        //Retorna a formatação dos atributos
        return nome + " X: " + coordenadaX + " Y: " + coordenadaY;
    }

    //Tamanho de cada cidade no arquivo-texto
    public int TamanhoRegistro { get => tamanhoNome + 7 + 7; }

    //Método para ler um registro de arquivo
    public void LerRegistro(StreamReader arquivo, long qualRegistro)
    {
        //Se arquivo não for nulo
       if (arquivo != null)
            try
            {
                //Lê uma linha
                string linha = arquivo.ReadLine();
                //Define nome como sendo os primeiros quinze caracteres, removendo os espaços
                this.nome = linha.Substring(0, tamanhoNome).TrimEnd(' ');
                //Define coordenadaX como os próximos seis caracteres
                this.coordenadaX = double.Parse(linha.Substring(tamanhoNome, 6));
                //Define coordenadaY como os últimos 6 caracteres
                this.coordenadaY = double.Parse(linha.Substring(tamanhoNome+6, 6));
            }
            //Caso ocorra um erro
            catch (Exception e)
            {
                //Alerta o usuário
                MessageBox.Show(e.Message);
            }
    }

    //Método para salvar um registro no arquivo-texto arquivo
    public void GravarRegistro(StreamWriter arquivo)
    {
       if (arquivo != null)
       {
            //Cria linha, passando o nome (com quinze caracteres), a coordenadaX (adicionando espaços à esquerda) e a coordenadaY (adicionando espaços à esquerda)
            string linha = Nome + coordenadaX.ToString().PadLeft(6) + coordenadaY.ToString().PadLeft(6);
            //Escreve a linha
            arquivo.WriteLine(linha);
       }
    }
}