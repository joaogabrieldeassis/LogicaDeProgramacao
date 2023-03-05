using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//https://docs.microsoft.com/pt-br/dotnet/api/system.string.substring?view=net-6.0
namespace teste
{
    public class InfixoParaPosfixo
    {
        /*
        * O professor pediu que você escrevesse um programa que convertesse uma expressão infixa em uma expressão posfixada. Como você sabe, os termos in e pos estão de acordo com a posição dos operadores. O programa terá que lidar apenas com os operadores binários +, -, *, /, ^. parênteses, letras e números. Um exemplo seria uma expressão como:
        (A*B+2*C^3)/2*A. O programa deve converter esta expressão (infixa) para a expressão posfix: AB*2C3^*+2/A*
        Todas as expressões dos casos de teste são expressões com sintaxe válida.

        Entrada
        A primeira linha de entrada é um inteiro N ( N < 1000), que indica o número total de casos de teste. Cada caso é uma expressão válida no formato infixo.

        Resultado
        Para cada caso de teste, imprima a expressão convertida em expressão posfix.
        */

        /*
         * Expressão (A+B)*C-(D-E)*(F+G)
        A expressão pósfixa segue a mesma lógica de infixa, elá é executada da esquerda para a direita, então que tem preferencia vai para a esquerda 
        Com o simbolo de + e - está entre parenteses, devemos fazer com que eles sejam executados primeiros.
         */
        static void Main3()
        {
            CalcularAExpressao();
        }
        public static void CalcularAExpressao()
        {
            int iOne = 0;
            int iTwo = 0;
            var list = new List<InfixaParaPosfixa>();
            Console.WriteLine("Notação infixa para a Posfixa");
            list.Add(new InfixaParaPosfixa("(A*(B*C+D))"));
            foreach (var item in list)
            {
                
                foreach (var count in item.Expressao)
                {
                    if (count == '*' || count == '/' || count == '-' || count == '+')
                    {
                        iOne++;
                    }
                }
                foreach (var expressao in item.Expressao)
                {
                     if (expressao == '(')
                     {
                        item.Pilha += expressao;
                     }
                    else if (expressao == '*' || expressao == '/' || expressao == '-' || expressao == '+')
                    {
                        iTwo++;
                        item.Pilha += expressao;
                        if (iOne <= iTwo)
                        {
                            Desempilhar(list);
                        }
                    }

                    else if (expressao == ')')
                    {
                        CloseParents(list);
                    }
                    else if(expressao != ' ')
                    {
                        item.PosFixa += expressao;
                    }
                }
                
            }
        }

        public static void CloseParents(List<InfixaParaPosfixa> list)
        {
            foreach (var item in list)
            {
                for (int i = item.Pilha.Length - 1; i >= 0 || i == '('; i--)
                {
                    if (item.Pilha[i] != '(' && item.Pilha[i] != ' ')
                    {
                        item.PosFixa += item.Pilha[i];
                    }
                    
                }
            }
        }
        public static void Desempilhar(List<InfixaParaPosfixa> list)
        {
            foreach (var item in list)
            {
                for (int i = item.Pilha.Length - 1; i >= 0; i--)
                {
                    if (item.Pilha[i] == '*' || item.Pilha[i--] == '/' )
                    {
                        string receivePilha = item.Pilha;
                        item.PosFixa += item.Pilha[i];
                        string receiveTheReceive = receivePilha.Remove(i);
                        item.Pilha = receiveTheReceive;
                    }
                    else if (item.Pilha[i] != '(' && item.Pilha[i] != ' ')
                    {
                        char a = item.Pilha[i];
                        string receive = "";
                        string receiveTheReceive = "";
                        item.PosFixa += item.Pilha[i];
                        receive = item.Pilha;
                        receiveTheReceive = receive;
                        item.Pilha = receive;
                    }

                    else if (item.Pilha[i] == '(') 
                    {
                        item.Pilha = item.Pilha.Remove(i);
                    }
                    break;
                }
            }
        }
    }
    public class InfixaParaPosfixa
    {
        public InfixaParaPosfixa()
        {

        }
        public InfixaParaPosfixa(string expressao) 
        {
            Expressao = expressao;
        }
        public InfixaParaPosfixa(string pilha, string posFixa)
        {
            Pilha = pilha;
            PosFixa = posFixa;
        }
        public string Pilha { get; set; }
        public string Expressao { get; }
        public string PosFixa { get; set; }
    }
}
