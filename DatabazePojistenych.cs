using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    class DatabazePojistenych
    {
        /// <summary>
        /// Kolekce pojištěných osob
        /// </summary>
        private List<PojistenaOsoba> kolekcePojistenych;

        /// <summary>
        /// Vrací hodnotu "true" pokud je kolekce pojistěných prázdná
        /// </summary>
        /// <returns></returns>
        public bool JeSeznamPrazdny()
        {
            return kolekcePojistenych.Count == 0;
        }

        /// <summary>
        /// Vytvoří novou instanci databáze pojistěných osob
        /// </summary>
        public DatabazePojistenych()
        {
            kolekcePojistenych = new List<PojistenaOsoba>();
        }

        /// <summary>
        /// Přidání záznamu do Databáze pojištěných
        /// </summary>
        /// <param name="jmeno">Křestní jméno pojištěného</param>
        /// <param name="prijmeni">Příjmení pojištěného</param>
        /// <param name="vek">Věk pojištěného</param>
        /// <param name="telefonniCislo">Telefonní číslo pojištěného</param>
        public void PridejPojisteneho(string jmeno, string prijmeni, int vek, string telefonniCislo)
        {
            kolekcePojistenych.Add(new PojistenaOsoba(jmeno, prijmeni, vek, telefonniCislo));
        }

        /// <summary>
        /// Najde pojištěnou osobu (pokud existuje) na základě dvou konkrétních kritérií
        /// </summary>
        /// <param name="jmeno">Křestní jméno potenciálního pojištěného</param>
        /// <param name="prijmeni">Příjmení potenciálního pojištěného</param>
        /// <returns></returns>
        public List<PojistenaOsoba> NajdiPojisteneho(string jmeno, string prijmeni)
        {
            List<PojistenaOsoba> nalezeneOsoby = new List<PojistenaOsoba>();
            foreach (PojistenaOsoba p in kolekcePojistenych)
            {
                if ((p.Prijmeni == prijmeni) && (p.Jmeno == jmeno))
                    nalezeneOsoby.Add(p);
            }
            return nalezeneOsoby;
        }

        /// <summary>
        /// Vypíše všechny pojištěné osoby z databáze
        /// </summary>
        public void VypisPojistene()
        {
            foreach (PojistenaOsoba p in kolekcePojistenych)
                Console.WriteLine(p);
        }
    }
}
