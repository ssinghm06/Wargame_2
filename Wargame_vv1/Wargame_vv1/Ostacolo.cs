using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
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

        public Ostacolo(TipoOstacolo tipo)
        {
            this.tipo = tipo;
        }

        public static bool GeneraOstacoloCasuale(Tabellone t)
        {
            Random r = new Random();

            int randomRiga = r.Next(0, t.Dimensione);
            int randomColonna = r.Next(0, t.Dimensione);
            TipoOstacolo tipoOstacolo = (TipoOstacolo)r.Next(0, 3);

            Ostacolo ostacolo = new Ostacolo(tipoOstacolo);

            // controlla se ci sono ostacoli nelle posizioni vicine
            if (CheckVicino(t, randomRiga, randomColonna))
                return false;

            // controlla che non ci siano squadre o ostacoli in questa posizione
            if (t.GetSquadra(randomRiga, randomColonna) != null || t.GetOstacolo(randomRiga, randomColonna) != null)
                return false;

            t.PosizionaOstacolo(randomRiga, randomColonna, ostacolo);
            return true;
        }

        private static bool CheckVicino(Tabellone t, int riga, int colonna)
        {
            for (int i = riga - 1; i <= riga + 1; i++)
            {
                for (int j = colonna - 1; j <= colonna + 1; j++)
                {
                    if (i >= 0 && i < t.Dimensione && j >= 0 && j < t.Dimensione && (i != riga || j != colonna))
                    {
                        if (t.GetOstacolo(i, j) != null)
                            return true;
                    }
                }
            }
            return false;
        }

        public string Stampa()
        {
            if (tipo == TipoOstacolo.Lago)
                return "L ";
            else if (tipo == TipoOstacolo.Montagna)
                return "M ";
            else
                return "F ";
        }
    }
}