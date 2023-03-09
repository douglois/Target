using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teste
{
    public class Program
    {
        static void Main(string[] args)
        {
            List <Dados> dados = new List<Dados>();

            string path = @"C:\Users\douglaslois-mtz\Desktop\dados.json";
            string result = File.ReadAllText(path);
            string diaMenor = "";
            string diaMaior = "";

            dados = JsonConvert.DeserializeObject<List<Dados>>(result);
            double menorValor = 0;
            double maiorValor = 0;
            double mediaValor = 0;

            for (int i = 0; i < dados.Count; i++)
            {
                if( i > 0)
                {
                    if (dados[i].valor == 0)
                    {
                        double valorZero = dados[i].valor;
                    }
                    else if (dados[i].valor < dados[i - 1].valor && dados[i].valor < menorValor)
                    {
                        menorValor = dados[i].valor;
                        diaMenor = dados[i].dia;
                    }
                }
                else
                {
                    menorValor = dados[i].valor;
                }
            }

            Console.WriteLine("O menor valor é: " + menorValor.ToString() + " e ocorreu no dia " + diaMenor);

            maiorValor = dados.Select(i => i.valor).Max();

            for (int i = 0; i < dados.Count; i++)
            {
                if(dados[i].valor == maiorValor)
                {
                    diaMaior = dados[i].dia;
                }
            }

            Console.WriteLine("O maior valor é: " + maiorValor.ToString() + " e ocorreu no dia " + diaMaior);

            mediaValor = (dados.Select(i => i.valor).Sum()) / dados.Count();

            Console.WriteLine("A média do faturamento mensal é de : " + mediaValor.ToString());

            Console.ReadLine();
        }
    }
}
