using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class Squadra
    {
        public enum Type
        {
            Viking,
            Shogun,
            Knight,
            Gladiator,
        }

        private List<Personaggio> squad = new List<Personaggio>();

        private Tabellone tabellone;
        private int x;
        private int y;
        private Type tipo;
        private bool modCombattimento;
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

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Squadra(int x, int y, Type ti, Tabellone t)
        {
            CreaSquadra();

            X = x;
            Y = y;
            Tipo = ti;
            tabellone = t;
            ModCombattimento = false;
            viva = true;
        }

        public void CreaSquadra()
        {
            Squad.Add(new Guerriero());
            Squad.Add(new Cavaliere());
            Squad.Add(new Arciere());
            Squad.Add(new Mago());
        }

        public void Muovi(int newX, int newY)
        {
            if (newX < 0 || newX > tabellone.Dimensione - 1)
                throw new ArgumentException("posizione non valida");
            if (newY < 0 || newY > tabellone.Dimensione - 1)
                throw new ArgumentException("posizione non valida");

            int diffX = Math.Abs(newX - X);
            int diffY = Math.Abs(newY - Y);

            if (!(diffX <= 1 && diffY <= 1))
                throw new ArgumentException("mossa non valida per la squadra");

            Ostacolo o = tabellone.GetOstacolo(newX, newY);
            if (o != null)
                throw new ArgumentException("ostacolo in mezzo");

            Squadra s = tabellone.GetSquadra(newX, newY);
            if (s != null && s.Tipo == Tipo)
                throw new ArgumentException("casella occupata da una tua squadra");

            if (InvadiSquadra(newX, newY))
                modCombattimento = true;

            tabellone.RimuoviSquadra(X, Y);

            X = newX;
            Y = newY;
            tabellone.PosizionaSquadra(X, Y, this);
        }

        public void Cura(int punti)
        {
            foreach (Personaggio p in Squad)
                p.PuntiVita += punti;
        }

        public bool InvadiSquadra(int x, int y)
        {
            Squadra s = tabellone.GetSquadra(x, y);
            if (s != null && s.Tipo != Tipo)
                return true;
            return false;
        }

        public List<(int, int)> MossaValida(Tabellone t)
        {
            List<(int, int)> mosseValide = new List<(int, int)>();

            for (int i = X - 1; i <= X + 1; i++)
            {
                for (int j = Y - 1; j <= Y + 1; j++)
                {
                    // ignora la posizione corrente e controlla che le coordinte siano del tabellone
                    if ((i != X || j != Y) && i >= 0 && i < t.Dimensione && j >= 0 && j < t.Dimensione)
                    {
                        int diffX = Math.Abs(i - X);
                        int diffY = Math.Abs(j - Y);

                        if (diffX <= 1 && diffY <= 1)
                        {
                            Squadra s = tabellone.GetSquadra(i, j);
                            Ostacolo o = tabellone.GetOstacolo(i, j);

                            // questo if clause controlla che le caselle siano libere sia da squadre che da ostacoli
                            // in caso ci sia una squadra deve essere avversaria
                            if ((s == null || s.Tipo != Tipo) && o == null)
                            {
                                mosseValide.Add((i, j));
                            }
                        }
                    }
                }
            }

            return mosseValide;
        }
    }
}
