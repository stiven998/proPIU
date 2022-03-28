using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Farmacie
{
    class Gestionare:Medicament
    {
		public List<Medicament> medicamente = new List<Medicament>();
		public int nrMedicamente = 0;

		public Medicament[] med = new Medicament[50];

		public bool isEmpty()
		{
			if (nrMedicamente == 0)
				return true;
			else
				return false;
		}
		public bool isFull()
		{
			if (nrMedicamente == 100)
				return true;
			else
				return false;
		}


		public void adauga_produs_sir(string sir)
		{
			if (!isFull())
			{
				med[nrMedicamente] = new Medicament(sir);
				nrMedicamente++;
				Console.WriteLine("Produs adaugat cu succes!");
			}
			else
				Console.WriteLine("Baza de date este plina!");
		}

		public void adauga_produs()
		{
			int nr = 0;
			if (!isFull())
			{
				med[nrMedicamente] = new Medicament(nr);
				nrMedicamente++;
				Console.WriteLine("Produs adaugat cu succes!");
			}
			else
				Console.WriteLine("Baza de date este plina!");
		}


		public void sterge_produs(string denumire)
		{
			int k = -1, i;
			if (!isEmpty())
			{
				for (i = 0; i < nrMedicamente; i++)
				{
					if (String.Compare(denumire, med[i].nume) == 0)
					{
						k = i;
					}
					if (k != -1)
					{
						for (i = k; i < nrMedicamente; i++)
						{
							med[i] = med[i + 1];
						}
						nrMedicamente--;
					}
				}
				Console.WriteLine("Produs eliminat cu succes!");
			}
			else
				Console.WriteLine("Nu exista produse pentru eliminare!");
		}


		public int obtine_cod_produs(string den)
		{
			for (int i = 0; i < nrMedicamente; i++)
			{
				if (String.Compare(den, med[i].nume) == 0)
				{
					return med[i].cod;
				}
			}
			return -1;
		}
		public string obtine_denumire_produs(int _cod)
		{
			for (int i = 0; i < nrMedicamente; i++)
			{
				if (_cod == med[i].cod)
				{
					return med[i].nume;
				}
			}
			return String.Format("Produsul nu exista!");
		}

		public void set_pret_produs(string den, int _pret)
		{
			for (int i = 0; i < nrMedicamente; i++)
			{
				if (String.Compare(den, med[i].nume) == 0)
				{
					med[i].pret = _pret;
				}
			}
		}


		public string denumirea_produs(int _cod)
		{
			for (int a = 0; a < nrMedicamente; a++)
			{
				if (_cod == med[a].cod)
				{
					return med[a].nume;
				}
			}
			return String.Format("Produsul nu exista!");
		}




		public string cauta_produs_denumire(string den)
		{
			for (int i = 0; i < nrMedicamente; i++)
			{
				if (String.Compare(den, med[i].nume) == 0)
				{
					return med[i].afisare();
				}
			}
			return String.Format("Produsul nu exista in baza de date");
		}




		public string cauta_produs_cod(int _cod)
		{
			for (int i = 0; i < nrMedicamente; i++)
			{
				if (_cod == med[i].cod)
				{
					return med[i].afisare();
				}
			}
			return String.Format("Produsul nu exista in baza de date");
		}


		public void afisare_medicamente()
		{
			if (isEmpty()) Console.WriteLine("Nu aveti nici un produs in stoc!");

			for (int i = 0; i < nrMedicamente; i++)
			{
				Console.WriteLine(med[i].afisare() + "\n");
			}
		}





		public void citire_din_fisier()
		{
			using (StreamReader da = new StreamReader("E:\\PIUproiectGradinariStiven\\Farmacie\\Farmacie\\infoMedicamente.txt"))
			{
				string linie;
				while ((linie = da.ReadLine()) != string.Empty && linie != null)
				{
					if (!isFull())
					{
						med[nrMedicamente] = new Medicament(linie);
						nrMedicamente++;
					}
					else
						Console.WriteLine("Baza de date este plina!");
				}
			}
		}

		public void scriere_in_fisier()
		{
			using (StreamWriter da = new StreamWriter("E:\\PIUproiectGradinariStiven\\Farmacie\\Farmacie\\infoMedicamente.txt"))
			{
				for (int i = 0; i < nrMedicamente; i++)
				{
					da.WriteLine(med[i].afisare());
				}
			}
		}

	}
}
