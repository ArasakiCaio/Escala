using Missas;

namespace Semanas
{
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
}