using ProvaApisul.Elevador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProvaApisul
{
    public class Entrada
    {
        public List<ElevadorModel> pegaInputs()
        {
            //Caminho variavel
            var caminho = "../input.json";

            //Lista dos inputs do json
            List<ElevadorModel> inputs = new List<ElevadorModel>();

            try
            {
                // Lê todo o conteúdo do arquivo JSON
                var json = File.ReadAllText(caminho);

                // Desserializa o JSON
                inputs = JsonSerializer.Deserialize<List<ElevadorModel>>(json);
            }
            catch (FileNotFoundException ex)
            {
                // Caso o arquivo não seja encontrado
                Console.WriteLine($"Arquivo {caminho} não encontrado: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Erro na desserialização do JSON
                Console.WriteLine($"Erro na desserialização do JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Outros erros não tratados
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }

            return inputs;
        }
    }
}
