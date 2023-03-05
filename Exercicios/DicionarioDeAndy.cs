using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class DicionarioDeAndy
    {
        public static void Main10()
        {
            var lita = new List<string>();
            
            Console.WriteLine("Digite o seu texto");

            var receberTexto = Console.ReadLine();            
            string[] quebrarOtexto = receberTexto.Split(' ');
            string[] receberOtextoEmMinusculo = new string[quebrarOtexto.Length];
            for (int i = 0; i < quebrarOtexto.Length; i++)
            {
                receberOtextoEmMinusculo[i] = quebrarOtexto[i].ToLower();
            }                            
            
            JogarNaTela(receberOtextoEmMinusculo);
        }
        public static void JogarNaTela(string[] receberQuebraDeTextoParametro)
        {
            int receive = receberQuebraDeTextoParametro.Length;

            string[] receberQubraDeTexto = new string[receive];            
            
            string alfabeto = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

            string[] receberAsLetrasDoAlfabeto = alfabeto.Split(',');
            int z = 0;
            for (int i = 0; i < receberAsLetrasDoAlfabeto.Length; i++)
            {
                for (int a = 0; a < receive; a++)
                {
                    var c = receberQuebraDeTextoParametro[a].Substring(0, 1);

                    if (c == receberAsLetrasDoAlfabeto[i])
                    {
                        receberQubraDeTexto[z] = receberQuebraDeTextoParametro[a];
                        z++;
                    }
                }
            }
            foreach (var item in receberQubraDeTexto)
            {
                Console.WriteLine(item);
            }
        }
    }
}
