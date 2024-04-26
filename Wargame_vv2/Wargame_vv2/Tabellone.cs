using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
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

        public void PosizionaSquadra(int x, int y, Squadra s)
        {
            ControllaCoordinate(x, y);
            tabellone[x, y] = s;
        }

        public void PosizionaOstacolo(int x, int y, Ostacolo o)
        {
            ControllaCoordinate(x, y);
            ostacoli[x, y] = o;
        }

        public void RimuoviSquadra(int x, int y)
        {
            ControllaCoordinate(x, y);
            tabellone[x, y] = null;
        }
        public void RimuoviOstacolo(int x, int y)
        {
            ControllaCoordinate(x, y);
            ostacoli[x, y] = null;
        }

        public Squadra GetSquadra(int x, int y)
        {
            ControllaCoordinate(x, y);
            return tabellone[x, y];
        }

        public Ostacolo GetOstacolo(int x, int y)
        {
            ControllaCoordinate(x, y);
            return ostacoli[x, y];
        }

        public void ControllaCoordinate(int x, int y)
        {
            if (x < 0 || x > Dimensione - 1)
                throw new ArgumentException("riga non valida");
            if (y < 0 || y > Dimensione - 1)
                throw new ArgumentException("colonna non valida");
        }
    }
}
