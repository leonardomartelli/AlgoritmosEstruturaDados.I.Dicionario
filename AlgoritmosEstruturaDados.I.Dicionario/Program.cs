using System;
using System.IO;
using System.Text.Json;

namespace AlgoritmosEstruturaDados.I.Dicionario
{
    class Program
    {
        static void Main()
        {
            Dicionario dicionario;
            
            if(File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "save.json")))
                dicionario = JsonSerializer.Deserialize(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "save.json")), typeof(Dicionario)) as Dicionario;

            else
                dicionario = new Dicionario();

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(" 1. Cadastra palavra;");
                Console.WriteLine(" 2. Consulta palavra;");
                Console.WriteLine(" 3. Remove palavra;");
                Console.WriteLine(" 4. Conta numero de palavras;");
                Console.WriteLine(" 5. Escreve ordem alfabética;");
                Console.WriteLine(" 6. Escreve ordem alfabética inversa;");
                Console.WriteLine(" 7. Escreve palavras com letra escolhida;");
                Console.WriteLine(" 8. Consulta significado da palavra;");
                Console.WriteLine(" 9. Escreve palavras sem significado;");
                Console.WriteLine("10. Escreve total de consultas;");
                Console.WriteLine("11. Escreve total de consultas de uma palavra;");
                Console.WriteLine();

                int.TryParse(Console.ReadLine(), out int escolha);

                switch(escolha)
                {
                    case 1:
                        dicionario.CadastrarPalavra();
                        Console.WriteLine();
                        continue;
                    case 2:
                        dicionario.ConsultaPalavra();
                        Console.WriteLine();
                        continue;
                    case 3:
                        dicionario.RemovePalavra();
                        Console.WriteLine();
                        continue;
                    case 4:
                        Console.WriteLine($"O dicionario contem {dicionario.Contador} palavras");
                        Console.WriteLine();
                        continue;
                    case 5:
                        dicionario.EscreveAlfabetica();
                        Console.WriteLine();
                        continue;
                    case 6:
                        dicionario.EscreveAlfabeticaInversa();
                        Console.WriteLine();
                        continue;
                    case 7:
                        dicionario.EscrevePalavrasLetra();
                        Console.WriteLine();
                        continue;
                    case 8:
                        dicionario.ConsultaSignificadoPalavra();
                        Console.WriteLine();
                        continue;
                    case 9:
                        dicionario.EscreveAlfabeticaSemSignificado();
                        Console.WriteLine();
                        continue;
                    case 10:
                        dicionario.EscreveTotalConsultas();
                        Console.WriteLine();
                        continue;
                    case 11:
                        dicionario.EscreveNumeroConsultasPalavra();
                        Console.WriteLine();
                        continue;
                    default:
                        return;
                }
            }
        }
    }
}
