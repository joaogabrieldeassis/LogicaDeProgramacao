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

            AtribuirDadosAmatriz(matrizParaArmazenarOsDadosDoUsuario, receberAEntradaDoUsuario);
        }
        public static bool VerificarSeEImpar(int number) => number % 2 != 0;

        public static void AtribuirDadosAmatriz(char[,] receberMatriz, string receberOsDadosDaMatriz)
        {
            char[] receberAstringEmCaractersParaAtribuirAmatriz = receberOsDadosDaMatriz.ToCharArray();
            for (int percorrerLinhaDaMatriz = 0, percorrerArrayDeCaracters = 0; percorrerLinhaDaMatriz < receberMatriz.GetLength(0); percorrerLinhaDaMatriz++)
            {
                for (int percorrerColunaDaMatriz = 0; percorrerColunaDaMatriz < receberMatriz.GetLength(1); percorrerColunaDaMatriz++, percorrerArrayDeCaracters++)
                {                    
                    receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] = receberAstringEmCaractersParaAtribuirAmatriz[percorrerArrayDeCaracters];
                    if (percorrerArrayDeCaracters + 1 == receberOsDadosDaMatriz.Length)
                    {
                        percorrerColunaDaMatriz++;
                        for (int i = 0; i < percorrerColunaDaMatriz; i++)
                        {
                            receberMatriz[percorrerLinhaDaMatriz, percorrerColunaDaMatriz] = '0';
                        }
                        break;
                    }
                }
            }
        }
    }
}

