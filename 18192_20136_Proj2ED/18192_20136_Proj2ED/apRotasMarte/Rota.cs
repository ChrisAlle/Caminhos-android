using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apRotasMarte
{
    //Classe que vai armazenar as informações de cada rota
    class Rota
    {
        public int distancia, preco;

        //Ao instanciar, define os valores de seus atributos como o valor de infinity da classe grafo
        public Rota()
        {
            this.distancia = 1000000;
            this.preco = 1000000;
        }
    }
}
