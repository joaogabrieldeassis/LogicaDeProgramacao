using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios;

public class CampoDeVerao
{
    /*     
             Nas férias de julho, várias escolas da mesma região decidiram organizar um acampamento de verão para seus alunos. Normalmente nesses acampamentos os alunos são divididos
             em chalés coletivos por gênero e idade, sempre com um supervisor ou supervisora ​​que, além de dormir no chalé com o grupo, também fica responsável por criar e executar diversas
             atividades interessantes e emocionantes para todos. idades. Dentre as diversas atividades podemos citar jogos, passeios, Gincana Musical, Competições Noturnas, etc. No primeiro dia de acampamento
             devido à forte chuva, as atividades recreativas foram limitadas e as crianças foram levadas ao ginásio. Fizemos um concurso e uma das atividades consistia em crianças do mesmo grupo em uma
             roda (dispostas no sentido anti-horário) que seriam retiradas uma a uma até sobrar apenas uma criança,

            No momento em que a criança entra na roda ela recebe uma pequena ficha contendo um número entre 1 e 500. Uma vez formada a roda, conta-se até o número correspondente à ficha que a primeira
            criança possui, começando pela criança ao lado dela ou sua. A criança onde termina a contagem, deve ser retirada do grupo. A contagem recomeça de acordo com o número da ficha da criança que acabou de
            ser eliminada. Para tornar o jogo mais interessante, quando o número da ficha é par, a contagem é feita no sentido horário, caso contrário, a contagem é feita no sentido anti-horário.

            A peça teve muito sucesso e o administrador do acampamento pediu que você desenvolvesse um programa para o próximo evento, para que ele soubesse com antecedência qual criança será a vencedora
            de cada grupo, com base nas informações fornecidas.

            Entrada
            A entrada contém muitos casos de teste. A primeira linha de cada entrada contém um único inteiro N (1 ≤ N ≤ 100), indicando o número de crianças que participarão deste jogo. seguem N linhas
            com duas informações, o Nome da criança e o Valor de sua ficha ou cartão (1 ≤ Valor ≤ 500) separados por um espaço em branco, em ordem de aparecimento na formação do círculo inicial.

            Observação: o nome do filho deve ter menos de 30 caracteres, com letras maiúsculas e minúsculas e o caractere “_” (não são permitidos espaços). O fim da entrada é determinado pelo número zero (0).
            Saída
            Para cada caso de teste, deve ser impressa uma linha com a mensagem "Vencedor(a): xxxxxx" (que significa Vencedor: xxxxxx), com um espaço em branco após o caractere ":"
            , indicando o filho vencedor.


     */
    
    public static void Main7()
    {
        int contarRodadas = 0;
        
        AdicionarJogadores(contarRodadas);
    }
    
