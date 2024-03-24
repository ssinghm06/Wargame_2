using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargame_vv2
{
    public abstract class Personaggio
    {
        protected int puntiVita;
        protected int puntiAzione;
        protected int potenzaAttaccoBase;
        protected int potenzaAttaccoPesante;
        protected bool difesa;
        protected bool ferito;
        protected bool morto;


        public bool Difesa
        {
            get { return difesa; }
            set { difesa = value; }
        }

        public int PuntiVita
        {
            get { return puntiVita; }
            set { puntiVita = value; }
        }

        public int PuntiAzione
        {
            get { return puntiAzione; }
            set { puntiAzione = value; }
        }

        public bool Morto
        {
            get { return morto; }
            set { morto = value; }
        }

        public bool Ferito
        {
            get { return ferito; }
            set { ferito = value; }
        }

        public Personaggio(int pV, int pAB, int pAP)
        {
            puntiAzione = 50;
            puntiVita = pV;
            potenzaAttaccoBase = pAB;
            potenzaAttaccoPesante = pAP;
            difesa = false;
            ferito = false;
            morto = false;
        }

        public abstract void AttaccoBase(Personaggio p);

        public abstract void AttaccoPesante(Personaggio p);

        public void AttivaDifesa()
        {
            difesa = true;
        }

        public void IsFerito(Squadra s)
        {
            foreach (Personaggio p in s.Squad)
            {
                if (p.Ferito)
                {
                    p.PuntiVita -= 50;
                    p.Ferito = false;
                }
            }
        }
    }
}
