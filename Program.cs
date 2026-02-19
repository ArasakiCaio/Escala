using Semanas;
using Integrantes;
class Program
{

    static Dictionary<int, (string Mes, int Dias)> meses = new Dictionary<int, (string Mes, int Dias)>
    {
        { 1, ("Janeiro", 31)},
        { 2, ("Fevereiro", 28)},
        { 3, ("Março", 31) },
        { 4, ("Abril", 30) },
        { 5, ("Maio", 31) },
        { 6, ("Junho", 30) },
        { 7, ("Julho", 31) },
        { 8, ("Agosto", 31) } ,
        { 9, ("Setembro", 30) },
        { 10, ("Outubro", 31) },
        { 11, ("Novembro", 30) },
        { 12, ("Dezembro", 31) }
    };

    static Dictionary<int, string> dias = new Dictionary<int, string>
    {
        { 1, "Segunda"},
        { 2, "Terça"},
        { 3, "Quarta" },
        { 4, "Quinta" },
        { 5, "Sexta" },
        { 6, "Sábado" },
        { 7, "Domingo" }
    };

    public static int[] StringToIntArray(string[] input)
    {
        List<int> result = new List<int>();
        foreach (string str in input)
        {
            result.Add(Convert.ToInt32(str));
        }

        return result.ToArray();
    }

    public static void LerPlanilha(string File)
    {
        var data = new StreamReader(File);
        List<Integrante> Coroinhas = new List<Integrante>();
        List<Integrante> Acolitos = new List<Integrante>();

        data.ReadLine();

        while (!data.EndOfStream)
        {
            var line = data.ReadLine();
            if (line != null)
            {
                var values = line.Split(',');
                if(values[1] == "Coroinha")
                {
                    Coroinhas.Add(new Integrante(Convert.ToInt32(values[0]), values[2], Convert.ToBoolean(values[3]), StringToIntArray(values[4].Split(';')), StringToIntArray(values[5].Split(';')), new int[5], new int[3], new int[3]));
                }
                else if(values[1] == "Acolito")
                {
                    Acolitos.Add(new Integrante(Convert.ToInt32(values[0]), values[2], Convert.ToBoolean(values[3]), StringToIntArray(values[4].Split(';')), new int[1], StringToIntArray(values[5].Split(';')), new int[3], new int[3]));
                }
            }
        }

        foreach (var val in Coroinhas)
        {
            Console.WriteLine($"Coroinha - {val.Id}: {val.Nome}");
        }
        foreach (var val in Acolitos)
        {
            Console.WriteLine($"Acolito - {val.Id}: {val.Nome}");
        }
    }

    public static Semana[] CriarMes()
    {
        Semana[] Mes = new Semana[5];
        int numMes;
        int diaSemanaInicio;

        Console.WriteLine("Qual é o mês da escala que será gerada?");
        foreach(var aux in meses)
        {
            Console.WriteLine($"{aux.Key} - {aux.Value.Mes}");
        }

        Console.Write("Digite o número do mês: ");
        numMes = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nQual dia da semana o mês começa?");
        foreach(var aux in dias)
        {
            Console.WriteLine($"{aux.Key} - {aux.Value}");
        }

        Console.Write("Digite o número do dia da semana: ");
        diaSemanaInicio = Convert.ToInt32(Console.ReadLine());


        int semaDoMes = 0;
        int diaDoMes = 1;
        bool flag = true;

        while(diaDoMes <= meses[numMes].Dias)
        {
            if(diaSemanaInicio == 6 || diaSemanaInicio == 7)
            {
                if(diaSemanaInicio == 6)
                {
                    diaDoMes++;
                }
                diaDoMes++;

                diaSemanaInicio = 1;
            }

            Console.WriteLine($"\n{semaDoMes+1}a Semana do Mês");
            Mes[semaDoMes] = new Semana(dias, diaDoMes, numMes, meses[numMes].Dias, diaSemanaInicio, flag);
            semaDoMes++;
            
            if(flag)
            {
                diaDoMes += (7 - (diaSemanaInicio-1));
            }
            else
            {
                diaDoMes += 7;
            }
            flag = false;
        }

        return Mes;
    }

    static void Main()
    {
        // Semana[] Mes = CriarMes();
        // LerPlanilha("Data.csv");
    }
}