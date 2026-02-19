using Integrantes;

namespace PlanilhaFunctions
{
    public static class Planilha
    {
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

        public static int[] StringToIntArray(string[] input)
        {
            List<int> result = new List<int>();
            foreach (string str in input)
            {
                result.Add(Convert.ToInt32(str));
            }

            return result.ToArray();
        }
    }
}