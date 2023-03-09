using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class AcidoEstranho
    {
        /*
         Um tipo estranho de ácido ribonucleico (popularmente conhecido como RNA) foi descoberto. Os cientistas, por falta de criatividade, batizaram a descoberta de ácido ribonucléico alienígena (RNAA). Semelhante ao RNA que conhecemos, o RNAA é uma fita composta por várias bases. As bases são CFBS e podem se conectar em pares. Os únicos pares possíveis estão entre as bases B e S e as bases C e F.
        Enquanto ativo, o RNAA dobra vários intervalos da fita em torno de si, fazendo conexões entre suas bases. Os cientistas perceberam que:

        Quando um intervalo da fita de RNAA se dobra, todas as bases neste intervalo se ligarão às suas bases correspondentes:
        - Cada base pode se ligar a apenas uma outra base:
        - As dobras ocorrem para maximizar o número de chamadas feitas nas fitas

        Sua tarefa é, dada a descrição de uma faixa de RNAA, determinar quantas conexões são feitas entre suas bases caso a faixa se torne ativa.
        Entrada
        A entrada consiste em vários casos de teste e termina com EOF. Cada caso de teste possui uma linha que descreve a sequência de bases da faixa de RNAA. Uma faixa de RNAA contém pelo menos uma e no máximo 300 bases. Não há espaços em branco entre as bases de uma fita. As bases são 'B', 'C', 'F' e 'S'.

        Saída
        Para cada caso de teste, imprima uma linha contendo o número total de conexões que ocorrem quando a fita é ativada.

        Entrada de amostra	        Saída de amostra
        SBC                              1
        FCC                              1
        SFBC                             0   
        SFBCFSCB                         4
        CFCBSFFSBCCB                     5
         */
        public static void Main()
        {
            //Se for maior do que 8 os 2 primeiros vão se conectar com os 2 ultimos da ultima fileira.
            ////O terceiro vai se conectar com o segundo da proxima fileira e o quarto com o primeiro da proxima fileira
            ///E assim em diante
            

           

            Console.WriteLine("Digite Apenas as letras ' C F B S ' para o teste");
            var receiveBase = Console.ReadLine();
            var calculate = receiveBase.Length;
            var maiorDoqueDoze = calculate / 4;
            char[,] receiveTape;
            switch (calculate)
            {
                case <= 4:
                    receiveTape = new char[2, 2];
                    break;
                case <= 8:
                    receiveTape = new char[2, 4];
                    break;
                case > 8:
                    receiveTape = new char[maiorDoqueDoze, 4];
                    break;
                default:
            }
            AtribuirDadosAMatriz(receiveTape, receiveBase, calculate);
        }
        public static void AtribuirDadosAMatriz(char[,] receiveMatriz, string receberAsLetras, int receiveCalculate)
        {             
            char[] quebrarNumeros = receberAsLetras.ToCharArray();
            if (receiveCalculate >= 4)
            {                
                for (int coluna = receiveMatriz.Length; coluna != 0; coluna--)
                {
                    
                }
            }
            for (int coluna = receiveMatriz.Length; coluna != 0; coluna--)
            {
                for (int linha = 0; linha < 2; linha++)
                {

                }
            }
        }
    }
}