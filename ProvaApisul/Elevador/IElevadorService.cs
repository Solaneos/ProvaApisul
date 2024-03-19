using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaApisul.Elevador
{
    public interface IElevadorService
    {
        List<string> elevadorMaisFrequentado();
        List<string> periodoMaiorFluxoElevadorMaisFrequentado();
        List<string> elevadorMenosFrequentado();
        List<string> periodoMenorFluxoElevadorMenosFrequentado();
        List<string> periodoMaiorUtilizacaoConjuntoElevadores();
        List<int> andarMenosUtilizado();

        float percentualA();
        float percentualB();
        float percentualC();
        float prcentualD();
        float percentualE();
    }
}
