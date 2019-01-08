using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManipulandoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //caminho onde o arquivo 'Veiculos.json' será armazenado
            string path = "...\\ManipulandoJson\\JsonTeste\\Veiculos.json";

            SalvarObjetoEmArquivo(path);
            //ConverterObjetoParaJson();
            //ConverterJsonParaObjeto();

            Console.ReadKey();
        }

        static void ConverterObjetoParaJson()
        {
            Topico topico = new Topico
            {
                Id = 1,
                Titulo = "Erro ao publicar projeto",
                Conteudo = "Estou obtendo o erro XYZ ao publicar meu projeto na hospedagem.",
                Usuario = "Alex",
                Tags = new string[3] { "ASP.NET", "C#", "Visual Studio" }
            };

            string json = JsonConvert.SerializeObject(topico);

            Console.WriteLine(json);
        }

        static void ConverterJsonParaObjeto()
        {
            string json = "{" +
                          " 'Id':1, " +
                          " 'Titulo':'Estudando C# avançado'," +
                          " 'Conteudo':'Manipulando Json com C#'," +
                          " 'Usuario':'Alex'," +
                          " 'Tags': ['ASP.NET','C#','Visual Studio', 'Json']" +
                          "}";

            Topico topico = JsonConvert.DeserializeObject<Topico>(json);

            Console.WriteLine($"{topico.Usuario}\n{topico.Titulo}\n{topico.Conteudo}");
        }

        static bool SalvarObjetoEmArquivo(string path)
        {
            try
            {
                List<Veiculo> veiculos = CriarListaDeVeiculos();

                StreamWriter stream = new StreamWriter(path);
                JsonTextWriter writer = new JsonTextWriter(stream);
                JsonSerializer serializer = new JsonSerializer();

                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, veiculos);
                stream.Close();

                return LerObjetoDeArquivo(path);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        static bool LerObjetoDeArquivo(string path)
        {
            try
            {
                StreamReader stream = new StreamReader(path);
                JsonTextReader reader = new JsonTextReader(stream);
                JsonSerializer serializer = new JsonSerializer();

                List<Veiculo> veiculos = serializer.Deserialize<List<Veiculo>>(reader);

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

                stream.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        static List<Veiculo> CriarListaDeVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            for (int i = 0; i < 50; i++)
            {
                veiculos.Add(new Veiculo(i + 1985, $"CGO-{i + 320}", "Mitsubishi Lancer", 60 * 1250, 85 * 155 * i)
                {
                    DataCadastro = DateTime.Now.Date,
                    NumChassi = Guid.NewGuid()
                });
            }
            return veiculos;
        }
    }
}