    public static void AdicionarJogadores(int receberOnumeroDeRodadas)
    {
       
        Console.WriteLine("Digite a quantidade de rodadas");
        int receberAquantidadeDeRodadas = Convert.ToInt32(Console.ReadLine());

        receberOnumeroDeRodadas++;
        if (receberOnumeroDeRodadas == receberAquantidadeDeRodadas) Console.WriteLine("Fim do programa");
        Console.Clear();
        Console.WriteLine("Digite quantas crianças irão participar desse jogo");
        int quantidadeDecriancasQuevaoParticipar = Convert.ToInt32(Console.ReadLine());
        var numeroEnomeDacrianca = new List<Jogadores>();
        var ramdom = new Random();

        for (int i = 0; i < quantidadeDecriancasQuevaoParticipar; i++)
        {
            Console.Clear();
            var receberNumeroAleatorio = ramdom.Next(1, 500);
            Console.WriteLine("Digite o nome da criança");
            var receberNomeDaCriança = Console.ReadLine();
            numeroEnomeDacrianca.Add(new Jogadores(receberNumeroAleatorio, receberNomeDaCriança));
        }
        int receberOprimeiroJogador = 0;
        int primeiroForeach = 0;
        foreach (var item in numeroEnomeDacrianca)
        {
            primeiroForeach++;
            if (primeiroForeach == 1)
            {
                receberOprimeiroJogador = item.Numero;
            }
        }
        EliminarJogador(numeroEnomeDacrianca, receberOprimeiroJogador, receberOnumeroDeRodadas);
    }
    public static void EliminarJogador(List<Jogadores> jogadores, int receberOprimeiroJogador, int receberOnumeroDeRodadas)
    {
        if (VerificarSeEparOuImpar(receberOprimeiroJogador) == true) PercorrerAlistaNoSentidoHorario(jogadores,receberOprimeiroJogador, receberOnumeroDeRodadas);
        PercorrerAlistaNoSentidoAntiHorario(jogadores,receberOprimeiroJogador, receberOnumeroDeRodadas);
        
    }
    public static void PercorrerAlistaNoSentidoHorario(List<Jogadores> receberAlista,int receberAposicaoDoPrimeiroJogador, int receberOnumeroDeRodadas)
    {
        if (receberAlista.Count == 1)
        {
            foreach (var item in receberAlista)
            {
                Console.WriteLine($"{item.Nome} - é o Vencedor !!");
                
                AdicionarJogadores(receberOnumeroDeRodadas);
            }
        }
        int n = 0;        
        int receberAposicaoDoJogador = receberAposicaoDoPrimeiroJogador;
        bool trueOrFalseWhile = true;
        while (trueOrFalseWhile)
        {
            for (int i = 0 ; i < receberAlista.Count; i++,n++)
            {
                if (n == receberAposicaoDoJogador)
                {
                    n = 0;
                    receberAposicaoDoJogador = receberAlista[i].Numero;
                    receberAlista.Remove(receberAlista[i]);
                    trueOrFalseWhile = false;
                    break;
                }
            }
        }
        if (VerificarSeEparOuImpar(receberAposicaoDoJogador) == true) PercorrerAlistaNoSentidoHorario(receberAlista, receberAposicaoDoJogador, receberOnumeroDeRodadas);
        PercorrerAlistaNoSentidoAntiHorario(receberAlista, receberAposicaoDoJogador, receberOnumeroDeRodadas);
    }
    public static void PercorrerAlistaNoSentidoAntiHorario(List<Jogadores> receberAlista, int receberAposicaoDoJogador, int receberOnumeroDeRodadas)
    {
        if (receberAlista.Count == 1)
        {
            foreach (var item in receberAlista)
            {
                Console.WriteLine($"{item.Nome} - é o Vencedor !!");
                
                AdicionarJogadores(receberOnumeroDeRodadas);
            }
        }
        int n = 0;
        int receberAposicaoDoJogadorNaFuncao = receberAposicaoDoJogador;
        bool trueOrFalseWhile = true;
        while (trueOrFalseWhile)
        {
            for (int i = receberAlista.Count-1; i != 0 ; i--, n++)
            {
                if (n == receberAposicaoDoJogador)
                {
                    n = 0;
                    receberAposicaoDoJogadorNaFuncao = receberAlista[i].Numero;
                    receberAlista.Remove(receberAlista[i]);
                    trueOrFalseWhile = false;
                    break;
                }
            }
        }
        if (VerificarSeEparOuImpar(receberAposicaoDoJogadorNaFuncao) == true) PercorrerAlistaNoSentidoHorario(receberAlista, receberAposicaoDoJogadorNaFuncao, receberOnumeroDeRodadas);
        PercorrerAlistaNoSentidoAntiHorario(receberAlista, receberAposicaoDoJogador, receberOnumeroDeRodadas);
    }
    public static bool VerificarSeEparOuImpar(int receberOnumeroDeverificacao) => receberOnumeroDeverificacao % 2 == 0 ? true : false;
}
public class Jogadores
{
    public Jogadores(int numero, string nome)
    {
        Numero = numero;
        Nome = nome;
    }

    public int Numero { get; set; }
    public string Nome { get; set; }
}

