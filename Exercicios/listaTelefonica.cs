using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class ListaTelefonica
    {
        public static void Main9()
        {
          
            Console.WriteLine("Digite a quantidade de Testes");
            
            int contarNumerosDaPrimeiraPosicao = 0;
            int linhaDaMatriz=0;
            int receberAquantidadeDeTestes = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Digite a quantidade de numeros que seu numero vai ter");
            int quantidadeDeNumero = Convert.ToInt32(Console.ReadLine());
            int[,] matrizDeNumeros = new int[receberAquantidadeDeTestes, quantidadeDeNumero];
            for (int i = 0; i < receberAquantidadeDeTestes; i++)
            {                                
                contarNumerosDaPrimeiraPosicao++;
                int a;
                Console.Clear();
                Console.WriteLine($"Digite o º{contarNumerosDaPrimeiraPosicao} numero");
                for (a = 0, linhaDaMatriz = linhaDaMatriz; a < quantidadeDeNumero; a++)
                {
                    matrizDeNumeros[linhaDaMatriz, a] = Convert.ToInt32(Console.ReadLine());
                }
                linhaDaMatriz++;               
            }
            Console.Clear();
            foreach (var item in matrizDeNumeros)
            {
                Console.WriteLine(item);
            }
            ReceberAlistaTelefonica(matrizDeNumeros, quantidadeDeNumero, receberAquantidadeDeTestes);
        }
        public static void ReceberAlistaTelefonica(int[,] receberListaTelefonica,int receberAquantidadeDeNumeros,int receberAquantidadeDeTestes)
        {
            int linhaDaMatrix = 0;
            int verificar = 0;
            var compararAprimeiraLinhaDoArray = new int[receberAquantidadeDeTestes, receberAquantidadeDeNumeros];
            
            for (int i = 0; i < receberAquantidadeDeNumeros; i++)
            {
                compararAprimeiraLinhaDoArray[linhaDaMatrix, i] = receberListaTelefonica[linhaDaMatrix, i];
            }
            linhaDaMatrix = 1;
            for (int colunaDaMatriz = 0; colunaDaMatriz < receberListaTelefonica.Length; colunaDaMatriz++)
            {
                
                if (verificar == 1)
                {
                    verificar = 0;
                    colunaDaMatriz = 0;
                    for (int i = 0; i < receberAquantidadeDeNumeros; i++,colunaDaMatriz++)
                    {
                        if (compararAprimeiraLinhaDoArray[0, colunaDaMatriz] != receberListaTelefonica[linhaDaMatrix, colunaDaMatriz])
                        {
                            int receberColunaDaMatriz = colunaDaMatriz;
                            for (int a = receberAquantidadeDeNumeros; a > colunaDaMatriz; a--, receberColunaDaMatriz++)
                            {
                                compararAprimeiraLinhaDoArray[linhaDaMatrix, receberColunaDaMatriz] = receberListaTelefonica[linhaDaMatrix, receberColunaDaMatriz];
                            }
                            linhaDaMatrix++;
                            verificar++;
                            if (linhaDaMatrix == receberAquantidadeDeTestes)
                            {
                                ExibirOsNumerosTelefonicos(receberListaTelefonica, receberAquantidadeDeTestes, receberAquantidadeDeNumeros);
                            }
                        }
                        else
                        {
                            compararAprimeiraLinhaDoArray[linhaDaMatrix, colunaDaMatriz] = 0;
                        }
                    }                    
                }
                else if (compararAprimeiraLinhaDoArray[0, colunaDaMatriz] != receberListaTelefonica[linhaDaMatrix, colunaDaMatriz])
                {
                    verificar++;
                    int receberColunaDaMatriz = colunaDaMatriz;
                    for (int i = receberAquantidadeDeNumeros; i > colunaDaMatriz; i--, receberColunaDaMatriz++)
                    {
                        compararAprimeiraLinhaDoArray[linhaDaMatrix, receberColunaDaMatriz] = receberListaTelefonica[linhaDaMatrix, receberColunaDaMatriz];
                    }
                    linhaDaMatrix++;
                    if (linhaDaMatrix == receberAquantidadeDeTestes)
                    {
                        ExibirOsNumerosTelefonicos(receberListaTelefonica, receberAquantidadeDeTestes, receberAquantidadeDeNumeros);
                    }
                }
                else
                {
                    compararAprimeiraLinhaDoArray[linhaDaMatrix, colunaDaMatriz] = 0;
                }                                
            }            
        }
        public static void ExibirOsNumerosTelefonicos(int[,] listaTelefonica, int quantidadesDeTestes,int quantidadeDeNumeros)
        {
            int receberAquantidadeDeTestes = 0;
            var compararAprimeiraLinhaDoArray = new int[quantidadesDeTestes, quantidadeDeNumeros];
            Console.Clear();
            for (int i = 0; i < quantidadeDeNumeros; i++)
            {
                Console.Write(" ");
                Console.Write(compararAprimeiraLinhaDoArray[0, i] = listaTelefonica[0, i]);
            }
            Console.WriteLine();
            quantidadesDeTestes = 1;
            for (int i = 0; i < listaTelefonica.Length; i++)
            {
                for (int a = 0; a < quantidadeDeNumeros; a++)
                {
                    if (compararAprimeiraLinhaDoArray[0, a] != listaTelefonica[quantidadesDeTestes, a])
                    {
                        for (int s = a; s < quantidadeDeNumeros; s++)
                        {
                            Console.Write(" " + listaTelefonica[quantidadesDeTestes, s]);
                        }    
                        break;
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
                quantidadesDeTestes++;
                if (receberAquantidadeDeTestes == quantidadesDeTestes)
                {
                    Console.WriteLine();
                    Console.WriteLine("Fim do programa!");
                }    
            }
        }
    }
}
