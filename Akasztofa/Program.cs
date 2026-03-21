Dictionary<string, List<string>> kategoriak = new Dictionary<string, List<string>>()
{
    { "gyumolcs", new List<string> { "alma", "korte", "banan", "szilva", "barack" } },
    { "allat", new List<string> { "kutya", "macska", "elefant", "oroszlan", "tigris" } },
    { "targy", new List<string> { "asztal", "szek", "telefon", "konyv", "auto" } }
};

Console.WriteLine("Valassz kategoriat:");
Console.WriteLine("1 - Gyumolcs");
Console.WriteLine("2 - Allat");
Console.WriteLine("3 - Targy");

string valasztas = Console.ReadLine();
string kategoria = "";

if (valasztas == "1")
    kategoria = "gyumolcs";
else if (valasztas == "2")
    kategoria = "allat";
else if (valasztas == "3")
    kategoria = "targy";
else
{
    Console.WriteLine("Hibas valasztas!");
    return;
}

Random rnd = new Random();
List<string> szavak = kategoriak[kategoria];
string szo = szavak[rnd.Next(szavak.Count)];

char[] talalat = new string('_', szo.Length).ToCharArray();
int eletek = 6;
List<string> probalkozasok = new List<string>();

Console.Clear();

while (eletek > 0)
{
    Console.Clear();
    Rajzol(eletek);

    Console.WriteLine("Szo: " + string.Join(" ", talalat));
    Console.WriteLine("Eletek: " + eletek);
    Console.WriteLine("Probalkozasok: " + string.Join(", ", probalkozasok));

    Console.Write("Adj meg egy betut vagy egy teljes szot: ");
    string input = Console.ReadLine().ToLower();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Nem adtal meg semmit!");
        Console.ReadKey();
        continue;
    }

    if (probalkozasok.Contains(input))
    {
        Console.WriteLine("Ezt mar probaltad!");
        Console.ReadKey();
        continue;
    }

    probalkozasok.Add(input);

    if (input.Length > 1)
    {
        if (input == szo)
        {
            Console.WriteLine("Gratulalok! Kitalaltad a szot: " + szo);
            return;
        }
        else
        {
            Console.WriteLine("Rossz szo! Azonnal meghaltal!");
            eletek = 0;
        }
    }
    else
    {
        char betu = input[0];
        bool talaltBetu = false;

        for (int i = 0; i < szo.Length; i++)
        {
            if (szo[i] == betu)
            {
                talalat[i] = betu;
                talaltBetu = true;
            }
        }

        if (!talaltBetu)
        {
            eletek--;
            Console.WriteLine("Rossz betu!");
        }
    }

    if (new string(talalat) == szo)
    {
        Console.Clear();
        Rajzol(eletek);
        Console.WriteLine("Gratulalok! Kitalaltad a szot: " + szo);
        return;
    }

}

Console.Clear();
Rajzol(eletek);
Console.WriteLine("GAME OVER!");
Console.WriteLine("A szo ez volt: " + szo);
    

static void Rajzol(int eletek)
{
Console.WriteLine(" +---+");
Console.WriteLine(" |   |");

if (eletek <= 5)
    Console.WriteLine(" O   |");
else
    Console.WriteLine("     |");

if (eletek == 4)
    Console.WriteLine(" |   |");
else if (eletek == 3)
    Console.WriteLine("/|   |");
else if (eletek <= 2)
    Console.WriteLine("/|\\  |");
else
    Console.WriteLine("     |");

if (eletek == 1)
    Console.WriteLine("/    |");
else if (eletek <= 0)
    Console.WriteLine("/ \\  |");
else
    Console.WriteLine("     |");

Console.WriteLine("     |");
Console.WriteLine("=========");
}