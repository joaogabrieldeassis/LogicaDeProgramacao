using CaixaEletronico.Models;
using CaixaEletronico;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using teste;

namespace Exercicios
{
    public class TrocaDeTrem
    {
        /*Em uma antiga estação ferroviária, você ainda pode encontrar um dos últimos “trocadores de trem” restantes.Um trocador de trem é um funcionário da ferrovia,
         * cujo único trabalho é reorganizar os vagões dos trens.
        Uma vez que os vagões estejam dispostos na ordem ideal, tudo o que o maquinista precisa fazer é despachá-los, um a um, nas estações para as quais a carga é destinada.
        O título “troca de trem” vem da primeira pessoa que realizou essa tarefa, em uma estação próxima a uma ponte ferroviária.Em vez de se abrir verticalmente
        a ponte girava em torno de um pilar no centro do rio.Depois de girar a ponte 90 graus, os barcos podem passar para a esquerda ou para a direita.
        O primeiro trocador de trem descobriu que a ponte poderia ser operada com no máximo dois vagões.Ao girar a ponte 180 graus, os vagões trocaram de lugar,
        permitindo que ele reorganizasse os vagões(como efeito colateral, os vagões ficaram voltados para a direção oposta, mas os vagões do trem podem se mover para qualquer lado,
        então quem se importa).
        Agora que quase todos os trocadores de trem morreram, a companhia ferroviária gostaria de automatizar sua operação.Parte do programa a ser desenvolvido é uma rotina
        que decide para um determinado trem o menor número de trocas de dois vagões adjacentes necessários para ordenar o trem.Sua tarefa é criar essa rotina.

        Entrada:
        A entrada contém na primeira linha o número de casos de teste (N ). Cada caso de teste consiste em duas linhas de entrada. A primeira linha de um caso de teste contém um inteiro L,
        determinando o comprimento do trem (0 ≤ L ≤ 50). A segunda linha de um caso de teste contém uma permutação dos números de 1 a L,
        indicando a ordem atual dos carros.Os carros devem ser ordenados de modo que o carro 1 venha primeiro, depois o 2, etc., com o carro L vindo por último.
        Resultado
        Para cada caso de teste, imprima a sentença: 'A troca de trem ideal requer S trocas.' onde S é um número inteiro.
        Saída:
        Para cada caso de teste, imprima a sentença: 'A troca de trem ideal requer S trocas.' onde S é um número inteiro.

        Amostra de entrada	Amostra de saída
        3               
        3
        1 3 2                   A troca de trem ideal leva 1 troca.
        4
        4 3 2 1                 A troca de trem ideal leva 6 trocas.
        2
        2 1                     A troca de trem ideal leva 1 troca.*/
        public static void Main6()
        {
            Console.WriteLine("Digite a quantidade de casos de testes");
            int numeroDeTestes = Convert.ToInt32(Console.ReadLine());            
            GerarLista(numeroDeTestes);
        }
        public static void GerarLista(int recebernNmeroDeTestes)
        {
            bool trueOrFalseWhileTwo = true;
            int receberOnumeroDeTestes = 0;
            while (trueOrFalseWhileTwo)
            {
                if (receberOnumeroDeTestes == recebernNmeroDeTestes)
                {
                    Console.WriteLine("Fim do programa");                    
                    break;
                }                
                Console.WriteLine("Digite quantos vagoes o trem irá ter");
                int receberQuantidadeDeVagoes = Convert.ToInt32(Console.ReadLine());
                var random = new Random();
                var listaDeVagoes = new List<int>();
                for (int i = 0; i < receberQuantidadeDeVagoes; i++)
                {
                    var receberNumerosAleatorios = random.Next(1, receberQuantidadeDeVagoes + 1);
                    if (i == 0)
                    {
                        listaDeVagoes.Add(receberNumerosAleatorios);
                    }
                    else
                    {
                        int verificarSeOnumeroJaExisteNaLista;
                        int l;
                        bool trueOrFalseWhile = true;
                        while (trueOrFalseWhile)
                        {
                            receberNumerosAleatorios = random.Next(1, receberQuantidadeDeVagoes + 1);
                            for (verificarSeOnumeroJaExisteNaLista = 0, l = 0; l < listaDeVagoes.Count; l++)
                            {
                                if (receberNumerosAleatorios != listaDeVagoes[l])
                                {
                                    verificarSeOnumeroJaExisteNaLista++;
                                }
                            }
                            if (verificarSeOnumeroJaExisteNaLista == l)
                            {
                                listaDeVagoes.Add(receberNumerosAleatorios);
                                trueOrFalseWhile = false;
                            }
                            else if (listaDeVagoes.Count == receberQuantidadeDeVagoes)
                            {
                                trueOrFalseWhile = false;
                            }
                        }
                    }
                }
                string exibirListatwo = String.Join("", listaDeVagoes);
                Console.WriteLine(exibirListatwo);
                int[] array = new int[receberQuantidadeDeVagoes];
                for (int i = 0; i < listaDeVagoes.Count; i++)
                {
                    array[i] = listaDeVagoes[i];
                }
                VerificarQuantasVezesAtrocaSeraFeita(array, receberQuantidadeDeVagoes);
                receberOnumeroDeTestes++;
            }                        
        }
        public static void VerificarQuantasVezesAtrocaSeraFeita(int[] receiveListCars,int receberAquantidadeDevagoes)
        {
            int quantidadeDeNumerosTrocados = 0;
            bool trueOrFalseWhile = true;
            int[] receiveexchangeListCars = new int[receberAquantidadeDevagoes];
            var listEnumerada = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
            quantidadeDeNumerosTrocados = 0;
            while (trueOrFalseWhile)
            {
                for (int i = 0; i < receiveListCars.Length; i++)
                {
                    if (receiveListCars[i] > receiveListCars[i + 1])
                    {
                        quantidadeDeNumerosTrocados++;
                        receiveexchangeListCars[i] = receiveListCars[i + 1];
                        receiveexchangeListCars[i + 1] = receiveListCars[i];

                        if (i + 2 > receiveexchangeListCars.Length) break;                                                                            
                        for (int n = i + 2; n < receiveListCars.Length; n++)
                        {
                            receiveexchangeListCars[n] = receiveListCars[n];
                        }
                        Array.Clear(receiveListCars);
                        receiveListCars = new int[receberAquantidadeDevagoes];
                        for (int v = 0; v < receiveexchangeListCars.Length; v++)
                        {
                            receiveListCars[v] = receiveexchangeListCars[v];
                        }
                        Array.Clear(receiveexchangeListCars);
                        break;
                    }
                    else
                    {
                        receiveexchangeListCars[i] = receiveListCars[i];
                    }
                }
                int verificar = 0;
                for (int i = 0; i < receiveListCars.Length; i++)
                {                    
                    if (receiveListCars[i] != listEnumerada[i]) break;
                    verificar++;
                }
                if (verificar == receiveListCars.Length)
                {
                    trueOrFalseWhile = false;
                }
            }
            Console.WriteLine($"A quantidade de trocas foi {quantidadeDeNumerosTrocados}");
        }
    }
}
