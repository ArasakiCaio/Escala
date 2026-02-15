
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

    public Semana(Dictionary<int, string> dias, int inicioSemana, int mes, int diasMes, int diaSemanaInicio, bool semana1)
    {
        int countID = 1;
        int count;
        int dateCount;

        if(semana1)
        {
            count = diaSemanaInicio;
        }
        else
        {
            count = 1;
        }

        dateCount = 0;

        do
        {
            if(count < 6)
            {
                if(count != 5)
                {
                    missasDaSemana[count-1] = new MissaSemana(countID, dias[count], ConvertDateToString(inicioSemana + dateCount, mes), "19:00", 1, new int[] { 1, 2, 3, 4, 5, 6 });
                }
                else
                {
                    missasDaSemana[count-1] = new MissaSemana(countID, dias[count], ConvertDateToString(inicioSemana + dateCount, mes), "15:00", 1, new int[] { 1, 2, 3, 4, 5, 6 });
                }
                
                countID++;
            }
            else if (count < 7)
            {
                missasDoFimSemana[0] = new MissaFimSemana(countID, dias[count], ConvertDateToString(inicioSemana + dateCount, mes), "19:00", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
                countID++;
            }
            else
            {
                missasDoFimSemana[1] = new MissaFimSemana(countID, dias[count], ConvertDateToString(inicioSemana + dateCount, mes), "09:30", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 });
                countID++;
                missasDoFimSemana[2] = new MissaFimSemana(countID, dias[count], ConvertDateToString(inicioSemana + dateCount, mes), "19:00", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
                countID++;
            }

            count++;
            dateCount++;
        }while( (count < 8) && ((inicioSemana + (count-1)) <= diasMes) );

        if(((inicioSemana + (count-1)) > diasMes) && count > 5)
        {
            int diaUltimoFimSemana = 1;
            if(count == 6)
            {
                missasDoFimSemana[0] = new MissaFimSemana(countID, dias[count], ConvertDateToString(diaUltimoFimSemana, mes+1), "19:00", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
                diaUltimoFimSemana++;
                countID++;
                count++;
            }

            missasDoFimSemana[1] = new MissaFimSemana(countID, dias[count], ConvertDateToString(diaUltimoFimSemana, mes+1), "09:30", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 });
            countID++;
            missasDoFimSemana[2] = new MissaFimSemana(countID, dias[count], ConvertDateToString(diaUltimoFimSemana, mes+1), "19:00", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }); 
        }

        PrintSemana(missasDaSemana, missasDoFimSemana);
    }

    public static string ConvertDateToString(int dia, int mes)
    {
        string dateString = "";
        
        string Dia = dia.ToString();
        string Mes = mes.ToString();

        if(dia < 10)
        {
            Dia = $"0{Dia}";
        }

        if (mes < 10)
        {
            dateString = $"{Dia}/0{Mes}"; 
        }
        else
        {
            dateString = $"{Dia}/{Mes}"; 
        }

        return dateString;
    }

    public static void PrintSemana(MissaSemana[] sem, MissaFimSemana[] fimSem)
    {

        foreach(MissaSemana item in sem)
        {
            if(item != null)
            {
                Console.WriteLine($"Semana Id: {item.Id}");
                Console.WriteLine($"Dia: {item.Dia}");
                Console.WriteLine($"Data: {item.Data}");
                Console.WriteLine($"Horário: {item.Horario}");
                Console.WriteLine($"Acolito: {item.Acolitos[0]}");
                Console.Write("Coroinhas: ");
                foreach (int cor in item.Coroinhas)
                {
                    Console.Write($"{cor} ");
                }
                Console.WriteLine("\n");
            }
        }

        foreach(MissaFimSemana item in fimSem)
        {
            if(item != null)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Dia: {item.Dia}");
                Console.WriteLine($"Data: {item.Data}");
                Console.WriteLine($"Horário: {item.Horario}");
                Console.Write("Acolitos: ");
                foreach (int aco in item.Acolitos)
                {
                    Console.Write($"{aco} ");
                }
                Console.WriteLine("");

                Console.Write("Coroinhas: ");
                foreach (int cor in item.Coroinhas)
                {
                    Console.Write($"{cor} ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}

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
        Semana[] Mes = CriarMes();
    }
}