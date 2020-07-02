namespace AlgoritmosEstruturaDados.I.Dicionario
{
    public class Nodo
    {
        public Nodo() { }

        public Nodo(string palavra, string significado = null)
        {
            this.Palavra = palavra;
            this.Significado = significado ?? string.Empty;
            this.Consultas = 0;
        }

        public string Palavra { get; set; }

        public string Significado { get; set; }

        public int Consultas { get; set; }

        public Nodo Esquerda { get; set; }

        public Nodo Direita { get; set; }
    }
}
