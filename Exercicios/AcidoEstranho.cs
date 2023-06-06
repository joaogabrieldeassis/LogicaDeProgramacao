namespace Exercicios
{
    public class AcidoEstranho
    {
        /*
         Um tipo estranho de ácido ribonucleico (popularmente conhecido como RNA) foi descoberto. Os cientistas, por falta de criatividade, batizaram a descoberta de ácido
        ribonucléico alienígena (RNAA). Semelhante ao RNA que conhecemos, o RNAA é uma fita composta por várias bases. As bases são CFBS e podem se conectar em pares.
        Os únicos pares possíveis estão entre as bases B e S e as bases C e F.
        Enquanto ativo, o RNAA dobra vários intervalos da fita em torno de si, fazendo conexões entre suas bases. Os cientistas perceberam que:

        Quando um intervalo da fita de RNAA se dobra, todas as bases neste intervalo se ligarão às suas bases correspondentes:
        - Cada base pode se ligar a apenas uma outra base:
        - As dobras ocorrem para maximizar o número de chamadas feitas nas fitas

        Sua tarefa é, dada a descrição de uma faixa de RNAA, determinar quantas conexões
        são feitas entre suas bases caso a faixa se torne ativa.
        Entrada
        A entrada consiste em vários casos de teste e termina com EOF. Cada caso de teste possui uma linha que descreve a sequência de bases da faixa de RNAA.
        Uma faixa de RNAA contém pelo menos uma e no máximo 300 bases. Não há espaços em branco entre as bases de uma fita. As bases são 'B', 'C', 'F' e 'S'.

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
            ReceberAEntradaDoUsuario();
        }
        public static void ReceberAEntradaDoUsuario()
        {
            Console.WriteLine("Digite as letras do programa");
            string receberAentradaDoUsuario = Console.ReadLine();
            CalculoParaDefinirOtamanhoDaMatriz(receberAentradaDoUsuario);
        }

        public static void CalculoParaDefinirOtamanhoDaMatriz(string receberAEntradaDoUsuario)
        {
            double definirQuantasLinhasAmatrizIraTer = receberAEntradaDoUsuario.Length <= 4 ? receberAEntradaDoUsuario.Length / 2.0 : receberAEntradaDoUsuario.Length / 4.0;
            double definirQuantasColunasAmatrizIraTer = receberAEntradaDoUsuario.Length / definirQuantasLinhasAmatrizIraTer;
            if (VerificarSeEImpar(receberAEntradaDoUsuario.Length))
            {
                definirQuantasLinhasAmatrizIraTer = Math.Ceiling(definirQuantasLinhasAmatrizIraTer);
                definirQuantasColunasAmatrizIraTer = Math.Ceiling(definirQuantasColunasAmatrizIraTer);
            }
            char[,] matrizParaArmazenarOsDadosDoUsuario = new char[(int)definirQuantasLinhasAmatrizIraTer, (int)definirQuantasColunasAmatrizIraTer];

            AtribuirDadosEmBrancoAmatriz(matrizParaArmazenarOsDadosDoUsuario, receberAEntradaDoUsuario);
        }

        public static bool VerificarSeEImpar(int number) => number % 2 != 0;

        public static void AtribuirDadosEmBrancoAmatriz(char[,] receberMatriz, string receberEntradaDoUsuario)
        {
            for (int percorrerLinhaDaMatriz = 0, percorrerArrayDeCaracters = 0; percorrerLinhaDaMatriz < receberMatriz.GetLength(0); percorrerLinhaDaMatriz++)
            {
                for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberMatriz.GetLength(1); percorrerColunaDaMatriz++, percorrerArrayDeCaracters++)
                {
                    receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] = '0';
                }
            }
            AtribuirStringDoUsuarioAoArrayDeCaracters(receberMatriz, receberEntradaDoUsuario);
        }

        public static void AtribuirStringDoUsuarioAoArrayDeCaracters(char[,] receberMatriz, string receberOsDadosDaMatriz)
        {
            char[] receberAstringEmCaractersParaAtribuirAmatriz = receberOsDadosDaMatriz.ToCharArray();
            AtribuirDadosDoUsuarioParaAmatriz(receberMatriz, receberAstringEmCaractersParaAtribuirAmatriz);
        }
        public static void AtribuirDadosDoUsuarioParaAmatriz(char[,] receberMatriz, char[] receberArrayDeCaracteres)
        {
            int trocarAformaDePercorrerAmatriz = 0;
            for (int percorrerLinhaDaMatriz = 0, percorrerArrayDeCaracters = receberArrayDeCaracteres.Length - 1; percorrerLinhaDaMatriz < receberMatriz.GetLength(0); percorrerLinhaDaMatriz++)
            {
                if (trocarAformaDePercorrerAmatriz == 0)
                {
                    trocarAformaDePercorrerAmatriz = 1;
                    for (int percorrerColunaDaMatriz = receberMatriz.GetLength(1) - 1; percorrerColunaDaMatriz >= 0; percorrerColunaDaMatriz--, percorrerArrayDeCaracters--)
                    {
                        receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] = receberArrayDeCaracteres[percorrerArrayDeCaracters];
                        if (percorrerArrayDeCaracters == 0) break;
                    }
                }
                else
                {
                    trocarAformaDePercorrerAmatriz = 0;
                    for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberMatriz.GetLength(1); percorrerColunaDaMatriz++, percorrerArrayDeCaracters--)
                    {
                        receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] = receberArrayDeCaracteres[percorrerArrayDeCaracters];
                        if (percorrerArrayDeCaracters == 0) break;
                    }
                }
            }
            ValidarOtamanhoDaMatrixParaVerificarSuasConexoes(receberMatriz);
        }
        public static void ValidarOtamanhoDaMatrixParaVerificarSuasConexoes(char[,] receberMatriz)
        {
            if (receberMatriz.Length <= 8)
                VerificarAsConexoesDaMatrizComTamanhoMenorDoQueOito(receberMatriz);
            else
                VerificarAsConexoesDaMatrizComTamanhoMaiorDoQueOito(receberMatriz);
        }
        public static void VerificarAsConexoesDaMatrizComTamanhoMenorDoQueOito(char[,] receberMatriz)
        {
            int incrementarOnumeroDeConexoesFeitas = 0;
            for (int percorrerLinhaDaMatriz = 0; percorrerLinhaDaMatriz < 1; percorrerLinhaDaMatriz++)
            {
                for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberMatriz.GetLength(1); percorrerColunaDaMatriz++)
                {
                    if (receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] == 'S' && receberMatriz[percorrerLinhaDaMatriz + 1, percorrerColunaDaMatriz] == 'B'
                        || receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] == 'B' && receberMatriz[percorrerLinhaDaMatriz + 1, percorrerColunaDaMatriz] == 'S')
                        incrementarOnumeroDeConexoesFeitas++;

                    else if (receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] == 'C' && receberMatriz[percorrerLinhaDaMatriz + 1, percorrerColunaDaMatriz] == 'F'
                        || receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] == 'F' && receberMatriz[percorrerLinhaDaMatriz + 1, percorrerColunaDaMatriz] == 'C')
                        incrementarOnumeroDeConexoesFeitas++;
                }
            }
            Console.WriteLine($"O total de conexoes foi de {incrementarOnumeroDeConexoesFeitas}");
        }
        public static void VerificarAsConexoesDaMatrizComTamanhoMaiorDoQueOito(char[,] receberMatriz)
        {
            int mudarOrdemDePercorrer = 0, incrementarOnumeroDeConexoesFeitas = ValidarOantepenultimoComOsegundoCaracter(receberMatriz);
            int teste = receberMatriz.GetLength(0);
            for (int linhaDaMatriz = 0; linhaDaMatriz < receberMatriz.GetLength(0)-1; linhaDaMatriz++)
            {
                for (int percorrerColunaDaMatrizDoComecoAoFim = 0, percorrerColunaDaMatrizDoFimAoComeco = 3; percorrerColunaDaMatrizDoComecoAoFim < 2; percorrerColunaDaMatrizDoComecoAoFim++, percorrerColunaDaMatrizDoFimAoComeco--)
                {
                    if (receberMatriz[linhaDaMatriz, percorrerColunaDaMatrizDoComecoAoFim] == 'B' && receberMatriz[linhaDaMatriz + 1, percorrerColunaDaMatrizDoFimAoComeco] == 'S'
                        || receberMatriz[linhaDaMatriz, percorrerColunaDaMatrizDoComecoAoFim] == 'S' && receberMatriz[linhaDaMatriz+1, percorrerColunaDaMatrizDoFimAoComeco] == 'B')
                        incrementarOnumeroDeConexoesFeitas++;

                    else if (receberMatriz[linhaDaMatriz, percorrerColunaDaMatrizDoComecoAoFim] == 'C' && receberMatriz[linhaDaMatriz + 1, percorrerColunaDaMatrizDoFimAoComeco] == 'F'
                        || receberMatriz[linhaDaMatriz, percorrerColunaDaMatrizDoComecoAoFim] == 'F' && receberMatriz[linhaDaMatriz+1, percorrerColunaDaMatrizDoFimAoComeco] == 'C')
                        incrementarOnumeroDeConexoesFeitas++;
                }
            }
            Console.WriteLine($"O total de conexoes foi de {incrementarOnumeroDeConexoesFeitas}");
        }
        public static int ValidarOantepenultimoComOsegundoCaracter(char[,] matriz)
        {
            int incrementarContadorDeValidação = 0;
            int pegarUltimaLinhaDaMatriz = matriz.GetLength(0)-1;

            if (matriz[0, 2] == 'S' && matriz[pegarUltimaLinhaDaMatriz, 1] == 'B' || matriz[0, 2] == 'B' && matriz[pegarUltimaLinhaDaMatriz, 1] == 'S')
                incrementarContadorDeValidação++;

            else if (matriz[0, 2] == 'C' && matriz[pegarUltimaLinhaDaMatriz, 1] == 'F' || matriz[0, 2] == 'F' && matriz[pegarUltimaLinhaDaMatriz, 1] == 'C')
                incrementarContadorDeValidação++;

            return incrementarContadorDeValidação;
        }
    }
}

