abstract class Missa
{
    public int Id { get; set; }
    
    public string? Dia { get; set; }
    public string? Data { get; set; }
    public string? Horario { get; set; }
    public abstract int[] Acolitos { get; set; }
    public abstract int[] Coroinhas {get; set;}
}

class MissaSemana : Missa
{
    public override int[] Acolitos { get; set;}
    public override int[] Coroinhas { get; set;}

    public MissaSemana(int id, string dia, string data, string horario, int acolito, int[] coroinhas)
    {
        Id = id;
        Dia = dia;
        Data = data;
        Horario = horario;
        Acolitos = new int[] { acolito };
        Coroinhas = coroinhas;
    }
}

class MissaFimSemana : Missa
{
    public override int[] Acolitos { get; set;}
    public override int[] Coroinhas { get; set;}

    public MissaFimSemana(int id, string dia, string data, string horario, int[] acolitos, int[] coroinhas)
    {
        Id = id;
        Dia = dia;
        Data = data;
        Horario = horario;
        Acolitos = acolitos;
        Coroinhas = coroinhas;
    }
}

class Program
{
    static Dictionary<int, string> dias = new Dictionary<int, string>
    {
        { 1, "Segunda"},
        { 2, "Terça"},
        { 3, "Quarta" },
        { 4, "Quinta" },
        { 5, "Sexta" },
        { 6 , "Sábado" },
        { 7, "Domingo" }
    };

    static void Main()
    {
    }

}