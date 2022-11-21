

using System;
using System.IO;

//Interface ensinada em aula, mas com uso de StreamFile ao invés de BinaryFile
interface IRegistro
{
    void LerRegistro(StreamReader arquivo, long qualRegistro);
    void GravarRegistro(StreamWriter arquivo);
    int TamanhoRegistro { get; }
}