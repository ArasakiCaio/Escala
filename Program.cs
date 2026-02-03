var dias = new Dictionary<int, string>
{
    { 1, "Segunda"},
    { 2, "Terça"},
    { 3, "Quarta" },
    { 4, "Quinta" },
    { 5, "Sexta" },
    { 6 , "Sábado" },
    { 7, "Domingo" }
};

for (int i = 1; i<8; i++)
{
    Console.WriteLine($"{dias[i]}");
}