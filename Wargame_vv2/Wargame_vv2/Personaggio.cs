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
        protected int puntiVitaMassimi;
        protected int puntiAzioneMassimi;
        protected int potenzaAttaccoBase;
        protected int potenzaAttaccoPesante;
        protected bool difesa;
        protected bool ferito;
        protected bool morto;

        public int PuntiVitaMassimi
        {
            get { return puntiVitaMassimi; }
            set { puntiVitaMassimi = value; }
        }

        public int PuntiAzioneMassimi
        {
            get { return puntiAzioneMassimi; }
            set { puntiAzioneMassimi = value; }
        }

        public bool Difesa
        {
            get { return difesa; }
            set { difesa = value; }
        }

        public int PuntiVita
        {
            get { return puntiVita; }
            set
            {
                if (value > PuntiVitaMassimi)
                {
                    value = PuntiVitaMassimi;
                }

                if (value < 0)
                {
                    value = 0;
                    morto = true;
                }
                puntiVita = value;
            }
        }

        public int PuntiAzione
        {
            get { return puntiAzione; }
            set
            {
                if (value > PuntiAzioneMassimi)
                {
                    value = PuntiAzioneMassimi;
                }
                puntiAzione = value;
            }
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

        public Personaggio(int pV, int pAB, int pAP, int pVM)
        {
            puntiAzione = 50;
            puntiVita = pV;
            potenzaAttaccoBase = pAB;
            potenzaAttaccoPesante = pAP;
            difesa = false;
            ferito = false;
            morto = false;
            puntiVitaMassimi = pVM;
            puntiAzioneMassimi = 50;
        }

        public abstract void AttaccoBase(Personaggio p);

        public abstract void AttaccoPesante(Personaggio p);

        public void AttivaDifesa()
        {
            difesa = true;
        }
    }
}
