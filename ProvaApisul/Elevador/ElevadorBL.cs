using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaApisul.Elevador
{
    public class ElevadorBL : IElevadorService
    {
        public ElevadorBL(List<ElevadorModel> elevadores) { this.elevadores = elevadores; }

        // Lista de objetos ElevadorModel
        public List<ElevadorModel> elevadores { get; set; }

        // Método para encontrar o andar menos utilizado
        public List<int> andarMenosUtilizado()
        {    
            List<int> andares = new List<int>();
            // Extrai os andares
            this.elevadores.ForEach(e => andares.Add(e.andar));

            // Agrupa e ordena os andares
            var andaresMenosUtilizados = (from a in andares
                                          group a by a into grupo
                                          orderby grupo.Count() ascending
                                          select grupo.Key).ToList();

            Console.WriteLine("\nAndares menos utilizados:\n");

            andaresMenosUtilizados.ForEach(a => Console.WriteLine(a));

            return andaresMenosUtilizados;
        }

        public List<string> elevadorMaisFrequentado()
        {  
            List<string> elevadores = new List<string>();

            // Extrai os elevadores
            this.elevadores.ForEach(e => elevadores.Add(e.elevador));


            // Agrupa e ordena os elevadores
            var elevadoresMaisFrequentados = (from e in elevadores
                                              group e by e into grupo
                                              orderby grupo.Count() descending
                                              select grupo.Key).ToList();

            Console.WriteLine("\nElevadores mais frequentados:\n");

            elevadoresMaisFrequentados.ForEach(e => Console.WriteLine(e));

            return elevadoresMaisFrequentados;
        }

        public List<string> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            string elevadorMaisFrequentado = this.elevadorMaisFrequentado().First();

            // Filtra os objetos pelo elevador mais grequentado
            var periodos = (from e in this.elevadores
                            where e.elevador == elevadorMaisFrequentado
                            group e.turno by e.turno into grupo
                            orderby grupo.Count() descending
                            select grupo.Key).ToList();


            Console.WriteLine("\nO elevador mais frequentado é " + elevadorMaisFrequentado + " e é mais utilizado no turno " +
                              periodos.First() + "\n");

            return periodos;
        }

        public List<string> elevadorMenosFrequentado()
        {
            List<string> elevadores = new List<string>();

            // Extrai os elevadores
            this.elevadores.ForEach(e => elevadores.Add(e.elevador));


            // Agrupa e ordena
            var elevadoresMenosFrequentados = (from e in elevadores
                                               group e by e into grupo
                                               orderby grupo.Count() ascending
                                               select grupo.Key).ToList();

            Console.WriteLine("\nElevadores menos frequentados:\n");

            elevadoresMenosFrequentados.ForEach(e => Console.WriteLine(e));


            return elevadoresMenosFrequentados.ToList();
        }
        public List<string> periodoMenorFluxoElevadorMenosFrequentado()
        {
            string elevadorMenosFrequentado = this.elevadorMenosFrequentado().First();

            //Filtra os objetos pelo elevador menos frequentado
            var periodos = (from e in this.elevadores
                            where e.elevador == elevadorMenosFrequentado
                            group e.turno by e.turno into grupo
                            orderby grupo.Count() ascending
                            select grupo.Key).ToList();

            Console.WriteLine("\nO elevador menos frequentado é " + elevadorMenosFrequentado + " e é menos utilizado no turno " +
                              periodos.First() + "\n");

            return periodos;
        }

        public List<string> periodoMaiorUtilizacaoConjuntoElevadores()
        {    
            List<string> periodos = new List<string>();

            // Extrai os períodos
            this.elevadores.ForEach(e => periodos.Add(e.turno));


            // Agrupa os períodos e ordena
            var periodoMaiorUtilizacao = (from p in periodos
                                          group p by p into grupo
                                          orderby grupo.Count() descending
                                          select grupo.Key).First();

            Console.WriteLine("\nOs elevadores são mais utilizados no período " + periodoMaiorUtilizacao + "\n");

            return periodos;
        }

        public float percentualA()
        {
            return calculaPercentual("A");
        }
        public float percentualB()
        {
            return calculaPercentual("B");
        }
        public float percentualC()
        {
            return calculaPercentual("C");
        }

        public float prcentualD()
        {
            return calculaPercentual("D");
        }

        public float percentualE()
        {
            return calculaPercentual("E");
        }

        private float calculaPercentual(string elevador)
        {
            List<string> elevadores = new List<string>();

            // Extrai os elevadores de cada objeto
            this.elevadores.ForEach(e => elevadores.Add(e.elevador));

            // Calcula o percentual de utilização do elevador específico
            var percentual = ((float)elevadores.Count(i => i == elevador)) / elevadores.Count * 100;

            return percentual;
        }
    }
}

