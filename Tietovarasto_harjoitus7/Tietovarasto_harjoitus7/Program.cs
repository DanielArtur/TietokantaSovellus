using System;
using System.Diagnostics.Metrics;
using Tietovarasto_harjoitus7;



Console.WriteLine("Options:\n1.AddItem\n2.DeleteItem\n3.ShowItemCount\n4.AlterItemName\n5.ShowItemList\n6.Exit application");
Console.WriteLine("\nEnter number");
int input = Convert.ToInt32(Console.ReadLine());


switch (input)
{
    case 1:
        Additem();
        break;
    case 2:
        DeleteItem();
        break;
    case 3:
        ShowItemCount();
        break;
    case 4:
        AlterItemName();
        break;
    case 5:
        ShowItemList();
        break;
    case 6:
        Exit();
        break;


}

void Exit()
{
    Environment.Exit(0);
}

void AlterItemName()
{
    using (Varastonhallinta varastonhallinta = new())
    {
        Console.WriteLine("Syötä tuotenumero/id:");
        String tuoteID = Console.ReadLine();

        Tuote tuote = varastonhallinta.Tuotteet.Find(tuoteID);

        if (tuote is null)
        {
            Console.WriteLine("Kyseistä tuotetta ei löydy.");
            return;


        }
        else
        {
            Console.WriteLine("Syötä uusi nimi");
            string uusiNimi = Console.ReadLine();

            tuote.Tuotenimi = uusiNimi;
            int affected = varastonhallinta.SaveChanges();

            Console.WriteLine("Nimi muutettu.");

        }



    }
}

void ShowItemCount()
{
    using (Varastonhallinta varastonhallinta = new())
    {

        Console.WriteLine("Syötä tuotenumero/id:");
        String tuoteID = Console.ReadLine();

        Tuote tuote = varastonhallinta.Tuotteet.Find(tuoteID);

        if (tuote is null)
            Console.WriteLine("Kyseistä tuotetta ei löydy!");
        else
            Console.WriteLine("Tuotteen " + tuote.Tuotenimi + " varastosaldo on: " + tuote.Varastosaldo);



    }
}

static void DeleteItem()
{

    using (Varastonhallinta varastonhallinta = new())
    {

        Console.WriteLine("Syötä tuotenumero/id:");
        String tuoteID = Console.ReadLine();

        Tuote tuote = varastonhallinta.Tuotteet.Find(tuoteID);

        if (tuote is null)
        {
            Console.WriteLine("Kyseistä tuotetta ei löydy!");


        }
        else
        {
            varastonhallinta.Remove(tuote);
            int affected = varastonhallinta.SaveChanges();
            Console.WriteLine(tuote.Tuotenimi + " on poistettu.");


        }


    }
}

static void Additem()
{
    using (Varastonhallinta varastonhallinta = new())
    {

        Console.WriteLine("Syotä tuotenimi...");
        String name = Console.ReadLine();

        Console.WriteLine("Syotä tuotehinta...");
        String hinta = Console.ReadLine();

        Console.WriteLine("Syotä varastosaldo...");
        String saldo = Console.ReadLine();

        Console.WriteLine("Syotä tuoteID...");
        String tuoteID = Console.ReadLine();

        Tuote tuote = new();
        {

            tuote.Id = tuoteID;
            tuote.Tuotenimi = name;
            tuote.Tuotehinta = hinta;
            tuote.Varastosaldo = saldo;
        }

        varastonhallinta.Tuotteet?.Add(tuote);

        int affected = varastonhallinta.SaveChanges();
        Console.WriteLine("Tuote lisätty tieotnakntaan. " + affected + " Muutosta.");


    }
}

static int GetRowCount()
{
    int rowCount = 0;

    using (Varastonhallinta varastonhallinta = new())

    {
        IQueryable<Tuote>? tuotteet = varastonhallinta.Tuotteet;

        foreach (Tuote tuote in tuotteet)
        {

            rowCount++;

        }

        return rowCount;
    }


}

static void ShowItemList()
{

    using (Varastonhallinta varastonhallinta = new())
    {

        Console.WriteLine("Kaikki Tuotteet:");

        IQueryable<Tuote>? tuotteet = varastonhallinta.Tuotteet;

        if (tuotteet is null)
        {
            Console.WriteLine("Varasto on tyhjä.");
            return;


        }
        foreach (Tuote tuote in tuotteet)
        {
            Console.WriteLine(tuote.Tuotenimi + " [" + tuote.Id + "]");
            

        }

    }




}