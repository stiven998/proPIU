using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Farmacie
{
    class Medicament
    {
        public string nume { set; get; }
        public string producator { set; get; }
        public int pret { set; get; }
        public int cod { set; get; }
        public int stoc { set; get; }
        public NaturaMedicament naturaMedicament { set; get; }
        public Eliberare modEliberare { set; get; }
        public DateTime dataActualizare = new DateTime();

        public Medicament()
        {
            nume = null;
            producator= null;
            pret = 0;
            cod = 0;
            stoc = 0;
        }

        public Medicament(string info)
        {
            string[] sir = info.Split(',');
            nume = sir[0];
            producator = sir[1];
            naturaMedicament = (NaturaMedicament)Enum.Parse(typeof(NaturaMedicament), sir[2]);
            pret = int.Parse(sir[4]);
            cod = int.Parse(sir[3]);   
            stoc = int.Parse(sir[5]);
            modEliberare = (Eliberare)Enum.Parse(typeof(Eliberare), sir[6]);

        }

        public Medicament(string den, string _producator, string _naturaMedicament, int _pret, int _cod, int _stoc, string _modEliberat)
        {
            nume = den;
            producator = _producator;
            naturaMedicament = (NaturaMedicament)Enum.Parse(typeof(NaturaMedicament), _naturaMedicament);
            pret = _pret;
            cod = _cod;
            stoc = _stoc;
            modEliberare = (Eliberare)Enum.Parse(typeof(Eliberare), _modEliberat);
        }

        public string afisare()
        {
            Console.WriteLine("Denumire     Producator     NaturaMed     Cod     Pret     Stoc     ModEliberare");
            return string.Format(""+nume+"  "+producator+"        "+naturaMedicament+"    "+cod+"    "+pret+"       "+stoc+"        "+modEliberare);
            //return string.Format("{0,-5}{1,-20}{2,-15}{3,-10}{4,-10}{5,-10}{6,-10}", nume, producator, naturaMedicament, cod, pret, stoc, modEliberare);
        }
        public void AdaugaMedicament()
        {
            try
            {
                using (StreamWriter scrieInFisier = new StreamWriter("medicamente.txt"))
                {

                    scrieInFisier.WriteLine(String.Format(nume.PadRight(10) + "," + producator.PadRight(10) + "," + Convert.ToString(naturaMedicament) + "," + cod + "," + pret + "," + stoc + "," + modEliberare.ToString()));
                }
            }
            catch (IOException E)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + E.Message);
            }
            catch (Exception GenericEx)
            {
                throw new Exception("Eroare generica. Mesaj: " + GenericEx.Message);
            }
            
        }


        public Medicament(int nr)
        {
            Console.Write("Denumire produs: ");
            nume = Console.ReadLine();

            Console.Write("Producator produs: ");
            producator = Console.ReadLine();

            Console.Write("Pret: ");
            pret = Int32.Parse(Console.ReadLine());

            Console.Write("Codul produsului: ");
            cod = Int32.Parse(Console.ReadLine());

            Console.Write("Stocul produsului= ");
            stoc = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Forma produsului:\n1. Comprimate\n2. Sirop\n3. Unguent");
            naturaMedicament = (NaturaMedicament)Enum.Parse(typeof(NaturaMedicament), Console.ReadLine());

            Console.WriteLine("Predare cu:\n1.Reteta\n2.Fara_reteta");
            modEliberare = (Eliberare)Enum.Parse(typeof(Eliberare), Console.ReadLine());
        }
    }
}
