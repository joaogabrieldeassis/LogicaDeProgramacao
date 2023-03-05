using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    public class EquilíbrioEntreParênteses
    {
        //Considerando uma expressão entre parênteses, imprima uma mensagem informando se o entre parênteses está correto ou incorreto, sem considerar o restante da expressão.Exemplo:
        //a+(b* c)-2-a está correto
        //(a+b*(2-c)-2+a)*2  está correto
        //quando

        //(a* b-(2+c)         está incorreto
        //2*(3-a))           está incorreto
        //)3+b* (2-c)(está incorreto

        // Resumindo, todos os parênteses de fechamento devem ter um parêntese aberto e não é possível um parêntese de fechamento sem um parêntese aberto prévio, e a quantidade de parênteses de fechamento e abertura deve ser a mesma.

        // Entrada
        // O arquivo de entrada contém N expressões (1 <= N <= 10000), cada uma com até 1000 caracteres.

        // Resultado
        // A saída deve estar correta ou incorreta para cada caso de teste de acordo com as regras acima.
        static void Main1()
        {

            Parenteses();
        }

        static bool Parenteses()
        {
            while (true)
            {
                var jhonNumbers = "";
                int parenteses1 = 0;
                int parenteses2 = 0;
                Console.Clear();
                Console.WriteLine("Digite a sua expressão");
                jhonNumbers = (Console.ReadLine());
                foreach (var item in jhonNumbers)
                {
                    if (item == '(')
                    {
                        parenteses1++;
                    }
                    if (item == ')')
                    {
                        parenteses2++;
                    }
                }
                if (parenteses1 == parenteses2)
                {
                    Console.WriteLine("Correto");
                }
                else
                {
                    Console.WriteLine("Incorreto");
                }
                Console.WriteLine("Deseja fazer outra operação? S para sim, N para não");
                char operação = Convert.ToChar(Console.ReadLine());
                if (operação == 'n' || operação == 'N')
                {
                    return false;
                }
            }
        }
    }
}
