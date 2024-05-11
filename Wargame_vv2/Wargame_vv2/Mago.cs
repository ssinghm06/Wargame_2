using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public class Mago : Personaggio
    {
        private int potenzaAttaccoRiserva;
        private bool attaccoriserva;

        public Mago() : base(1200, 200, 500, 1200)
        {
            potenzaAttaccoRiserva = 50;
            attaccoriserva = false;
        }

        public override void AttaccoBase(Personaggio p)
        {
            if (PuntiAzione < 15)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            p.PuntiVita = p.PuntiVita + potenzaAttaccoBase;

            puntiAzione -= 15;
        }

        public override void AttaccoPesante(Personaggio p)
        {
            if (puntiAzione < 25)
            {
                throw new Exception("Punti azione insufficienti!");
            }

            p.PuntiVita = p.PuntiVita + potenzaAttaccoPesante;

            puntiAzione -= 25;
        }

        public override string ToString()
        {
            return $"Mago";
        }
    }
}
