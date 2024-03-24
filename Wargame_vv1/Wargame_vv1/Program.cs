using Wargame_vv1;

Tabellone tabellone = new Tabellone();

List<Squadra> squadre = new List<Squadra>()
{
    new Squadra(7, 4, Squadra.Colore.Rosso, tabellone),
    new Squadra(8, 4, Squadra.Colore.Rosso, tabellone),
    new Squadra(8, 5, Squadra.Colore.Rosso, tabellone),
    new Squadra(1, 1, Squadra.Colore.Blu, tabellone),
    new Squadra(2, 1, Squadra.Colore.Blu, tabellone),
    new Squadra(1, 2, Squadra.Colore.Blu, tabellone),
    new Squadra(1, 8, Squadra.Colore.Giallo, tabellone),
    new Squadra(2, 8, Squadra.Colore.Giallo, tabellone),
    new Squadra(1, 7, Squadra.Colore.Giallo, tabellone)
};

foreach (Squadra s in squadre)
    tabellone.PosizionaSquadra(s.Riga, s.Colonna, s);

int i = 0;
while (i < 15)
    if (Ostacolo.GeneraOstacoloCasuale(tabellone))
        i++;

tabellone.visualizza();

string richiesta = "idk";

while (richiesta != "")
{
    // si può migliorare tutto ma è solo una simulazione per testare
    int pos = 0;

    Console.WriteLine("\nrossa: [s1, s2, s3]");

    Console.WriteLine("scegli: ");
    string s = Console.ReadLine();

    if (s == "s1")
        pos = 0;
    else if (s == "s2")
        pos = 1;
    else if (s == "s3")
        pos = 2;
    else
        break;

    Console.WriteLine("x:");
    int x = int.Parse(Console.ReadLine());
    Console.WriteLine("y:");
    int y = int.Parse(Console.ReadLine());

    Console.WriteLine(squadre[pos].Riga.ToString() + squadre[pos].Colonna.ToString() + "\n");
    squadre[pos].Muovi(x, y);

    tabellone.visualizza();

    Console.WriteLine("vuoi uscire [premi invio]");
    richiesta = Console.ReadLine();
}