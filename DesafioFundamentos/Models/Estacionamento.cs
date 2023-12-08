using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para estacionar:\n\nObs: deve-se haver 7 caracteres " +
            "e com o padrão - sem espaço e com todas a letras maiúsculas - ABC1234");

            string placaDoCarro = Console.ReadLine();
            string padrão = "^[A-Z]{3}\\d{4}$";

            // Verifica se a placa tem 7 caracteres.
            if (placaDoCarro.Length != 7)
            {
                Console.WriteLine($"\nA placa ({placaDoCarro}) não tem 7 caracteres. Tente de novo.");
            }
            else
            {
                // Verifica se a placa está no padrão exigido.
                if (Regex.IsMatch(placaDoCarro, padrão))
                {
                    veiculos.Add(placaDoCarro);
                    Console.WriteLine("\nCarro cadastrado.");
                }
                else
                {
                    Console.WriteLine($"\nA placa ({placaDoCarro}) não está no padrão ABC1234. Tente de novo.");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pega a quantidade de horas e faz o calculo do preço.
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoInicial + (precoPorHora * horas)); 

                veiculos.Remove(placa);

                Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                // Lista no terminal os veículos estacionados.
                Console.WriteLine("\nOs veículos estacionados são:\n");

                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    Console.WriteLine($"{contador+1}º - {veiculos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}
