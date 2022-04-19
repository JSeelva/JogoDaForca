using System;

namespace JogoDaForca
{
    class Menu
    {
        /// <summary>
        /// Método Construtor da instancia Menu
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// Construtor Instância objecto forca
        /// </summary>
        Estrutura forca = new Estrutura();



        /// <summary>
        /// Menu Principal (Início da Aplicação)
        /// </summary>
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("\n\n\tBENVINDO AO JOGO DA FORCA!!!");
            Console.WriteLine("\n\tNOVO JOGO <QUALQUER TECLA>");
            Console.WriteLine("\tSAIR <ESC>");

            var tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Escape)
            {
                ConfirmacaoSaida();
            }
            else
            {
                Console.Clear();
                forca.NovoJogo();
            }
        }

        /// <summary>
        /// Questiona o Jogador se quer mesmo Sair do Jogo ou voltar para o Menu Principal
        /// </summary>
        public void ConfirmacaoSaida()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tTem a certeza que pretende sair da aplicação?");
            Console.WriteLine("\n\tSIM, sair da aplicação <ESC>");
            Console.WriteLine("\tNÃO, voltar para menu principal <QUALQUER TECLA>");

            var tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else { 
                MenuPrincipal();
            }

        }

        /// <summary>
        /// Questiona se o jogador quer realmente desistir sabendo que a pontuação será perdida
        /// </summary>
        public void ConfirmacaoDesistencia()
        {
            Console.WriteLine($"\n\n\n\tTem a certeza que pretende desistir do jogo?\n\tSe SIM, perderá a sua pontuação actual.");
            Console.WriteLine("\n\tSIM, ir para o menu principal <ESC>");
            Console.WriteLine("\tNÃO, continuar a jogar <QUALQUER TECLA>");

            var tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Escape)
            {
                MenuPrincipal();
            }
        }

        /// <summary>
        /// Questiona o jogador se quer voltar a jogar depois de perder o jogo
        /// </summary>
        public void VoltarJogar()
        {
            Console.WriteLine("\n\n\tVoltar a jogar?");
            Console.WriteLine("\n\tNOVO JOGO <QUALQUER TECLA>");
            Console.WriteLine("\tSAIR <ESC>");

            var tecla = Console.ReadKey();
            
            if (tecla.Key == ConsoleKey.Escape)
            {
                ConfirmacaoSaida();
            }
            else
            {
                Console.Clear();
                forca.NovoJogo();
            }
        }
    }
}
