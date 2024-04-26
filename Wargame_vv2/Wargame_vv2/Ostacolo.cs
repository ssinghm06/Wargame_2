using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class Ostacolo
    {
        public enum TipoOstacolo
        {
            Lago,
            Montagna,
            Foresta
        }

        private TipoOstacolo tipo;
        public TipoOstacolo Tipo
        {
            get { return tipo; } 
            set { tipo = value; }
        }

        public Ostacolo(TipoOstacolo tipo)
        {
            Tipo = tipo;
        }

        public static bool GeneraOstacoloCasuale(Tabellone t)
        {
            Random r = new Random();

            int randomX = r.Next(0, t.Dimensione);
            int randomY = r.Next(0, t.Dimensione);
            TipoOstacolo tipoOstacolo = (TipoOstacolo)r.Next(0, 3);

            Ostacolo ostacolo = new Ostacolo(tipoOstacolo);

            // controlla se ci sono ostacoli nelle posizioni vicine
            if (CheckVicino(t, randomX, randomY))
                return false;

            // controlla che non ci siano squadre o ostacoli in questa posizione
            if (t.GetSquadra(randomX, randomY) != null || t.GetOstacolo(randomX, randomY) != null)
                return false;

            t.PosizionaOstacolo(randomX, randomY, ostacolo);
            return true;
        }

        private static bool CheckVicino(Tabellone t, int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < t.Dimensione && j >= 0 && j < t.Dimensione && (i != x || j != y))
                    {
                        if (t.GetOstacolo(i, j) != null)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
