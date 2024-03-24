using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
{
    public class Cavaliere : Personaggio
    {
        private bool danniDoppi;

        public Cavaliere() : base(950, 70, 125)
        {

        }

        public override void AttaccoBase(Personaggio p)
        {
            if (puntiAzione < 12)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            Random r = new Random();

            int mauro = r.Next(0, 2);

            if (mauro == 0)
            {
                danniDoppi = true;
            }
            else
            {
                danniDoppi = false;
            }

            if (p.Difesa == true && danniDoppi == true)
            {
                p.PuntiVita = p.PuntiVita - potenzaAttaccoBase;
                p.Difesa = false;
            }
            else if (p.Difesa == true && danniDoppi == false)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoBase / 2);
                p.Difesa = false;
            }
            else if (p.Difesa == false && danniDoppi == true)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoBase * 2);
            }
            else
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoBase);
            }

            if (p.PuntiVita <= 0)
            {
                p.Morto = true;
            }

            puntiAzione -= 12;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (puntiAzione < 22)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            Random r = new Random();

            int mauro = r.Next(0, 2);

            if (mauro == 0)
            {
                danniDoppi = true;
            }
            else
            {
                danniDoppi = false;
            }

            if (p.Difesa == true && danniDoppi == true)
            {
                p.PuntiVita = p.PuntiVita - potenzaAttaccoPesante;
            }
            else if (p.Difesa == true && danniDoppi == false)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoPesante / 2);
            }
            else if (p.Difesa == false && danniDoppi == true)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoPesante * 2);
            }
            else
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoPesante);
            }

            if (p.PuntiVita <= 0)
            {
                p.Morto = true;
            }

            puntiAzione -= 22;
        }
    }
}