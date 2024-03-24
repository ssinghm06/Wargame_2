using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv1
{
    public class Guerriero : Personaggio
    {
        public Guerriero() : base(700, 100, 300)
        {

        }

        public override void AttaccoBase(Personaggio p)
        {
            if (puntiAzione < 10)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            if (p.Difesa)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoBase / 2);
                p.Difesa = false;
            }

            else
            {
                p.PuntiVita = p.PuntiVita - potenzaAttaccoBase;
            }

            if (p.PuntiVita <= 0)
            {
                p.Morto = true;
            }

            puntiAzione -= 10;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (puntiAzione < 25)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            if (p.Difesa)
            {
                p.PuntiVita = p.PuntiVita - (potenzaAttaccoPesante / 2);
                p.Difesa = false;
            }

            else
            {
                p.PuntiVita = p.PuntiVita - potenzaAttaccoPesante;
            }

            if (p.PuntiVita <= 0)
            {
                p.Morto = true;
            }

            puntiAzione -= 25;
        }
    }
}
