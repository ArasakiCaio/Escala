using Semanas;

namespace Integrantes
{
    class Integrante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public bool? isNovo { get; set; }
        public int[]? SemaDisponibilidade { get; set; }
        public int[]? FimSemaDisponibilidade { get; set; }
        public int[]? Irmaos { get; set; }
        public int[]? SemaEscalado { get; set; }
        public int[]? FimSemaEscalado { get; set; }
        public int[]? QuantEscalado { get; set; }
    

        public Integrante(int id, string nome, bool isnovo, int[] semaDispo, int[] fimSemaDispo, int[] irmaos, int[] semaEscalado, int[] fimSemaEscalado, int[] quantEscalado)
        {
            Id = id;
            Nome = nome;
            isNovo = isnovo;
            SemaDisponibilidade = semaDispo;
            FimSemaDisponibilidade = fimSemaDispo;
            Irmaos = irmaos;
            SemaEscalado = semaEscalado;
            FimSemaEscalado = fimSemaEscalado;
            QuantEscalado = quantEscalado;
        }
    }
}