using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class Arciere : Personaggio
    {
        private int dannoFerito;

        public Arciere() : base(400, 1000, 100, 400)
        {
            dannoFerito = 50;
        }

        public override void AttaccoBase(Personaggio p)
        {
            if (PuntiAzione < 5)
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
            p.Ferito = true;

            PuntiAzione -= 5;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (puntiAzione < 10)
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
            p.Ferito = true;

            PuntiAzione -= 10;
        }

        public override string ToString()
        {
            return $"Arciere";
        }
    }
}
