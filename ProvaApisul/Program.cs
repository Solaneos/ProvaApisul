using ProvaApisul;
using ProvaApisul.Elevador;
using System;
using System.Collections.Generic;

namespace ProvaAdmissionalCSharpApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Olá, me chamo Nikolas e estou resolvendo esse desafio!
                Eu sei que no Clean Code, geralmente não devemos utilizar comentários explicando decisões, somente coisas que não ficam tão legíveis no código,
             porém essa pode ser a única comunicação que vamos ter durante esse processo, então deixei alguns comentários pra somente exemplificar o que eu pensei na hora de escrever o código             
             */



            Entrada input = new Entrada();

            List<ElevadorModel> elevadoresModel = input.pegaInputs();

            ElevadorBL elevadores = new ElevadorBL(elevadoresModel);

            elevadores.andarMenosUtilizado();

            elevadores.elevadorMaisFrequentado();

            elevadores.elevadorMenosFrequentado();

            elevadores.periodoMaiorFluxoElevadorMaisFrequentado();

            elevadores.periodoMenorFluxoElevadorMenosFrequentado();

            elevadores.periodoMaiorUtilizacaoConjuntoElevadores();


            Console.WriteLine("O percentual do elevador A é de " + elevadores.percentualA());
            Console.WriteLine("O percentual do elevador B é de " + elevadores.percentualB());
            Console.WriteLine("O percentual do elevador C é de " + elevadores.percentualC());
            Console.WriteLine("O percentual do elevador D é de " + elevadores.prcentualD());
            Console.WriteLine("O percentual do elevador E é de " + elevadores.percentualE());

        }
    }
}