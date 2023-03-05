using System;
namespace Joao;
public class DiamantesLogica //: Lista
{
    static void Main2()
    {
        Diamantes();
    }
    static void Diamantes()
    {

        /*
         * John está trabalhando em uma mina de diamantes, tentando extrair o maior número de diamantes "<>". Ele deve excluir todas as partículas de areia encontradas "." neste processo e depois que um diamante pode ser extraído, novos diamantes podem ser formados. Se ele tiver como entrada. <... << .. >> ....> .... >>>. três diamantes são formados. O primeiro é retirado de <..> resultante. <... <> ....> .... >>>. O segundo diamante é então removido, deixando. <.......> .... >>>. O terceiro diamante é então removido, deixando no final ..... >>>. sem a possibilidade de extrair novos diamantes.

        Entrada
        Leia um inteiro N que é o número de casos de teste. Em seguida, segue N linhas cada uma com até 1000 caracteres, incluindo "<", ">" e "."

        Resultado
        Você deve imprimir a quantidade de diamantes que podem ser extraídos em cada caso de teste.

        Amostra de entrada      |	Amostra de saída
        2                       |
        <..><.<..>>             |       3                        
        <<<..<......<<<<....>   |       1
         */
        Console.Clear();
        int joao = 0;
        Console.WriteLine("Digite a quantidade de testes a serem feito");
        int receiveTest = Convert.ToInt16(Console.ReadLine());
        for (int i = 0; i < receiveTest; i++)
        {
            int contadorOne = 0;
            int contadorTwo = 0;
            Console.WriteLine("Digite os seus diamantes com pedras !!");
            var jhon = (Console.ReadLine());
            foreach (var item in jhon)
            {
                if (item == '<')
                {
                    contadorOne++;
                }
                if (item == '>')
                {
                    contadorTwo++;
                }
            }
            if (contadorOne > contadorTwo)
            {
                while (contadorOne > contadorTwo)
                {
                    contadorOne--;
                }
                Console.WriteLine(contadorOne);
            }
            if (contadorTwo > contadorOne)
            {
                while (contadorTwo > contadorOne)
                {
                    contadorTwo--;
                }
                Console.WriteLine(contadorTwo);
            }
            if (contadorTwo == contadorOne)
                Console.WriteLine(contadorTwo);
        }
    }
}
