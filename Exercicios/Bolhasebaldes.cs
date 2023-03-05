namespace teste
{
    public class Bolhasebaldes
    {
        /*
         Andrea, Carlos e Marcelo são amigos íntimos e passam os fins de semana à beira da piscina. Enquanto Andrea se bronzeia, os dois amigos jogam Bubbles .
        Andrea, uma cientista da computação muito inteligente, já disse a eles que não entende por que eles gastam tanto tempo jogando um jogo tão simples.

        Usando seu laptop, Carlos e Marcelo geram um inteiro aleatório N e uma sequência, também aleatória, que é uma permutação de 1, 2, ..., N .

        O jogo então começa. Os jogadores jogam por turnos e, a cada turno, um jogador faz um movimento. Marcelo é sempre o primeiro a jogar.
        Uma jogada consiste em escolher um par de elementos consecutivos que estão fora de ordem na sequência e trocar os dois elementos.
        Por exemplo, dada a sequência 1, 5, 3, 4, 2 , um jogador pode trocar 3 e 5 ou 4 e 2 , mas não pode trocar 3 e 4 nem 5 e 2 .
        Continuando com o exemplo, se o jogador decidir trocar 5 e 3 , a nova sequência será 1, 3, 5, 4, 2 .

        Mais cedo ou mais tarde, a sequência será ordenada. O jogador que não pode fazer um movimento perde.
        Andrea, com desdém, sempre diz que seria mais simples jogar par ou ímpar, para o mesmo efeito.
        Sua missão, caso decida aceitá-la, é determinar quem ganha o jogo, dada a permutação inicial P .

        Entrada
        A entrada contém vários casos de teste. Cada caso de teste é composto por uma única linha, na qual todos os inteiros são separados por um espaço.
        Cada linha contém um inteiro N ( 2 ≤ N ≤ 10 5 ), seguido pela sequência inicial P = ( X 1 , X 2 , ...,X N ) de N inteiros distintos,
        com 1 ≤ X i ≤ N para 1 ≤ i ≤ N .

        O fim da entrada é indicado por uma linha contendo apenas um zero.
         */
        public static void Main4(string []args)
        {
            Console.WriteLine("Digite a entrada de 1 a 9");
            int entrada = Convert.ToInt32(Console.ReadLine());
            GerarListaAleatoria(entrada);
        }
        public static void GerarListaAleatoria(int entrada)
        {
            
            List<int> numbersInt = new List<int> { 1,2,3,4,5,6,7,8,9};
            List<int> listaTemporaria = new(9);
            var passarArrayParaOproximoMetodo = new int[9];
            var list = new List<int>();
            var random = new Random();
            var result = "";
            int validationListTemporaria;
            int m;
            int y;
            bool validationNumbersList;
            int numbers = random.Next(entrada, entrada);
            for (int i = 0; i < numbers; i++)
            {
               list.Add(random.Next(1, numbers));
            }            
            for (int i = 0; i < list.Count; i++)
            {
                int number = random.Next(1, numbers);                
                if (i > 0 )
                {
                    for (m = 0, validationListTemporaria = 0; m < listaTemporaria.Count; m++)
                    {
                        if (listaTemporaria[m] != number)
                        {
                            validationListTemporaria++;
                        }                            
                    }
                    if (validationListTemporaria == m)
                    {
                        listaTemporaria.Add(number);
                    }
                }
                else
                {
                    listaTemporaria.Add(number);
                }
            }
            for (int i = 0; i < numbersInt.Count; i++)
            {
                if (i == entrada)
                {
                    break;
                }
                for (y = 0,validationNumbersList = true; y < listaTemporaria.Count; y++)
                {
                    if (numbersInt[i] == listaTemporaria[y])
                    {
                        validationNumbersList = false;
                    }              
                }
                if (validationNumbersList == true)
                { 
                    listaTemporaria.Add(numbersInt[i]);
                }
            }            
            for (int i = 0; i < listaTemporaria.Count; i++)
            {
                    passarArrayParaOproximoMetodo[i] = listaTemporaria[i];
                    result += listaTemporaria[i].ToString();
            } 
            
            Console.WriteLine($"Entrada {numbers} - Aleatorio Gerado {result}");
            TrocarNumeros(entrada, passarArrayParaOproximoMetodo);
        }
        public static void TrocarNumeros(int entrada, params int[] trocarNumeros)
        {
            List<int> numbersInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var listTwo = new int[9];                                    
            int one = 0;
            int two = 0;
            int i;
            bool verificarWhile = true;
            while (verificarWhile)
            {
                string stringDaLista = "";
                foreach (var item in trocarNumeros)
                {
                    
                    stringDaLista += item.ToString();
                }
                Console.Clear();
                Console.WriteLine($"Sua lista - {stringDaLista}");
                Console.WriteLine("Digite os dois valores a serem trocados");
                int numberOne = Convert.ToInt32(Console.ReadLine());
                
                int numberTwo = Convert.ToInt32(Console.ReadLine());
                for (int z = 0; z < trocarNumeros.Length; z++)
                {                    
                    if (trocarNumeros[z] == numberOne)
                    {
                        one = z;
                    }
                    else if (trocarNumeros[z] == numberTwo)
                    {
                        two = z;
                    }
                }
                for (i = 0; i < trocarNumeros.Length; i++)
                {
                    if (trocarNumeros[i] == numberOne)
                    {
                        if (two == i-1 || i+1 == two)
                        {                          
                            if (trocarNumeros[i] != trocarNumeros[two]-1 && trocarNumeros[i] != trocarNumeros[two]+1)
                            {
                                listTwo[i] = trocarNumeros[two];
                            }
                            else
                            {
                                Console.WriteLine("Os valores trocados, estão em sequencia númerica");
                                Console.WriteLine("Clique enter para jogar novamente");
                                Console.ReadLine();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Os valores trocados, não estão em sequencia");
                            Console.WriteLine("Clique enter para jogar novamente");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else if (trocarNumeros[i] == numberTwo)
                    {
                        listTwo[i] = trocarNumeros[one];
                    }
                    else
                    {
                        listTwo[i] = trocarNumeros[i];
                    }
                }
                if (i == trocarNumeros.Length)
                {
                    int validar = 0;
                    Array.Clear(trocarNumeros);
                    for (int p = 0; p < listTwo.Length; p++)
                    {
                        trocarNumeros[p] = listTwo[p];
                    }
                    for (int l = 0; l < trocarNumeros.Length; l++)
                    {
                        if (trocarNumeros[l] == numbersInt[l] && trocarNumeros[l] != 0)
                        {
                            validar++;
                        }
                    }
                    if (validar == entrada)
                    {
                        verificarWhile = false;
                    }
                    else
                    {
                        verificarWhile = true;
                    }
                }                                
            }
        }
        
            
    }
}
