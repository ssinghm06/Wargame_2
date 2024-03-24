using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
{
    public class Tabellone
    {
        private Squadra[,] tabellone;
        private Ostacolo[,] ostacoli;
        private int dimensione;  // sarà sempre una struttura quadrata (altezza e lunghezza coincidono)

        public int Dimensione
        {
            get { return dimensione; }
            set { dimensione = value; }
        }
        
        public Tabellone()
        {
            Dimensione = 10;
            tabellone = new Squadra[Dimensione, Dimensione];
            ostacoli = new Ostacolo[Dimensione, Dimensione];
        }

        public void PosizionaSquadra(int r, int c, Squadra s)
        {
            ControllaCoordinate(r, c);
            tabellone[r, c] = s;
        }

        public void PosizionaOstacolo(int r, int c, Ostacolo o)
        {
            ControllaCoordinate(r, c);
            ostacoli[r, c] = o;
        }

        public void RimuoviSquadra(int r, int c)
        {
            ControllaCoordinate(r, c);
            tabellone[r, c] = null;
        }

        public Squadra GetSquadra(int r, int c)
        {
            ControllaCoordinate(r, c);
            return tabellone[r, c];
        }

        public Ostacolo GetOstacolo(int r, int c)
        {
            ControllaCoordinate(r, c);
            return ostacoli[r, c];
        }

        private void ControllaCoordinate(int r, int c)
        {
            if (r < 0 || r > Dimensione - 1)
                throw new ArgumentException("riga non valida");
            if (c < 0 || c > Dimensione - 1)
                throw new ArgumentException("colonna non valida");
        }

        public void visualizza()
        {
            for (int r = 0; r < Dimensione; r++)
            {
                for (int c = 0; c < Dimensione; c++)
                {
                    if (tabellone[r, c] != null)
                        Console.Write(tabellone[r, c].Stampa());
                    else if (ostacoli[r, c] != null)
                    {
                        Console.Write(ostacoli[r, c].Stampa());
                    }
                    else
                        Console.Write("* ");
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }
        }
    }
}