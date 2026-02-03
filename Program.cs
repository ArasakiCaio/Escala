
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

class Semana
{
    public int Id { get; set;}
    public MissaSemana[] missasDaSemana { get; set; } = new MissaSemana[5];
    public MissaFimSemana[] missasDoFimSemana { get; set; } = new MissaFimSemana[3];

    public Semana(Dictionary<int, string> dias)
    {
        int countID = 1;
        int count = 1;

        do
        {
            if(count < 6)
            {
                missasDaSemana[count-1] = new MissaSemana(countID, dias[count], "Data", "Horário", 1, new int[] { 1, 2, 3, 4, 5, 6 });
                countID++;
            }
            else if (count < 7)
            {
               missasDoFimSemana[0] = new MissaFimSemana(countID, dias[count], "Data", "Horário", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
               countID++;
               missasDoFimSemana[1] = new MissaFimSemana(countID, dias[count], "Data", "Horário", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 });
            }
            else
            {
               missasDoFimSemana[2] = new MissaFimSemana(countID, dias[count], "Data", "Horário", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
               countID++;
            }

            count++;
        }while(count < 8);

        PrintSemana(missasDaSemana, missasDoFimSemana);
    }

    public static void PrintSemana(MissaSemana[] sem, MissaFimSemana[] fimSem)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Id: {sem[i].Id}");
            Console.WriteLine($"Dia: {sem[i].Dia}");
            Console.WriteLine($"Data: {sem[i].Data}");
            Console.WriteLine($"Horário: {sem[i].Horario}");
            Console.WriteLine($"Acolito: {sem[i].Acolitos[0]}");
            Console.Write("Coroinhas: ");
            foreach (int cor in sem[i].Coroinhas)
            {
                Console.Write($"{cor} ");
            }
            Console.WriteLine("\n");
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Id: {fimSem[i].Id}");
            Console.WriteLine($"Dia: {fimSem[i].Dia}");
            Console.WriteLine($"Data: {fimSem[i].Data}");
            Console.WriteLine($"Horário: {fimSem[i].Horario}");
            Console.Write("Acolitos: ");
            foreach (int aco in fimSem[i].Acolitos)
            {
                Console.Write($"{aco} ");
            }
            Console.WriteLine("");

            Console.Write("Coroinhas: ");
            foreach (int cor in fimSem[i].Coroinhas)
            {
                Console.Write($"{cor} ");
            }
            Console.WriteLine("\n");
        }
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