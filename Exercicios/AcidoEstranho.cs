using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            Console.WriteLine("Digite Apenas as letras ' C F B S ' para o teste");
            var receiveBase = Console.ReadLine();
            var tamanhoDaString = receiveBase.Length;
            decimal maiorDoqueDoze = tamanhoDaString % 4;
            int definirLinhaDaMatriz = tamanhoDaString / 4;
            if (maiorDoqueDoze != 0)
            {
                definirLinhaDaMatriz++;
            }
            char[,] receiveTape;
            switch (tamanhoDaString)
            {
                case <= 4:
                    receiveTape = new char[2, 2];
                    break;
                case <= 8:
                    receiveTape = new char[2, 4];
                    break;
                case > 8:
                    receiveTape = new char[definirLinhaDaMatriz, 4];
                    break;
                default:
            }
            AtribuirDadosAMatriz(receiveTape, receiveBase, definirLinhaDaMatriz, tamanhoDaString);

        }
        public static void AtribuirDadosAMatriz(char[,] receiveMatriz, string receberAsLetras, Int32 receberAdefinicaoDaLinhaDaMatriz, Int32 receberOtamanhoDaString)
        {
            char[] quebrarNumeros = receberAsLetras.ToCharArray();
            byte indexDoArrayDeCaracters = 0, trocarFileira = 0;
            if (receberOtamanhoDaString > 8)
            {
                for (Int32 linha = receberAdefinicaoDaLinhaDaMatriz - 1; linha >= 0; linha--)
                {
                    if (trocarFileira == 0)
                    {
                        trocarFileira++;
                        for (Int16 coluna = 0; coluna != 4; coluna++, indexDoArrayDeCaracters += +1)
                        {
                            receiveMatriz[linha, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                        }
                    }
                    else
                    {
                        trocarFileira = 0;
                        for (Int16 coluna = 3; coluna >= 0; coluna--, indexDoArrayDeCaracters += +1)
                        {
                            receiveMatriz[linha, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                        }
                    }
                }
            }
            /*else if (receberOtamanhoDaString <= 4)
            {
                indexDoArrayDeCaracters = 0;                
                byte mudarAposicaoDaMatriz = 0;
                for (Int16 linhaDaMatriz = 1; linhaDaMatriz >= 0; linhaDaMatriz--)
                {
                    if (mudarAposicaoDaMatriz == 1)
                    {
                        mudarAposicaoDaMatriz = 0;
                        for (Int16 coluna = 1; coluna >= 0; coluna--, indexDoArrayDeCaracters++)
                        {
                            receiveMatriz[linhaDaMatriz, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                            if (indexDoArrayDeCaracters == 0)
                                break;
                        }
                    }
                    else
                    {
                        mudarAposicaoDaMatriz = 1;
                        for (int coluna = 0; coluna <= 1; coluna++, indexDoArrayDeCaracters++)
                        {
                            receiveMatriz[linhaDaMatriz, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                            if (indexDoArrayDeCaracters == 1)
                                break;
                        }
                    }

                }
            }*/
            else if (receberOtamanhoDaString <= 8)
            {
                indexDoArrayDeCaracters = 0;
                Int16 definirOTamanhoDaColuna = receberOtamanhoDaString / 2;               
                byte definirLinhaDaMatriz = 0;
                for (Int16 linha = 0; linha <= 1; linha++)
                {
                    if (definirLinhaDaMatriz == 1)
                    {
                        definirLinhaDaMatriz = 0;
                        for (Int16 coluna = definirOTamanhoDaColuna; coluna >= 0; coluna--, indexDoArrayDeCaracters--)
                        {
                            receiveMatriz[linha, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                            if (indexDoArrayDeCaracters == receberOtamanhoDaString || indexDoArrayDeCaracters == 0)
                                break;
                        }
                    }
                    else
                    {
                        definirLinhaDaMatriz = 1;
                        for (Int16 coluna = 0; coluna <= definirOTamanhoDaColuna; coluna++, indexDoArrayDeCaracters--)
                        {
                            receiveMatriz[linha, coluna] = quebrarNumeros[indexDoArrayDeCaracters];
                            if (indexDoArrayDeCaracters == receberOtamanhoDaString || indexDoArrayDeCaracters == 0)
                                break;
                        }
                    }
                }
            }
            VerificarQuantasConexoesEpossivelFazer(receiveMatriz);
        }
        public static void VerificarQuantasConexoesEpossivelFazer(char[,] receberMatrizComOsDadosAtribuidos)
        {
            if (receberMatrizComOsDadosAtribuidos.Length <= 8)
            {
                double dividirMatrizNoMeio = receberMatrizComOsDadosAtribuidos.Length / 2;
                Int16 receberAdivisaoDaMatriz = (short)Math.Ceiling(dividirMatrizNoMeio);
                Int16 linhaDaMatriz = 0;
                Int16 validarAcontagemDaOperacao = 0;
                for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberAdivisaoDaMatriz; percorrerColunaDaMatriz++)
                {
                    if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 'B' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 'b'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 'S' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 's')
                    {
                        if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz+1, percorrerColunaDaMatriz] == 'B' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz+1, percorrerColunaDaMatriz] == 'b'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'S' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 's')
                        {
                            validarAcontagemDaOperacao++;
                        }
                        
                    }
                    else
                    {
                        if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'C' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'f'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'F' || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'c')
                        {
                            validarAcontagemDaOperacao++;
                        }
                    }
                }
                Console.WriteLine($"O total de conexões foi de {validarAcontagemDaOperacao}");
            }
            else
            {

            }
            
        }
    }
}

