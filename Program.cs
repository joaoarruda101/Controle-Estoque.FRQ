using System;
using System.Collections.Generic;

namespace Trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz matriz = new Matriz();
            //Inicializa estoque
            //Mostra todos os estoques
            for (int i = 1; i < 5; i++)
            {

                if (i == 1)
                {
                    MostraEstoque(i, matriz.mtz1);
                }
                if (i == 2)
                {
                    MostraEstoque(i, matriz.mtz2);
                }
                if (i == 3)
                {
                    MostraEstoque(i, matriz.mtz3);
                }
                if (i == 4)
                {
                    MostraEstoque(i, matriz.mtz4);
                }

                Console.WriteLine("");
            }


            for (int dias = 0; dias < 5; dias++)
            {
                //RecebeCarga(QtdDeCargas);
                int QtdDeCargas = Geradores.Qtd();
                Console.WriteLine(" <----> QUANTIDADE DE CARGAS:" + QtdDeCargas);
                Console.WriteLine("");
                
                //Criar lista para a entrada do IDS
                List<string> listaEnt = Geradores.GeraEntrada();
                
                for (int i = 0; i < QtdDeCargas; i++)
                {
                    Console.WriteLine("ID:" + i + " LISTA");

                    string resultadoSv = "";
                    string resultaodoLista = "";

                    foreach (var item in listaEnt)
                    {
                        resultaodoLista = resultaodoLista + item;
                    }
                    Console.WriteLine("CARGAS : " + resultaodoLista);
                    //Cria um array de string para ser percorrido e usar os items no foreach
                    //Resumindo, Aqui eu chamo a função da classe Geradores OrdemDeServiço

                    foreach (var item in listaEnt)
                    {
                        //transformei para inteiro para poder inserir na matriz correspondente
                        int IdItem = Convert.ToInt32(item);

                        if (IdItem == 1)
                        {
                            PreencherMatriz(IdItem, matriz.mtz1);

                        }
                        if (IdItem == 2)
                        {
                            PreencherMatriz(IdItem, matriz.mtz2);

                        }
                        if (IdItem == 3)
                        {
                            PreencherMatriz(IdItem, matriz.mtz3);

                        }
                        if (IdItem == 4)
                        {
                            PreencherMatriz(IdItem, matriz.mtz4);
                        }
                    }

                    //Aqui eu separo os caracteres da string para adicionar list<string>
                    List<string> OrdemDeSv = new List<string>();
                    string vetorOrdSv = Geradores.OrdemDeServico();
                    foreach (var item in vetorOrdSv)
                    {
                        char ordSv = Convert.ToChar(item);
                        if (ordSv == '1')
                        {
                            string ordem1 = "1";
                            OrdemDeSv.Add(ordem1);
                        }
                        if (ordSv == '2')
                        {
                            string ordem2 = "2";
                            OrdemDeSv.Add(ordem2);
                        }
                        if (ordSv == '3')
                        {
                            string ordem3 = "3";
                            OrdemDeSv.Add(ordem3);
                        }
                        if (ordSv == '4')
                        {
                            string ordem4 = "4";
                            OrdemDeSv.Add(ordem4);
                        }
                    }
                    foreach (var item in OrdemDeSv)
                    {
                        resultadoSv = resultadoSv + item;
                    }
                    Console.WriteLine("ORDEM DE SERVIÇO : " + resultadoSv);

                    foreach (var item in OrdemDeSv)
                    {
                        //transformei para inteiro para poder inserir na matriz correspondente
                        int IdItem = Convert.ToInt32(item);

                        if (IdItem == 1)
                        {
                            RemoverMatriz(IdItem, matriz.mtz1);

                        }
                        if (IdItem == 2)
                        {
                            RemoverMatriz(IdItem, matriz.mtz2);

                        }
                        if (IdItem == 3)
                        {
                            RemoverMatriz(IdItem, matriz.mtz3);

                        }
                        if (IdItem == 4)
                        {
                            RemoverMatriz(IdItem, matriz.mtz4);
                        }
                    }

                }



                Console.WriteLine();

                //mostra Estoque FINAL
                Console.WriteLine("=====ATUALIZAÇÃO ESTOQUE LOCAL======");
                for (int i = 1; i < 5; i++)
                {

                    if (i == 1)
                    {
                        MostraEstoqueFinal(matriz.mtz1);
                    }
                    if (i == 2)
                    {
                        MostraEstoqueFinal(matriz.mtz2);
                    }
                    if (i == 3)
                    {
                        MostraEstoqueFinal(matriz.mtz3);
                    }
                    if (i == 4)
                    {
                        MostraEstoqueFinal(matriz.mtz4);
                    }
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
            Console.WriteLine("--- | FIM DA LOGICA DE ESTOQUE | ---");
        }

        private static void MostraEstoque(int IdEstoque, int[][] mtz)
        {
            int rowMatriz = 6;
            int colMatriz = 6;
            //Valor totall da matriz (Tamanho)
            int totalMatriz = rowMatriz * colMatriz;
            //Pega a metade da Matriz para preencher
            int metadeMatriz = MetadeMatriz(totalMatriz);
            int cont = 0;
            for (int i = 0; i < mtz.Length; i++)
            {
                mtz[i] = new int[6];
            }
            for (int i = 0; i < mtz.Length; i++)
            {
                for (int j = 0; j < mtz[i].Length; j++)
                {
                    cont = cont + 1;

                    if (cont <= metadeMatriz)
                    {
                        mtz[i][j] = IdEstoque;
                    }
                    else
                    {
                        mtz[i][j] = 0;
                    }
                    Console.Write(mtz[i][j] + " ");
                }
                Console.WriteLine();
            }

        }

        private static int MetadeMatriz(int tamanhoMatriz)
        {
            //Formula para usar com o cont e dividir a matriz
            int resultado = 0;
            resultado = tamanhoMatriz / 2;
            return resultado;
        }

        private static void PreencherMatriz(int IdItem, int[][] mtz)
        {
            int cont = 0;
            for (int i = 0; i < mtz.Length; i++)
            {
                for (int j = 0; j < mtz[i].Length; j++)
                {
                    if (mtz[i][j] == 0 && cont == 0)
                    {
                        mtz[i][j] = IdItem;
                        cont = 1;
                    }
                }
            }
        }

        private static void RemoverMatriz(int IdItem, int[][] mtz)
        {
            int cont = 0;
            for (int i = mtz.Length - 1; i >= 0; i--)
            {
                for (int j = mtz.Length - 1; j >= 0; j--)
                {
                    if (mtz[i][j] == IdItem && cont == 0)
                    {
                        mtz[i][j] = 0;
                        cont = 1;
                    }
                }
            }  
                       
        }

        private static void MostraEstoqueFinal(int[][] mtz)
        {
            for (int i = 0; i < mtz.Length; i++)
            {
                for (int j = 0; j < mtz[i].Length; j++)
                {
                    Console.Write(mtz[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}


