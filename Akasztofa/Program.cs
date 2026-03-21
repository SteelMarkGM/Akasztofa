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

    if (probalkozasok.Contains(input))
    {
        Console.WriteLine("Ezt mar probaltad!");
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
            eletek--;
            Console.WriteLine("Rossz szo!");
        }
    }
    else
    {
        char betu = input[0];
        bool talalt = false;

        for (int i = 0; i < szo.Length; i++)
        {
            if (szo[i] == betu)
            {
                talalat[i] = betu;
                talalt = true;
            }
        }

        if (!talalt)
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

    Console.WriteLine("Nyomj meg egy gombot a folytatashoz...");
    Console.ReadKey();
}

Console.Clear();
Rajzol(eletek);
Console.WriteLine("GAME OVER!");
Console.WriteLine("A szo ez volt: " + szo);


void Rajzol(int eletek)
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
    
}