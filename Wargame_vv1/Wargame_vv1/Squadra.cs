using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
{
    public class Squadra
    {
        public enum Colore
        {
            Rosso,
            Blu,
            Giallo
        }

        private List<Personaggio> squad = new List<Personaggio>();

        private Tabellone tabellone;
        private int riga;
        private int colonna;
        private Colore colore;
        private bool modCombattimento;  // TODO: come funziona... ?
        private bool viva;  // TODO: da rivedere

        public List<Personaggio> Squad
        {
            get { return squad; }
            set { squad = value; }
        }

        public bool ModCombattimento
        {
            get { return modCombattimento; }
            set { modCombattimento = value; }
        }

        public int Riga
        {
            get { return riga; }
            set { riga = value; }
        }

        public int Colonna
        {
            get { return colonna; }
            set { colonna = value; }
        }

        public Squadra(int r, int c, Colore co, Tabellone t)
        {
            CreaSquadra();

            Riga = r;
            Colonna = c;
            colore = co;
            tabellone = t;
            ModCombattimento = false;
            viva = true;
        }

        public void CreaSquadra()
        {
            Squad.Add(new Arciere());
            Squad.Add(new Cavaliere());
            Squad.Add(new Mago());
            Squad.Add(new Guerriero());
        }
        public void Muovi(int newRiga, int newColonna)
        {
            if (newRiga < 0 || newRiga > tabellone.Dimensione - 1)
                throw new ArgumentException("posizione non valida");
            if (newColonna < 0 || newColonna > tabellone.Dimensione - 1)
                throw new ArgumentException("posizione non valida");

            int diffRiga = Math.Abs(newRiga - riga);
            int diffColonna = Math.Abs(newColonna - colonna);

            if (!(diffRiga <= 1 && diffColonna <= 1))
                throw new ArgumentException("mossa non valida per la squadra");

            Ostacolo o = tabellone.GetOstacolo(newRiga, newColonna);
            if (o != null)
                throw new ArgumentException("ostacolo in mezzo");

            Squadra s = tabellone.GetSquadra(newRiga, newColonna);
            if (s != null && s.colore == colore)
                throw new ArgumentException("casella occupata da una tua squadra");

            if (InvadiSquadra(newRiga, newColonna))
                modCombattimento = true;

            tabellone.RimuoviSquadra(riga, colonna);

            riga = newRiga;
            colonna = newColonna;
            tabellone.PosizionaSquadra(riga, colonna, this);
        }

        public void Cura(int punti)
        {
            foreach (Personaggio p in Squad)
                p.PuntiVita += punti;
        }

        public bool InvadiSquadra(int riga, int colonna)
        {
            Squadra s = tabellone.GetSquadra(riga, colonna);
            if (s != null && s.colore != colore)
                return true;
            return false;
        }

        public string Stampa()
        {
            if (colore == Colore.Rosso)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (colore == Colore.Blu)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;
            return "S ";
        }
    }
}