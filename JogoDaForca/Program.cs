using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encoding
            Console.OutputEncoding = Encoding.UTF8;

            //Construtor Instância objecto menu
            Menu menu = new Menu();


            //Construtor Instância objecto menu
            Estrutura forca = new Estrutura();

            menu.MenuPrincipal();
        }
    }
}
