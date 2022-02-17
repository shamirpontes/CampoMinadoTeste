using System;

namespace Ivory.TesteEstagio.CampoMinado 
{
    public class Program
    {
        private static char _linha = '\r';
        private static char _coluna = '\n';

        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do Jogo\n");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            var numeroLinhas = 9;
            var numeroColunas = 9;

            //matriz para guardar posições das bombas
            int[,] bombas = new int[numeroLinhas, numeroColunas];
            Array.Clear(bombas, 0, bombas.Length);

            while (campoMinado.JogoStatus == 0) {

                //cria uma cópia do tabuleiro atual
                var copyTabuleiro = campoMinado.Tabuleiro;
                var aux = 0;
                char[] auxTabuleiro = copyTabuleiro.ToCharArray();
                char[] tabuleiro = new char[numeroLinhas * numeroColunas];
                char[,] estadoAtualTabuleiro = new char[numeroLinhas, numeroColunas];

                foreach (var c in auxTabuleiro) 
                {
                    if (c != _linha && c != _coluna) 
                    {
                        tabuleiro[aux] = c;
                        aux++;
                    }
                }

                aux = 0;

                // Estado atual do tabuleiro
                for (var x = 0; x < numeroLinhas; x++) 
                {
                    for (var y = 0; y < numeroColunas; y++)
                    {
                        estadoAtualTabuleiro[x, y] = tabuleiro[aux];
                        aux++;
                    }
                }

                //Utilizado para descobrir onde estão as bombas
                for (var x = 0; x < numeroLinhas; x++)
                {
                    for (var y = 0; y < numeroColunas; y++) 
                    {
                        if (estadoAtualTabuleiro[x, y] == '-' | estadoAtualTabuleiro[x, y] == '0') 
                        {
                            continue;
                        } 
                        else 
                        {
                            var numeroCasa = (int)Char.GetNumericValue(estadoAtualTabuleiro[x, y]);
                            var casasLivres = 0;

                            //Analisa e Verifica as casas livres ao redor da casa atual
                            if (x - 1 >= 0 && y - 1 >= 0) 
                            {
                                if (estadoAtualTabuleiro[x - 1, y - 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }
                            if (x - 1 >= 0) 
                            {
                                if (estadoAtualTabuleiro[x - 1, y] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (x - 1 >= 0 && y + 1 < numeroColunas) 
                            {
                                if (estadoAtualTabuleiro[x - 1, y + 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (y - 1 >= 0) 
                            {
                                if (estadoAtualTabuleiro[x, y - 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (y + 1 < numeroColunas) 
                            {
                                if (estadoAtualTabuleiro[x, y + 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numeroLinhas && y - 1 >= 0) 
                            {
                                if (estadoAtualTabuleiro[x + 1, y - 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numeroLinhas) 
                            {
                                if (estadoAtualTabuleiro[x + 1, y] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numeroLinhas && y + 1 < numeroColunas) 
                            {
                                if (estadoAtualTabuleiro[x + 1, y + 1] == '-') 
                                {
                                    casasLivres++;
                                }
                            }

                            //Preenche a matriz com a posição das bombas
                            if (numeroCasa == casasLivres) 
                            {
                                if (x - 1 >= 0 && y - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x - 1, y - 1] == '-') 
                                    {
                                        bombas[x - 1, y - 1] = 1;
                                    }
                                }

                                if (x - 1 >= 0)
                                {
                                    if (estadoAtualTabuleiro[x - 1, y] == '-') 
                                    {
                                        bombas[x - 1, y] = 1;
                                    }
                                }

                                if (x - 1 >= 0 && y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x - 1, y + 1] == '-') 
                                    {
                                        bombas[x - 1, y + 1] = 1;
                                    }
                                }

                                if (y - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x, y - 1] == '-') 
                                    {
                                        bombas[x, y - 1] = 1;
                                    }
                                }

                                if (y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x, y + 1] == '-') 
                                    {
                                        bombas[x, y + 1] = 1;
                                    }
                                }

                                if (x + 1 < numeroColunas && y - 1 >= 0)
                                {
                                    if (estadoAtualTabuleiro[x + 1, y - 1] == '-') 
                                    {
                                        bombas[x + 1, y - 1] = 1;
                                    }
                                }

                                if (x + 1 < numeroLinhas) 
                                {
                                    if (estadoAtualTabuleiro[x + 1, y] == '-') 
                                    {
                                        bombas[x + 1, y] = 1;
                                    }
                                }

                                if (x + 1 < numeroLinhas && y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x + 1, y + 1] == '-') 
                                    {
                                        bombas[x + 1, y + 1] = 1;
                                    }

                                }
                            }
                        }
                    }
                }

                //Abre possíveis posições que nao contém bombas
                for (var x = 0; x < numeroLinhas; x++) 
                {
                    for (var y = 0; y < numeroColunas; y++) 
                    {
                        if (estadoAtualTabuleiro[x, y] == '-' | estadoAtualTabuleiro[x, y] == '0') 
                        {
                            continue;
                        } 
                        else 
                        {
                            var numeroCasa = (int)Char.GetNumericValue(estadoAtualTabuleiro[x, y]);
                            var numeroMinas = 0;

                            //conta quantas minas tem em volta da casa selecionada
                            if (x - 1 >= 0 && y - 1 >= 0) 
                            {
                                if (bombas[x - 1, y - 1] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (x - 1 >= 0) 
                            {
                                if (bombas[x - 1, y] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (x - 1 >= 0 && y + 1 < numeroColunas) 
                            {
                                if (bombas[x - 1, y + 1] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (y - 1 >= 0) 
                            {
                                if (bombas[x, y - 1] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (y + 1 < numeroColunas) 
                            {
                                if (bombas[x, y + 1] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (x + 1 < numeroLinhas && y - 1 >= 0) 
                            {
                                if (bombas[x + 1, y - 1] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (x + 1 < numeroLinhas) 
                            {
                                if (bombas[x + 1, y] == 1) 
                                {
                                    numeroMinas++;
                                }
                            }

                            if (x + 1 < numeroLinhas && y + 1 < numeroColunas) 
                            {
                                if (bombas[x + 1, y + 1] == 1) 
                                {
                                    numeroMinas++;
                                }

                            }

                            //Abre as casas que nao tem bombas em volta
                            if (numeroMinas == numeroCasa) 
                            {
                                if (x - 1 >= 0 && y - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x - 1, y - 1] == '-' && bombas[x - 1, y - 1] != 1) 
                                    {
                                        campoMinado.Abrir(x, y);
                                    }
                                }

                                if (x - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x - 1, y] == '-' && bombas[x - 1, y] != 1) 
                                    {
                                        campoMinado.Abrir(x, y + 1);
                                    }
                                }

                                if (x - 1 >= 0 && y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x - 1, y + 1] == '-' && bombas[x - 1, y + 1] != 1) 
                                    {
                                        campoMinado.Abrir(x, y + 2);
                                    }
                                }

                                if (y - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x, y - 1] == '-' && bombas[x, y - 1] != 1) 
                                    {
                                        campoMinado.Abrir(x + 1, y);
                                    }
                                }

                                if (y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x, y + 1] == '-' && bombas[x, y + 1] != 1) 
                                    {
                                        campoMinado.Abrir(x + 1, y + 2);
                                    }
                                }

                                if (x + 1 < numeroLinhas && y - 1 >= 0) 
                                {
                                    if (estadoAtualTabuleiro[x + 1, y - 1] == '-' && bombas[x + 1, y - 1] != 1) 
                                    {
                                        campoMinado.Abrir(x + 2, y);
                                    }
                                }

                                if (x + 1 < numeroLinhas) 
                                {
                                    if (estadoAtualTabuleiro[x + 1, y] == '-' && bombas[x + 1, y] != 1) 
                                    {
                                        campoMinado.Abrir(x + 2, y + 1);
                                    }
                                }

                                if (x + 1 < numeroLinhas && y + 1 < numeroColunas) 
                                {
                                    if (estadoAtualTabuleiro[x + 1, y + 1] == '-' && bombas[x + 1, y + 1] != 1) 
                                    {
                                        campoMinado.Abrir(x + 2, y + 2);
                                    }

                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\n\r\n\r");
                Console.WriteLine(campoMinado.Tabuleiro);

                if (campoMinado.JogoStatus == 1) 
                {
                    Console.WriteLine("\n\r\n\r");
                    Console.WriteLine("VITÓRIA");
                } 
                else if (campoMinado.JogoStatus == 2)
                {
                    Console.WriteLine("\n\r\n\r");
                    Console.WriteLine("GAME OVER");
                }
            }
        }
    }
}