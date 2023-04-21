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
            var receberStringsDoUsuario = Console.ReadLine().ToUpper();
            var definirOtamanhoDaString = receberStringsDoUsuario.Length;
            decimal definirSeEImparOuPar = definirOtamanhoDaString % 2;
            int definirLinhaDaMatriz = definirOtamanhoDaString / 4;
            int definirColunaDaMatriz = definirOtamanhoDaString / 2;
            if (definirSeEImparOuPar != 0)
            {
                definirColunaDaMatriz++;
            }
            char[,] receiveTape;
            switch (definirOtamanhoDaString)
            {                
                case <= 8:
                    receiveTape = new char[2, definirColunaDaMatriz];
                    break;
                case > 8:
                    receiveTape = new char[definirLinhaDaMatriz, 4];
                    break;
                default:
            }
           char[] enviarArrayDeCaracteresParaAmatriz = AtribuirDadosAoArrayDeCaracteres(definirOtamanhoDaString,receberStringsDoUsuario);
            AtribuirDadosAMatriz(receiveTape, definirLinhaDaMatriz, definirOtamanhoDaString, definirColunaDaMatriz,enviarArrayDeCaracteresParaAmatriz);

        }
        public static char[] AtribuirDadosAoArrayDeCaracteres(int receberOtamanhoDaString, string receberAsLetras)
        {
            Int16 definirSeEparOuImpar = (short)(receberOtamanhoDaString % 2);
            char[] quebrarNumeros = receberAsLetras.ToCharArray();
            char[] colecaoDeCaracters = new char[receberAsLetras.Length + 1];

            for (int i = 0; i < 1; i++)
            {
                if (definirSeEparOuImpar == 1)
                {
                    colecaoDeCaracters = new char[receberAsLetras.Length + 1];
                    colecaoDeCaracters[0] = '0';
                    for (int a = 1; a <= receberOtamanhoDaString; a++)
                    {
                        colecaoDeCaracters[a] = quebrarNumeros[a - 1];
                    }
                }
                else
                {
                    colecaoDeCaracters = new char[receberAsLetras.Length];
                    for (int a = 0; a < receberOtamanhoDaString; a++)
                    {
                        colecaoDeCaracters[a] = quebrarNumeros[a];
                    }
                }
            }
            return colecaoDeCaracters;
        }
        public static void AtribuirDadosAMatriz(char[,] receiveMatriz, Int32 receberAdefinicaoDaLinhaDaMatriz, Int32 receberOtamanhoDaString, Int32 receberColunaDaMatriz, char[] arraDeCaracteres)
        {
            
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
                            receiveMatriz[linha, coluna] = arraDeCaracteres[indexDoArrayDeCaracters];
                        }
                    }
                    else
                    {
                        trocarFileira = 0;
                        for (Int16 coluna = 3; coluna >= 0; coluna--, indexDoArrayDeCaracters += +1)
                        {
                            receiveMatriz[linha, coluna] = arraDeCaracteres[indexDoArrayDeCaracters];
                        }
                    }
                }
            }
            else
            {
                indexDoArrayDeCaracters = 0;                
                byte definirLinhaDaMatriz = 0;                
                for (Int16 linha = 1; linha >= 0; linha--)
                {
                    if (definirLinhaDaMatriz == 1)
                    {
                        definirLinhaDaMatriz = 0;
                        for (Int16 coluna = (short)((short)receberColunaDaMatriz -1); coluna >= 0; coluna--, indexDoArrayDeCaracters++)
                        {
                            receiveMatriz[linha, coluna] = arraDeCaracteres[indexDoArrayDeCaracters];
                        }
                    }
                    else
                    {
                        definirLinhaDaMatriz = 1;
                        for (Int16 coluna = 0; coluna < receberColunaDaMatriz; coluna++, indexDoArrayDeCaracters++)
                        {
                            receiveMatriz[linha, coluna] = arraDeCaracteres[indexDoArrayDeCaracters];
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
                int receberAdivisaoDaMatriz = receberMatrizComOsDadosAtribuidos.Length / 2;                
                Int16 linhaDaMatriz = 0;
                Int16 validarAcontagemDaOperacao = 0;
                for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberAdivisaoDaMatriz; percorrerColunaDaMatriz++)
                {
                    if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 'B'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz, percorrerColunaDaMatriz] == 'S')
                    {
                        if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'B'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'S')
                        {
                            validarAcontagemDaOperacao++;
                        }

                    }
                    else
                    {
                        if (receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'C'
                        || receberMatrizComOsDadosAtribuidos[linhaDaMatriz + 1, percorrerColunaDaMatriz] == 'F')
                        {
                            validarAcontagemDaOperacao++;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine($"O total de conexões foi de {validarAcontagemDaOperacao}");
            }
            else
            {

            }

        }
    }
}

