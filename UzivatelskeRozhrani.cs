using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencePojistenych
{
    class UzivatelskeRozhrani
    {
        /// <summary>
        /// Databáze pojištěných osob s příslušnými záznamy
        /// </summary>
        private DatabazePojistenych databazePojistenych;

        /// <summary>
        /// Vytvoří novou instanci uživatelského rozhraní
        /// </summary>
        public UzivatelskeRozhrani()
        {
            databazePojistenych = new DatabazePojistenych();
        }

        /// <summary>
        /// Metoda spustí celý náš program
        /// </summary>
        public void SpustProgram()
        {
            char volba = '0';
            while (volba != '4')
            {
                VypisMenu();
                volba = Console.ReadKey().KeyChar;
                Console.WriteLine();
                ZpracujVolbu(volba);
            }
        }

        /// <summary>
        /// Metoda vypíše hlavičku aplikace
        /// </summary>
        private void VypisMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------------\nEvidence pojištěných\n------------------------------");
            Console.WriteLine();
            Console.WriteLine("Vyberte si akci:");
            Console.WriteLine("1 - Přidat nového pojištěného");
            Console.WriteLine("2 - Vypsat všechny pojištěné");
            Console.WriteLine("3 - Vyhledat pojištěného");
            Console.WriteLine("4 - Konec");
        }
        /// <summary>
        /// Metoda zpracuje volbu uživatele
        /// </summary>
        /// <param name="volba">Číslo operace vybrané uživatelem</param>
        private void ZpracujVolbu(char volba)
        {
            switch (volba)
            {
                case '1':
                    VytvorPojisteneho();
                    VypisHlasku();
                    break;
                case '2':
                    VypisPojistene();
                    VypisHlasku();
                    break;
                case '3':
                    VyhledejPojisteneho();
                    VypisHlasku();
                    break;
                case '4':
                    Console.WriteLine("Libovolnou klávesou ukončíte program...");
                    break;
                default:
                    Console.WriteLine("Neplatná volba, stiskněte libovolnou klávesu a opakujte volbu.");
                    break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Metoda vyzve uživatele k přidání nového pojištěného, kterého následně uloží do databáze
        /// </summary>
        private void VytvorPojisteneho()
        {
            string jmeno = ZjistiJmeno();
            string prijmeni = ZjistiPrijmeni();
            int vek = ZjistiVek();
            string telefonniCislo = ZjistiTelefonniCislo();

            databazePojistenych.PridejPojisteneho(jmeno, prijmeni, vek, telefonniCislo);
        }

        /// <summary>
        /// Metoda vrací zvalidovanou stringovou hodnotu, která nesmí obsahovat číslice ani speciální znaky. Zároveň musí dodržet podmínku velkého písmena na začátku slova. Také odstraňuje přebytečné mezery.
        /// </summary>
        /// <param name="uzivatelskyVstup">Uživatelský vstup</param>
        /// <returns></returns>
        private string VratZvalidovanyText(string uzivatelskyVstup)
        {
            while (string.IsNullOrWhiteSpace(uzivatelskyVstup = Console.ReadLine()?.Trim() ?? "") || !JePrvniPismenoVelke(uzivatelskyVstup) || ObsahujeCisliceNeboSpecialniZnaky(uzivatelskyVstup))
            {
                Console.WriteLine("Ajajaj, někde se stala chyba! Hodnota (pokud byla zadána) musí začínat velkým písmenem, zároveň nesmí obsahovat číslice ani speciální znaky.");
            }
            return uzivatelskyVstup;
        }

        /// <summary>
        /// Metoda ověří, jestli uživatelský vstup začíná velkým písmenem.
        /// </summary>
        /// <param name="uzivatelskyVstup">Hodnota zadaná uživatelem</param>
        /// <returns></returns>
        private bool JePrvniPismenoVelke(string uzivatelskyVstup)
        {
            // Kontrola, zda je první znak velkým písmenem
            return char.IsUpper(uzivatelskyVstup[0]);
        }

        /// <summary>
        /// Metoda zjistí, jestli uživatelský vstup obsahuje nežádoucí číslovky či speciální znaky
        /// </summary>
        /// <param name="uzivatelskyVstup">Hodnota zadaná uživatelem</param>
        /// <returns></returns>
        private bool ObsahujeCisliceNeboSpecialniZnaky(string uzivatelskyVstup)
        {
            // Kontrola, zda text obsahuje číslice nebo speciální znaky
            foreach (char znak in uzivatelskyVstup)
            {
                if (char.IsDigit(znak) || char.IsSymbol(znak) || char.IsPunctuation(znak))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Metoda vrací zvalidovanou číselnou hodnotu
        /// </summary>
        /// <param name="uzivatelskyVstup">Hodnota zadaná uživatelem</param>
        /// <returns></returns>
        private int VratZvalidovanyVek(int uzivatelskyVstup)
        {
            while (!int.TryParse(Console.ReadLine(), out uzivatelskyVstup) || (uzivatelskyVstup <= 0))
            {
                VypisChybovouHlasku();
            }
            return uzivatelskyVstup;
        }

        /// <summary>
        /// Metoda vrací zvalidované telefonní číslo ve formátu +420 xxx xxx xxx
        /// </summary>
        /// <param name="uzivatelskyVstup">Hodnota zadaná uživatelem</param>
        /// <returns></returns>
        private string VratZvalidovaneCislo(string uzivatelskyVstup)
        {
            bool validniFormat = false;

            while (!validniFormat)
            {
                uzivatelskyVstup = Console.ReadLine() ?? "";
                // Použití regulárního výrazu k ověření formátu telefonního čísla
                if (Regex.IsMatch(uzivatelskyVstup, @"^\+420 \d{3} \d{3} \d{3}$"))
                {
                    validniFormat = true;
                }
                else
                {
                    VypisChybovouHlasku();
                }
            }
            return uzivatelskyVstup;
        }

        /// <summary>
        /// Metoda vypíše univerzální chybovou hlášku
        /// </summary>
        private void VypisChybovouHlasku()
        {
            Console.WriteLine("Ajajaj, něco se pokazilo. Zkuste to znovu a tentokrát se, prosím, držte zadání:");
        }

        /// <summary>
        /// Metoda vyzve uživatele k zadání křestního jména pojištěného
        /// </summary>
        /// <returns>Křestní jméno</returns>
        private string ZjistiJmeno()
        {
            Console.WriteLine("\nZadejte křestní jméno pojištěného:");
            string jmeno = "";
            return VratZvalidovanyText(jmeno);
        }

        /// <summary>
        /// Metoda vyzve uživatele k zadání příjmení pojištěného
        /// </summary>
        /// <returns>Příjmení</returns>
        private string ZjistiPrijmeni()
        {
            Console.WriteLine("Zadejte příjmení pojištěného:");
            string prijmeni = "";
            return VratZvalidovanyText(prijmeni);
        }
        /// <summary>
        /// Metoda vyzve uživatele k zadání věku pojištěného
        /// </summary>
        /// <returns>Věk</returns>
        private int ZjistiVek()
        {
            Console.WriteLine("Zadejte věk pojištěného (pouze číslovku):");
            int vek = 0;
            return VratZvalidovanyVek(vek);
        }

        /// <summary>
        /// Metoda vyzve uživatele k zadání telefonního čísla pojištěného
        /// </summary>
        /// <returns></returns>
        private string ZjistiTelefonniCislo()
        {
            Console.WriteLine("Zadejte telefonní číslo pojištěného (ve tvaru +420 xxx xxx xxx):");
            string telefonniCislo = "";
            return VratZvalidovaneCislo(telefonniCislo);
        }

        /// <summary>
        /// Vypíše do konzole všechny pojištěné osoby z databáze
        /// </summary>
        private void VypisPojistene()
        {
            if (databazePojistenych.JeSeznamPrazdny())
                Console.WriteLine("\nDatabáze pojištěných je zatím prázdná.");
            else
            {
                Console.WriteLine("\nTohle je seznam všech pojištěných:\n");
                databazePojistenych.VypisPojistene();
            }

        }

        /// <summary>
        /// Vyhledá pojištěnou osobu na základě údajů zadaných uživatelem
        /// </summary>
        private void VyhledejPojisteneho()
        {
            string jmeno = ZjistiJmeno();
            string prijmeni = ZjistiPrijmeni();
            List<PojistenaOsoba> odpovidajiciSeznamPojistenych = databazePojistenych.NajdiPojisteneho(jmeno, prijmeni);
            // Vypíše seznam pojištěných osob na základě uživatelského zadání
            if (odpovidajiciSeznamPojistenych.Count() > 0)
            {
                Console.WriteLine("\nVašemu zadání odpovídají následující výsledky:\n");
                foreach (PojistenaOsoba p in odpovidajiciSeznamPojistenych)
                    Console.WriteLine(p);
            }
            else
                // Pokud žádný záznam v databázi pojištěných osob neodpovídá uživatelskému zadání
                Console.WriteLine("\nNebyly nalezeny žádné osoby, které by odpovídaly vašemu zadání.");
        }

        /// <summary>
        /// Metoda vypíše hlášku, která uživatele nasměruje zpátky na začátek
        /// </summary>
        private void VypisHlasku()
        {
            Console.WriteLine("\nPro návrat do hlavního menu stiskněte libovolnou klávesu");
        }
    }
}
