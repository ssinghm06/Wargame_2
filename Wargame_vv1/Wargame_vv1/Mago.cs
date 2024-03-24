using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
{
    public class Mago : Personaggio
    {
        private int potenzaAttaccoRiserva;
        private bool attaccoriserva;

        public Mago() : base(1200, 200, 500)
        {
            potenzaAttaccoRiserva = 50;
            attaccoriserva = false;
        }

        public override void AttaccoBase(Personaggio p)
        {
            if (puntiAzione < 15)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            p.PuntiVita = p.PuntiVita + potenzaAttaccoBase;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (puntiAzione < 30)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            p.PuntiVita = p.PuntiVita + potenzaAttaccoPesante;
        }

        public void ControlloAttaccoRiserva(Squadra s)
        {
            int i = 0;
            foreach (Personaggio p in s.Squad)
            {
                if (p.Morto == true && !(p is Mago))
                    i += 1;
            }

            if (i == 3)
            {
                attaccoriserva = true;
            }
        }

        public void AttaccoRiserva(Personaggio p)
        {
            if (puntiAzione < 5)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            if (p.Difesa)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoRiserva / 2);
                p.Difesa = false;
            }

            else
            {
                p.PuntiVita = p.PuntiVita - potenzaAttaccoRiserva;
            }

            if (p.PuntiVita <= 0)
            {
                p.Morto = true;
            }

            puntiAzione -= 5;
        }
    }
}
