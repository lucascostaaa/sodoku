using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sodoku.ConsoleApp
{
    class Program
    //        A matriz do jogo é uma matriz de
    //inteiros 9 x 9 . Para ser uma solução do problema, cada linha e coluna deve
    //conter todos os números de 1 a 9. Além disso, se dividirmos a matriz em 9
    //regiões 3 x 3, cada uma destas regiões também deve conter os números de 1 a 9.
    //O exemplo abaixo mostra uma matriz que é uma solução do problema.


    //Entrada

    //Nas linhas seguintes são dadas as
    //n matrizes.Cada matriz é dada em 9 linhas, em que cada linha contém 9 números
    //inteiros. 




    //1 3 2  | 5 7 9  | 4 6 8
    //4 9 8  | 2 6 1  | 3 7 5
    //7 5 6  | 3 8 4  | 2 1 9
    //- - - + - - - + - - -
    //6 4 3  | 1 5 8  | 7 9 2
    //5 2 1  | 7 9 3 | 8 4 6
    //9 8 7  | 4 2 6 | 5 3 1
    //- - - + - - - + - - -
    //2 1 4  | 9 3 5 | 6 8 7
    //3 6 5  | 8 1 7 | 9 2 4
    //8 7 9  | 6 4 2 | 1 5 3





    //O seu programa deverá imprimir SIM se a matriz for a solução
    //de um problema de Sudoku, e NAO caso contrário. Exemplo:


    //Entrada:

    //1 3 2 5 7 9 4 6 8

    //4 9 8 2 6 1 3 7 5

    //7 5 6 3 8 4 2 1 9

    //6 4 3 1 5 8 7 9 2

    //5 2 1 7 9 3 8 4 6

    //9 8 7 4 2 6 5 3 1

    //2 1 4 9 3 5 6 8 7

    //3 6 5 8 1 7 9 2 4

    //8 7 9 6 4 2 1 5 3




    //Saída:

    //SIM
    {
        static void Main(string[] args)
        {

            string StringSudoku = @"1 3 2 5 7 9 4 6 8
                                   4 9 8 2 6 1 3 7 5 
                                   7 5 6 3 8 4 2 1 9
                                   6 4 3 1 5 8 7 9 2
                                   5 2 1 7 9 3 8 4 6
                                   9 8 7 4 2 6 5 3 1
                                   2 1 4 9 3 5 6 8 7
                                   3 6 5 8 1 7 9 2 4
                                   8 7 9 6 4 2 1 5 3";


            int[,] linhasSudoku = new int[9, 9];
            int[,] colunaSudoku = new int[9, 9];
            int[,] blocoSudoku = new int[9, 9];

            using (StringReader sudoReader = new StringReader(StringSudoku))
            {

                string linhaSudoku = "";

                for (int x = 0; x < 9; x++)
                {
                    linhaSudoku = sudoReader.ReadLine();

                    string[] valores = linhaSudoku.Trim().Split();
                    //LINHA
                    for (int y = 0; y < 9; y++)
                    {
                        linhasSudoku[x, y] = Convert.ToInt32(valores[y]);
                    }
                }

                //COLUNA

                for (int y = 0; y < 9; y++)
                    for (int x = 0; x < 9; x++)
                        colunaSudoku[y, x] = linhasSudoku[x, y];


                //BLOCOS
                int l = 0;
                for (int k = 0; k < 9; k++)
                {
                    l = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int x = i + k % 3 * 3;
                            int y = j + k / 3 * 3;
                            blocoSudoku[k, l] = linhasSudoku[x, y];
                            l++;

                        }
                    }
                }
                Verificar(linhasSudoku);
                Verificar(colunaSudoku);
                Verificar(blocoSudoku);

                Console.WriteLine("SIM");
                Console.ReadLine();

            }
        }

        private static void Verificar(int[,] linhasSudoku)
        {
            for (int k = 0; k < 9; k++)
                for (int i = 0; i < 9; i++)
                    for (int j = i + 1; j < 9; j++)
                        if (linhasSudoku[k, i] == linhasSudoku[k, j])
                        {
                            Console.WriteLine("NAO");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
        }
    }
}

