using System;

namespace Farmacie
{
    class Program
    {

        static void Main(string[] args)
        {
            Gestionare gest = new Gestionare();
            string meniu, alege;
            do
            {
                Console.Clear();
                Console.WriteLine("\n***************FARMACIE***************\n------------------------------------------");
                Console.WriteLine(" a/A. Adaugare medicamente (tastatura)\n");
                Console.WriteLine(" b/B. Adaugare medicament (primit ca sir)\n");
                Console.WriteLine(" c/C. Citire date din fisier\n");
                Console.WriteLine(" d/D. Salvare date in fisier\n");
                Console.WriteLine(" e/E. Afisare medicamente\n");
                Console.WriteLine(" f/F. Eliminare medicament\n");
                Console.WriteLine(" g/G. Obtine cod produs(necesar denumire)\n");
                Console.WriteLine(" h/H. Obtine denumire produs(necesar cod)\n");
                Console.WriteLine(" i/I. Info Farmacie\n");
                Console.WriteLine(" x/X. Iesire\n");
                Console.WriteLine(" l/L. Comparare doua produse\n");

                Console.Write("Alegeti o optiune din MENIU: ");
                meniu = Console.ReadLine();
                switch (meniu)
                {
                    case "a":
                    case "A":
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Adaugati produs nou? (DA/NU): ");
                            alege = Console.ReadLine();
                            if (alege.ToUpper() == "DA")
                                gest.adauga_produs();
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "i":
                    case "I":
                        Console.WriteLine(" Farmacia BIOMEDICA, strada Universitatii, Suceava");
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;


                    case "x":
                    case "X":
                        System.Environment.Exit(0);
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;


                    case "b":
                    case "B":
                        gest.adauga_produs_sir("Amoxacilina,Calvita,0,2222,10,2,1");
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        gest.citire_din_fisier();
                        Console.WriteLine("Date citite cu succes!");
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        gest.scriere_in_fisier();
                        Console.WriteLine("Date salvate cu succes!");
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "e":
                    case "E":
                        Console.Clear();
                        gest.afisare_medicamente();
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "f":
                    case "F":
                        Console.Clear();
                        Console.Write("Introduceti denumirea produsului pentru eliminare: ");
                        string med = Console.ReadLine();
                        gest.sterge_produs(med);
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    case "g":
                    case "G":
                        Console.Clear();
                        Console.Write("Introduceti denumirea produsului: ");
                        string den = Console.ReadLine();
                        Console.WriteLine("Codul asociat produsului introdus este: " + gest.obtine_cod_produs(den));
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;


                    case "h":
                    case "H":
                        Console.Clear();
                        Console.Write("Introduceti codul produsului: ");
                        int x = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Denumirea asociata codului introdus este: " + gest.denumirea_produs(x));
                        Console.WriteLine("\nApasa orice pentru o noua alegere...");
                        Console.ReadKey();
                        break;

                    

                }

            } while (true);
        }

    }
}
