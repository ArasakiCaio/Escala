using Semanas;
using PlanilhaFunctions;
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
        // Semana[] Mes = CriarMes();
        Planilha.LerPlanilha("Data.csv");
    }
}