using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEstruturaDados.I.Dicionario
{
    public class Arvore
    {

        public Nodo Raiz { get; set; }

        public int Soma = 0;
        public int SomaPAlavras = 0;


        public Nodo Insere(Nodo nodo, string palavra, string significado)
        {
            if(nodo is null)
                nodo = new Nodo(palavra, significado);
            else if(string.Compare(palavra, nodo.Palavra, true) == -1)
                nodo.Esquerda = this.Insere(nodo.Esquerda, palavra, significado);
            else if(string.Compare(palavra, nodo.Palavra, true) == 1)
                nodo.Direita = this.Insere(nodo.Direita, palavra, significado);
            else
                return null;

            return nodo;
        }

        public void EscreveOrdemAlfabetica(Nodo nodo)
        {
            if(!(nodo is null))
            {
                this.EscreveOrdemAlfabetica(nodo.Esquerda);

                var sb = new StringBuilder();

                sb.AppendLine(nodo.Palavra);

                if(!string.IsNullOrEmpty(nodo.Significado))
                    sb.AppendLine($"Significado: {nodo.Significado}");

                Console.WriteLine(sb.ToString());

                this.EscreveOrdemAlfabetica(nodo.Direita);
            }
        }

        public void EscreveOrdemAlfabeticaInversa(Nodo nodo)
        {
            if(!(nodo is null))
            {
                this.EscreveOrdemAlfabeticaInversa(nodo.Direita);

                var sb = new StringBuilder();

                sb.AppendLine(nodo.Palavra);

                if(!string.IsNullOrEmpty(nodo.Significado))
                    sb.AppendLine($"Significado: {nodo.Significado}");

                Console.WriteLine(sb.ToString());

                this.EscreveOrdemAlfabeticaInversa(nodo.Esquerda);
            }
        }

        public Nodo Remove(Nodo nodo, string palavra)
        {
            if(nodo is null)
                return null;
            if(string.Compare(palavra, nodo.Palavra, true) == -1)
                nodo.Esquerda = Remove(nodo.Esquerda, palavra);
            else if(string.Compare(palavra, nodo.Palavra, true) == 1)
                nodo.Direita = Remove(nodo.Direita, palavra);
            else
            {
                if(nodo.Direita is null && nodo.Esquerda is null)
                    nodo = null;
                else if(nodo.Direita is null)
                    nodo = nodo.Esquerda;
                else if(nodo.Esquerda is null)
                    nodo = nodo.Direita;
                else if(!(nodo.Direita is null) && !(nodo.Esquerda is null))
                {
                    var aux = this.AchaMaior(nodo.Esquerda);
                    nodo.Palavra = aux.Palavra;
                    nodo.Significado = aux.Significado;
                    nodo.Direita = this.Remove(nodo.Direita, aux.Palavra);
                }
            }

            return nodo;
        }

        private Nodo AchaMaior(Nodo nodo)
        {
            var maior = nodo;
            var atual = nodo;

            while(atual is Nodo)
            {
                if(string.Compare(atual.Palavra, maior.Palavra, true) == 1)
                    maior = atual;

                atual = atual.Direita;
            }

            return maior;
        }

        public Nodo ConsultaPalavra(Nodo raiz, string nome, bool conta = true)
        {
            var atual = raiz;

            while(atual is Nodo)
            {
                if(string.Compare(atual.Palavra, nome, true) == 0)
                {
                    if(conta)
                    {
                        atual.Consultas++;
                        Soma++;
                    }

                    return atual;
                }
                else if(string.Compare(atual.Palavra, nome, true) == 1)
                    atual = atual.Esquerda;
                else
                    atual = atual.Direita;
            }

            return null;
        }

        public void EscreveSemSignificado(Nodo nodo)
        {
            if(!(nodo is null))
            {
                this.EscreveSemSignificado(nodo.Esquerda);

                if(string.IsNullOrEmpty(nodo.Significado))
                {
                    nodo.Consultas++;
                    Soma++;
                    Console.WriteLine(nodo.Palavra);
                }

                this.EscreveSemSignificado(nodo.Direita);
            }
        }
    }
}
