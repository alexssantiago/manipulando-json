using Newtonsoft.Json;
using System;

namespace ManipulandoJson
{
    //[DataContract]
    public class Veiculo
    {
        //[DataMember]
        public Guid NumChassi { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        [JsonIgnore]
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public Veiculo(int ano, string placa, string modelo, decimal precoCompra, decimal precoVenda)
        {
            Ano = ano;
            Placa = placa;
            Modelo = modelo;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
        }

        public override string ToString()
        {
            return $"{Modelo} - {Placa} - {PrecoVenda}";
        }
    }
}
