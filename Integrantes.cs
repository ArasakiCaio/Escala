using Semanas;

namespace Integrantes
{
    class Integrante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public bool? isNovo { get; set; }
        public int[]? Disponibilidade { get; set; }
        public int[]? Irmaos { get; set; }
        public int[]? SemaEscalado { get; set; }
        public int[]? FimSemaEscalado { get; set; }
        public int[]? QuantEscalado { get; set; }
    

        public Integrante(int id, string nome, bool isnovo, int[] disponibilidade, int[] irmaos, int[] semaEscalado, int[] fimSemaEscalado, int[] quantEscalado)
        {
            Id = id;
            Nome = nome;
            isNovo = isnovo;
            Disponibilidade = disponibilidade;
            Irmaos = irmaos;
            SemaEscalado = semaEscalado;
            FimSemaEscalado = fimSemaEscalado;
            QuantEscalado = quantEscalado;
        }
    }
}