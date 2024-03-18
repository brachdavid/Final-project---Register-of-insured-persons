using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    class PojistenaOsoba
    {
        /// <summary>
        /// Křestní jméno pojištěné osoby
        /// </summary>
        public string Jmeno { get; private set; }

        /// <summary>
        /// Příjmení pojištěné osoby
        /// </summary>
        public string Prijmeni { get; private set; }

        /// <summary>
        /// Věk pojištěné osoby
        /// </summary>
        public int Vek { get; private set; }

        /// <summary>
        /// Telefonní číslo pojištěné osoby
        /// </summary>
        public string TelefonniCislo { get; private set; }

        /// <summary>
        /// Inicializace nové pojištěné osoby
        /// </summary>
        /// <param name="jmeno">Křestní jméno pojištěné osoby</param>
        /// <param name="prijmeni">Příjmení pojištěné osoby</param>
        /// <param name="vek">Věk pojištěné osoby</param>
        /// <param name="telefonniCislo">Telefonní číslo pojištěné osoby</param>
        public PojistenaOsoba(string jmeno, string prijmeni, int vek, string telefonniCislo)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefonniCislo = telefonniCislo;
        }

        /// <summary>
        /// Vrátí textovou reprezentaci pojištěné osoby
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Jméno a příjmení: {Jmeno} {Prijmeni}, věk: {Vek} let, telefonní číslo: {TelefonniCislo}";
        }
    }
}
