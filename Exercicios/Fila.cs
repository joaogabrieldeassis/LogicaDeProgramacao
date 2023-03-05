using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    public class Fila
    {
        /*Em uma tentativa séria de diminuir (reduzir) a fila de desempregados, o Novo Partido Nacional do Rinoceronte do Trabalho Verde decidiu a seguinte estratégia.
         * Todos os dias, todos os candidatos a auxílio-doença serão colocados em um grande círculo, voltados para dentro. 
         * Alguém é escolhido arbitrariamente como o número 1, e os demais são numerados no sentido anti-horário até N (que ficará à esquerda do 1). 
         * Partindo de 1 e movendo-se no sentido anti-horário, um funcionário do trabalho conta k candidatos, enquanto outro funcionário começa de N e se move no sentido horário,
         * contando m candidatos. Os dois escolhidos são enviados para retreinamento; se ambos os funcionários escolherem a mesma pessoa,
         * ela (ele) será enviada para se tornar política. Cada oficial então começa a contar novamente na próxima pessoa disponível e o processo continua até que
         * não haja mais ninguém. Observe que as duas vítimas (desculpe,

            Entrada
            Escreva um programa que leia sucessivamente (nessa ordem) os três números ( N , k e m ; k , m > 0, 0 < N < 20) e determine a ordem em que os candidatos são
            enviados para retreinamento. Cada conjunto de três números estará em uma linha separada e o final dos dados será sinalizado por três zeros (0 0 0).

            Resultado
            Para cada trio, imprima uma única linha de números especificando a ordem em que as pessoas são escolhidas. Cada número deve estar em um campo de 3 caracteres.
            Para pares de números, liste primeiro a pessoa escolhida pelo oficial anti-horário. Separe pares sucessivos (ou singletons) por vírgulas 
            (mas não deve haver uma vírgula à direita).*/
        public static void Main5()
        {            
            Console.WriteLine("Bem vindo a fila\nDigite quantas pessoas irá ter na fila");
            int quantidadeDePessoasNaFila = Convert.ToInt32(Console.ReadLine());
            GerarListaAleatoria(quantidadeDePessoasNaFila);
        }
        public static void GerarListaAleatoria(int quantidadeDePessoasNaFila)
        {
            var receive = "";
            int countListOne = 0;
            int n;
            bool TrueOrFalseWhile = true;
            var random = new Random();            
            var listaDePessoas = new List<int>();
            int receberNumeroAleatorio = random.Next(1, quantidadeDePessoasNaFila);            
            for (int i = 0; i < quantidadeDePessoasNaFila; i++)
            {
                if (i == 0)
                {
                    listaDePessoas.Add(receberNumeroAleatorio);
                }
                else
                {
                    while (TrueOrFalseWhile)
                    {
                        receberNumeroAleatorio = random.Next(1, quantidadeDePessoasNaFila+1);
                        for (n = 0,countListOne=0; n < listaDePessoas.Count; n++)
                        {
                            if (receberNumeroAleatorio != listaDePessoas[n])                            
                               countListOne++;                                                        
                        }
                        if (countListOne == n)
                        {
                            listaDePessoas.Add(receberNumeroAleatorio);
                            TrueOrFalseWhile = false;
                        }                      
                    }
                    TrueOrFalseWhile = true;
                }
            }
            foreach (var item in listaDePessoas)
            {
                 receive += item;
            }
            Console.WriteLine(receive);
            EscolhaDosJogadores(listaDePessoas,quantidadeDePessoasNaFila);
        }
        public static void EscolhaDosJogadores(List<int> receberListaAleatoria,int receberQuantidadeDePessoas)
        {
            string receberPosicoesDasListasPositiva = "";            
            string receberCanditadoAvereador = "";
            int x = 0;
            int y = 0;
            bool trueOrFalseWhile = true;            
            while (trueOrFalseWhile)
            {
                if (receberListaAleatoria.Count == 1)
                {
                    Console.Clear();
                    string exibirListatwo = String.Join("", receberListaAleatoria);
                    Console.WriteLine(exibirListatwo);
                    Console.WriteLine($"Funcionario 1 escolha um entre os {receberQuantidadeDePessoas} clientes");
                    int escolhaDoJogadorUmum = Convert.ToInt16(Console.ReadLine());
                    for (int i = 0; i < receberListaAleatoria.Count; i++)
                    {
                        if (receberListaAleatoria[i] == escolhaDoJogadorUmum)
                        {
                            x = i;
                            receberPosicoesDasListasPositiva += " " + " " + receberListaAleatoria[i];
                            receberQuantidadeDePessoas--;
                        }
                    }
                    if (receberQuantidadeDePessoas != 0)
                    {
                        if (receberListaAleatoria[x] == receberListaAleatoria[y])
                        {
                            receberCanditadoAvereador += Convert.ToString(receberListaAleatoria[x]);
                            receberListaAleatoria.Remove(escolhaDoJogadorUmum);
                        }
                        else
                        {
                            receberListaAleatoria.Remove(escolhaDoJogadorUmum);                           
                        }
                    }
                    else
                    {
                        receberListaAleatoria.Remove(escolhaDoJogadorUmum);
                        Console.WriteLine(receberPosicoesDasListasPositiva);
                        Console.WriteLine("Candito vereador: " + receberCanditadoAvereador);
                        trueOrFalseWhile = false;
                    }
                }
                else
                {
                    Console.Clear();
                    string exibirLista = String.Join("", receberListaAleatoria);
                    Console.WriteLine(exibirLista);
                    Console.WriteLine($"Funcionario 1 escolha um entre os {receberQuantidadeDePessoas} clientes");
                    int escolhaDoJogadorUm = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine($"Funcionario 2 escolha um entre os {receberQuantidadeDePessoas - 1} clientes");
                    int scolhaDoJogadorDois = Convert.ToInt16(Console.ReadLine());

                    for (int i = 0; i < receberListaAleatoria.Count; i++)
                    {
                        if (receberListaAleatoria[i] == escolhaDoJogadorUm)
                        {
                            x = i;
                            receberPosicoesDasListasPositiva += " " + " " + receberListaAleatoria[i];
                            receberQuantidadeDePessoas--;
                        }
                    }
                    for (int i = receberListaAleatoria.Count - 1; i >= 0; i--)
                    {
                        if (receberListaAleatoria[i] == scolhaDoJogadorDois)
                        {
                            y = i;
                            receberPosicoesDasListasPositiva += receberListaAleatoria[i] + " " + " ";
                            receberQuantidadeDePessoas--;
                        }
                    }
                    if (receberQuantidadeDePessoas != 0)
                    {
                        if (receberListaAleatoria[x] == receberListaAleatoria[y])
                        {
                            receberCanditadoAvereador += Convert.ToString(receberListaAleatoria[x]);
                            receberListaAleatoria.Remove(escolhaDoJogadorUm);
                        }
                        else
                        {
                            receberListaAleatoria.Remove(escolhaDoJogadorUm);
                            receberListaAleatoria.Remove(scolhaDoJogadorDois);
                        }
                    }
                    else
                    {
                        Console.WriteLine(receberPosicoesDasListasPositiva);
                        Console.WriteLine("Candito vereador: " + receberCanditadoAvereador);
                        trueOrFalseWhile = false;
                    }
                }                
            }            
        }
    }
}
