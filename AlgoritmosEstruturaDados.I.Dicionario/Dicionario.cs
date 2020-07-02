using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace AlgoritmosEstruturaDados.I.Dicionario
{
    public class Dicionario
    {
        public Dicionario()
        {
            this.Contador = 0;

            this.DicPalavras = new Arvore[26];

            for(int i = 0; i < 26; i++)
                this.DicPalavras[i] = new Arvore();
        }

        public Arvore[] DicPalavras { get; set; }

        [DefaultValue(0)]
        public int Contador { get; set; }

        public void EscreveTotalConsultas()
        {
            var totalConsultas = 0;

            foreach(var arvore in this.DicPalavras)
                totalConsultas += arvore.Soma;

            Console.WriteLine($"Foram feitas um total de {totalConsultas} consultas");
        }

        public void ConsultaPalavra()
        {
            var entrada = Console.ReadLine();

            var arvore = this.DicPalavras[entrada.ToUpper().ToCharArray()[0] - 65];

            var consulta = arvore.ConsultaPalavra(arvore.Raiz, entrada);

            if(consulta is Nodo nodo)
                Console.WriteLine($"Palavra consultada: {nodo.Palavra}\nSignificado:{nodo.Significado}");
            else
                Console.WriteLine("Palavra não encontrada");

            this.Salvar();
        }

        public void ConsultaSignificadoPalavra()
        {
            var entrada = Console.ReadLine();

            var arvore = this.DicPalavras[entrada.ToUpper().ToCharArray()[0] - 65];

            var consulta = arvore.ConsultaPalavra(arvore.Raiz, entrada);

            if(consulta is Nodo nodo)
                Console.WriteLine($"Palavra consultada: {nodo.Palavra}\nSignificado:{nodo.Significado}");
            else
                Console.WriteLine("Palavra não encontrada");
        }

        public void CadastrarPalavra()
        {
            Console.WriteLine("Digite a palavra:");
            var palavra = Console.ReadLine();

            var arvore = this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65];

            if(arvore.ConsultaPalavra(arvore.Raiz, palavra, false) is Nodo)
                Console.WriteLine("Palavra já adicionada");
            else
            {
                Console.WriteLine("Digite o significado:");
                var significado = Console.ReadLine();

                this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65].Raiz = arvore.Insere(arvore.Raiz, palavra, significado);

                this.Contador++;

                this.Salvar();
            }
        }

        public void RemovePalavra()
        {
            Console.WriteLine("Digite a palavra:");
            var palavra = Console.ReadLine();

            var arvore = this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65];


            if(arvore.Remove(arvore.Raiz, palavra) is Nodo novaArvoreRaiz)
            {
                this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65].Raiz = novaArvoreRaiz;
                this.Contador--;
            }
            else
                Console.WriteLine("Palavra não encontrada");

            this.Salvar();
        }

        public void EscreveAlfabetica()
        {
            foreach(var arvore in this.DicPalavras)
                arvore.EscreveOrdemAlfabetica(arvore.Raiz);

            this.Salvar();
        }

        public void EscreveAlfabeticaInversa()
        {
            for(int i = 25; i >= 0; i--)
            {
                var arvore = this.DicPalavras[i];
                arvore.EscreveOrdemAlfabeticaInversa(arvore.Raiz);
            }

            this.Salvar();
        }

        public void EscreveAlfabeticaSemSignificado()
        {
            foreach(var arvore in this.DicPalavras)
                arvore.EscreveSemSignificado(arvore.Raiz);

            this.Salvar();
        }

        public void EscrevePalavrasLetra()
        {
            Console.WriteLine("Digite a letra:");
            var palavra = Console.ReadLine();

            var arvore = this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65];

            arvore.EscreveOrdemAlfabetica(arvore.Raiz);
        }

        public void EscreveNumeroConsultasPalavra()
        {
            Console.WriteLine("Digite a palavra:");
            var palavra = Console.ReadLine();

            var arvore = this.DicPalavras[palavra.ToUpper().ToCharArray()[0] - 65];

            Console.WriteLine($"A palavra {palavra} teve {arvore.ConsultaPalavra(arvore.Raiz, palavra, false).Consultas} consultas");
        }

        public void Salvar()
            => File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "save.json"), JsonSerializer.Serialize(this, this.GetType()));
    }
}
