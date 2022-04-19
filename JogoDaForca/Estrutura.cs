using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class Estrutura
    {
        /// <summary>
        /// Método Construtor da Estrutura
        /// </summary>
        public Estrutura()
        {

        }

        //Variáveis da classe
        /// <summary>
        /// Ordem aleatória das palavras gerada no inicio de cada jogo.
        /// </summary>
        private int[] indicesUsados = new int[1] { 200 };

        /// <summary>
        /// Guarda o indice da ordem aleatória da palavra do vector de string palavras a adivinhar pelo jogador.
        /// </summary>
        private int indiceOrdem = -1;

        /// <summary>
        /// Guarda o nr de palavras acertadas para apresentação de mensagem de Parabéns quando todas palavras tiverem sido adivinhadas.
        /// </summary>
        private int contaPalavras = 0;

        /// <summary>
        /// Guarda o caractere digitado pelo jogador
        /// </summary>
        private char digito = '0';

        /// <summary>
        /// Número de letras na palavra que coincidem com o caractere digitado pelo jogador
        /// </summary>
        private int contaCertos = 0;

        /// <summary>
        /// Número de letras na palavra que NÃO coincidem com o caractere digitado pelo jogador
        /// </summary>
        private int contaErrados = 0;

        /// <summary>
        /// Número de tentativas erradas ao adivinhar a palavra
        /// </summary>
        private int tErradas = 0;

        /// <summary>
        /// Número de tentativas restantes para adivinhar a palavra
        /// </summary>
        private int tRestantes = 7;

        /// <summary>
        /// Pontuação actual/total
        /// </summary>
        private int pTotal;

        /// <summary>
        /// Guarda as palavras que se pretende que o jogador adivinhe
        /// O 1º elemento deste vector nunca aparece.
        /// </summary>
        private string[] palavras = new string[] { " ","Bola", "Primavera", "Carro", "Limousine", "Fiscal" };

        /// <summary>
        /// Guarda o valor true/false que define se a cada parte do boneco está visivel ou não
        /// </summary> bv,
        private bool[] boneco = new bool[7];

        /// <summary>
        /// Mostra a Estrutura e partes do boneco
        /// </summary>
        /// <param name=""></param>
        private void MostrarForca()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < 25; j++)
                {
                    //MOLDURA
                    // linha preta de cima
                    if (i < 2)
                    {
                        Console.Write("");
                    }
                    // chao
                    else if (i == 8 && j > 0 && j < 24)
                    {
                        Console.Write("\u2591");
                    }
                    // meia linha de baixo
                    else if (i == 9)
                    {
                        Console.Write("\u2580");
                    }
                    //meia linha esquerda
                    else if (j == 0)
                    {
                        Console.Write("\u258C");
                    }
                    //meia linha direita
                    else if (j == 24)
                    {
                        Console.Write("\u2590");
                    }

                    //POSTE
                    //poste vertical
                    else if (i > 2 && i < 7 && j == 10)
                    {
                        Console.Write("\u2503");
                    }
                    //base poste vertical
                    else if (i == 7 && j == 10)
                    {
                        Console.Write("\u253B");
                    }
                    //topo poste vertical
                    else if (i == 2 && j == 10)
                    {
                        Console.Write("\u250F");
                    }
                    //poste horizontal
                    else if (i == 2 && j > 10 && j < 16)
                    {
                        Console.Write("\u2501");
                    }
                    //poste horizontal fim
                    else if (i == 2 && j == 16)
                    {
                        Console.Write("\u2513");
                    }

                    //BONECO
                    //corda
                    else if (i == 3 && j == 16 && boneco[0] == true)
                    {
                        Console.Write("|");
                    }
                    //cabeca
                    else if (i == 4 && j == 16 && boneco[1] == true)
                    {
                        Console.Write("O");
                    }
                    //tronco
                    else if (i == 5 && j == 16 && boneco[2] == true)
                    {
                        Console.Write("|");
                    }
                    //braço esquerdo
                    else if (i == 5 && j == 15 && boneco[3] == true)
                    {
                        Console.Write("/");
                    }
                    //braço direito
                    else if (i == 5 && j == 17 && boneco[4] == true)
                    {
                        Console.Write("\\");
                    }
                    //perna esquerda
                    else if (i == 6 && j == 15 && boneco[5] == true)
                    {
                        Console.Write("/");
                    }
                    //perna direita
                    else if (i == 6 && j == 17 && boneco[6] == true)
                    {
                        Console.Write("\\");
                    }

                    //resto
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Escolhe palavra para adivinhar e transforma em vector
        /// </summary>
        /// <param name="palavras"></param>
        private char[] PalavraToVector(string[] palavras)
        {
            indiceOrdem += 1;

            //transforma string palavra para vector
            char[] vectorPalavra = palavras[indicesUsados[indiceOrdem]].ToCharArray();
            //transforma todos caracteres do vector em minusculas
            for (int i = 0; i < vectorPalavra.Length; i++)
            {
                vectorPalavra[i] = Char.ToLower(vectorPalavra[i]);
            }
            return vectorPalavra;
        }

        /// <summary>
        /// Gera um vector de int com a ordem aleatória com que as palavras aparecem para a adivinhar
        /// </summary>
        /// <param name="palavras"></param>
        private void RandomPalavra(string[] palavras)
        {
            int indiceActual = 1000;
            Random rnd = new Random();
            int[] indicesPalavras = new int[palavras.Length];

            for (int i = 1; i < palavras.Length - 1; i++)
            {
                indicesPalavras[i] = i;
            }

            for (int j = 0; j < indicesPalavras.Length - 1; j++)
            {
                int contaIguais = 0;
                do
                {
                    indiceActual = rnd.Next(indicesPalavras.Length);
                    contaIguais = 0;
                    for (int i = 0; i < indicesUsados.Length; i++)
                    {
                        if (indiceActual == indicesUsados[i] || indiceActual == 0)
                        {
                            contaIguais += 1;
                        }
                    }
                }
                while (contaIguais > 0);

                indicesUsados[j] = indiceActual;
                Array.Resize(ref indicesUsados, indicesUsados.Length + 1);
            }
        }

        /// <summary>
        /// Passa para a próxima palavra com mais 7 tentativas
        /// </summary>
        private void ProximaPalavra()
        {
            Console.Clear();
            contaCertos = 0;
            contaErrados = 0;
            tErradas = 0;
            tRestantes = 7;

            for (int i = 0; i < 7; i++)
            {
                boneco[i] = false;
            }

            MostrarForca();

            //Transforma palavra em vector

            char[] a = PalavraToVector(palavras);

            //Copia comprimento de vectorPalavra. 
            char[] b = CopiaVectorUnderscore(a);

            Tentativas(a, b);
        }

        /// <summary>
        /// Copia o vector da palavra para nova variável com as letras substituidas por Underscore '_'
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private char[] CopiaVectorUnderscore(char[] a)
        {
            char[] b = new char[a.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = '_';
            }
            return b;
        }

        /// <summary>
        /// Pede a letra e verifica se corresponde a algum caractere nas posições do vector da palavra aleatória
        /// </summary>
        /// <param name="utilizador"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void TentarDigito(char[] a, char[] b)
        {
            contaCertos = 0;
            contaErrados = 0;
            Console.Write("\tEscreva uma letra: ");
            Digito();

            if (digito == ' ')
            {
                //Construtor objecto menu
                Menu menu = new Menu();
                menu.ConfirmacaoDesistencia();
            }
            else if (digito == '_')
            {
                Console.WriteLine("\tCaractére vazio - inválido.");
                Console.Write("\tEscolha uma letra por favor: ");
                Console.WriteLine("\n");
                Digito();
            }
            else
            {
                //Valida se a letra inserida pelo jogador é igual a alguma já acertada
                for (int i = 0; i < a.Length; i++)
                {
                    while (digito == b[i] || Char.ToUpper(digito) == b[i])
                    {
                        Console.WriteLine("\tJá acertou nessa letra!");
                        Console.Write("\tEscolha outra letra por favor: ");
                        Digito();
                    }
                }

                //varre o vector e atribui a letra que o utilizador digitou ao vector b, quando coincide com alguma posição do vector
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == digito)
                    {
                        b[i] = a[i];
                        contaCertos += 1;
                    }

                    if (a[0] == b[0])
                    {
                        a[0] = Char.ToUpper(a[0]);
                        b[0] = Char.ToUpper(b[0]);
                    }
                }

                //soma 1 ponto se HOUVER coincidência de letras
                if (contaCertos > 0)
                {
                    pTotal += 1;
                }

                //se NÃO houver coincidência em nenhuma das posições, soma 1 a contaErrados
                for (int i = 0; i < a.Length; i++)
                {
                    a[0] = Char.ToLower(a[0]);
                    if (a[i] != digito)
                    {
                        contaErrados += 1;
                    }
                }
                //se o nr de posições que NAO coincidem com a letra é igual ao nr de posições total da palavra, significa que foi uma tentativa errada.
                //atribui valor true à posição do vector boneco que representa as tentativas erradas 
                if (contaErrados == a.Length)
                {
                    tRestantes -= 1;
                    tErradas += 1;
                    boneco[tErradas - 1] = true;
                }
            }
        }

        /// <summary>
        /// Verifica se o jogador acertou na palavra inteira
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true/false</returns>
        //Como todas as letras já foram verificadas, o método apenas verifica se existe ainda algum Underscore para validar a palavra inteira
        private bool VerificarPalavra(char[] a, char[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Dá 7 oportunidades ao jogador de falhar letras da palavra
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Tentativas(char[] a, char[] b)
        {
            while (tErradas < 7)
            {
                Console.Write("\t");
                for (int i = 0; i < b.Length; i++)
                {
                    Console.Write("{0} ", b[i]);
                }
                Console.WriteLine($"\n\n\tPontuação Actual: {pTotal}");
                Console.WriteLine($"\n\tTentativas restantes: {tRestantes}");
                Console.WriteLine("\tPara sair digite espaço seguido de <ENTER>");
                Console.WriteLine("");
                TentarDigito(a, b);

                Console.Clear();
                MostrarForca();

                if (VerificarPalavra(a, b) == true)
                {
                    pTotal = pTotal + 10;
                    contaPalavras += 1;
                    AcertaPalavra(b);
                    break;
                }
                else if (tErradas == 7)
                {
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Ecrã de Confirmação de palavra acertada
        /// </summary>
        /// <param name="b"></param>
        private void AcertaPalavra(char[] b)
        {
            Console.Write("\t");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0} ", b[i]);
            }

            if (contaPalavras == palavras.Length - 1)
            {
                Parabens();
            }
            else if (contaPalavras <= palavras.Length - 2)
            {
                Console.WriteLine("\n\n\tACERTOU NA PALAVRA!!!");
                Console.WriteLine($"\tPontuação Actual: {pTotal}");
                Console.WriteLine("\n\tContinuar a jogar?");
                Console.WriteLine("\tSIM, próxima palavra <QUALQUER TECLA>");
                Console.WriteLine("\tNÃO, terminar e voltar para menu principal <ESC>");

                var tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.Escape)
                {
                    //Construtor objecto menu
                    Menu menu = new Menu();
                    menu.MenuPrincipal();
                }
                else
                {
                    ProximaPalavra();
                }
            }
        }

        /// <summary>
        /// Apresenta a mensagem de Parabéns quando o jogador completa todas as palavrasdo jogo
        /// </summary>
        private void Parabens()
        {
            Console.WriteLine("\n\n\tPARABÉNS!!!");
            Console.WriteLine("\n\tAcertou nas 5 palavras!");
            Console.WriteLine($"\tPontuação Final: {pTotal}");

            Console.WriteLine("\n\n\n\tVoltar ao Menu Principal <QUALQUER TECLA>");
            Console.WriteLine("\tTerminar aplicação <ESC>");
            var tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else
            {
                Menu menu = new Menu();
                menu.MenuPrincipal();
            }
        }

        /// <summary>
        /// Ecrã de Confirmação de Jogo Perdido
        /// </summary>
        private void GameOver()
        {
            Console.Clear();
            //Construtor objecto menu
            Menu menu = new Menu();
            MostrarForca();
            Console.WriteLine("\n\t\tGAME OVER");
            Console.WriteLine($"\n\t     Pontuação Total:\n\t        {pTotal} pontos");
            menu.VoltarJogar();
        }

        /// <summary>
        /// Inicia um novo jogo
        /// </summary>
        public void NovoJogo()
        {
            Console.Clear();
            RandomPalavra(palavras);
            MostrarForca();

            //Transforma palavra  em vector
            char[] a = PalavraToVector(palavras);

            //Copia comprimento de vectorPalavra
            char[] b = CopiaVectorUnderscore(a);

            Tentativas(a, b);
        }

        /// <summary>
        /// Recebe o Digito do jogador para a variavel
        /// </summary>
        private void Digito()
        {
            try
            {
                digito = Convert.ToChar(Console.ReadLine().ToLower());
            }
            catch (System.FormatException)
            {
                Console.Write("\n\tDigitou 0 ou mais de 1 caractere...\n\tPerdeu uma tentativa.\n\tPrima qualquer tecla para continuar.");
                digito = '0';
                Console.WriteLine("\n");
                Console.ReadKey();
            }
        }

    }
}
