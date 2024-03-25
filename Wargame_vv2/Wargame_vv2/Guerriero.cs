using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class Guerriero : Personaggio
    {
        public Guerriero() : base(700, 1000, 3000, 700)
        {

        }

        public override void AttaccoBase(Personaggio p)
        {
            if (PuntiAzione < 10)
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

            PuntiAzione -= 10;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (PuntiAzione < 25)
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

            PuntiAzione -= 25;
        }

        public override string ToString()
        {
            return $"Guerriero";
        }
    }
}
