using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Wargame_vv2
{
    public partial class Form1 : Form
    {
        Tabellone tabellone;
        PictureBox[,] caselle;
        List<Squadra> squadre;
        Squadra squadraSelezionata = null;

        // mi serve per togliere la casella evidenziata --> unica soluzione che mi e venuta in mente
        List<Image> immaginiMosse;

        public MessageCustomYesNo customMessageBox = new MessageCustomYesNo();

        public Squadra SquadraSelezionata
        {
            get { return squadraSelezionata; }
            set { squadraSelezionata = value; }
        }

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackColor = Color.CadetBlue;
            //this.BackgroundImage = CaricaImmagine("sfondo.png");

            // un po di grafica
            pictureBox1.BackColor = Color.BurlyWood;
            pictureBox2.BackColor = Color.BurlyWood;
            pictureBox3.BackColor = Color.BurlyWood;

            label1.BackColor = Color.BurlyWood;
            label1.ForeColor = Color.DarkSlateGray;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = CaricaImmagine("war.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = CaricaImmagine("flag.png");

            tabellone = new Tabellone();
            caselle = new PictureBox[tabellone.Dimensione, tabellone.Dimensione];
            immaginiMosse = new List<Image>();

            // creo e posiziono le squadre
            squadre = new List<Squadra>()
            {
                new Squadra(7, 1, Squadra.Type.Gladiator, tabellone),
                new Squadra(8, 1, Squadra.Type.Gladiator, tabellone),
                new Squadra(8, 2, Squadra.Type.Gladiator, tabellone),
                new Squadra(1, 1, Squadra.Type.Knight, tabellone),
                new Squadra(2, 1, Squadra.Type.Knight, tabellone),
                new Squadra(1, 2, Squadra.Type.Knight, tabellone),
                new Squadra(1, 8, Squadra.Type.Viking, tabellone),
                new Squadra(2, 8, Squadra.Type.Viking, tabellone),
                new Squadra(1, 7, Squadra.Type.Viking, tabellone),
                new Squadra(8, 8, Squadra.Type.Shogun, tabellone),
                new Squadra(7, 8, Squadra.Type.Shogun, tabellone),
                new Squadra(8, 7, Squadra.Type.Shogun, tabellone)
            };

            foreach (Squadra s in squadre)
                tabellone.PosizionaSquadra(s.X, s.Y, s);

            // genero gli ostacoli
            int i = 0;
            while (i < 12)  // diminuito numero da 15 a 12 --> 15 erano troppi!
                if (Ostacolo.GeneraOstacoloCasuale(tabellone))
                    i++;

            StampaTabellone();
        }

        private void StampaTabellone()
        {
            // calcolo la dimensione di una casella
            int dimCasella = panel1.Width / tabellone.Dimensione;

            // la casella deve essere un quadrato
            panel1.Height = panel1.Width;

            // ciclo per creare le caselle sullo schermo
            for (int x = 0; x < tabellone.Dimensione; x++)
            {
                for (int y = 0; y < tabellone.Dimensione; y++)
                {
                    Color coloreCasella;
                    if ((x + y) % 2 == 0)
                        coloreCasella = Color.SaddleBrown;
                    else
                        coloreCasella = Color.SandyBrown;

                    PictureBox casellaCorrente = new PictureBox();

                    casellaCorrente.Height = dimCasella;
                    casellaCorrente.Width = dimCasella;
                    casellaCorrente.BackColor = coloreCasella;  // assegno il colore alla casella

                    // per outline : a me non piace!
                    // caselle[x, y].BorderStyle = BorderStyle.FixedSingle;

                    // adatta immagine
                    casellaCorrente.SizeMode = PictureBoxSizeMode.Zoom;

                    panel1.Controls.Add(casellaCorrente);

                    casellaCorrente.Click += new EventHandler(Casella_Click);

                    // serve per calcolare il punto della nuova casella
                    casellaCorrente.Location = new Point(x * dimCasella, y * dimCasella);

                    // per visualizzare gli ostacoli
                    if (tabellone.GetOstacolo(x, y) is Ostacolo)
                        casellaCorrente.Image = CaricaImmagine(tabellone.GetOstacolo(x, y));

                    // per visualizzare le squadre
                    if (tabellone.GetSquadra(x, y) is Squadra)
                    {
                        casellaCorrente.Image = CaricaImmagine(tabellone.GetSquadra(x, y));
                        casellaCorrente.Tag = tabellone.GetSquadra(x, y);
                    }

                    caselle[x, y] = casellaCorrente;
                }
            }
        }

        private Image CaricaImmagine(Squadra s)
        {
            if (s.Tipo is Squadra.Type.Gladiator)
                return CaricaImmagine("gladiator.png");
            else if (s.Tipo is Squadra.Type.Knight)
                return CaricaImmagine("knight.png");
            else if (s.Tipo is Squadra.Type.Shogun)
                return CaricaImmagine("shogun.png");
            else if (s.Tipo is Squadra.Type.Viking)
                return CaricaImmagine("viking.png");
            else
                return null;
        }

        private Image CaricaImmagine(Ostacolo o)
        {
            if (o.Tipo is Ostacolo.TipoOstacolo.Foresta)
                return CaricaImmagine("foresta.png");
            else if (o.Tipo is Ostacolo.TipoOstacolo.Lago)
                return CaricaImmagine("lago.png");
            else if (o.Tipo is Ostacolo.TipoOstacolo.Montagna)
                return CaricaImmagine("montagna.png");
            else
                return null;
        }

        public Image CaricaImmagine(string p)
        {
            try
            {
                Bitmap myImage = new Bitmap(p);
                return myImage;
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nel caricare l'immagine", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            customMessageBox = CustomMessageBox();

            DialogResult risposta = customMessageBox.ShowDialog();

            if (risposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // creo un metodo per gestire il click su una casella
        private void Casella_Click(object sender, EventArgs e)
        {
            PictureBox casellaCliccata = (PictureBox)sender;

            // ottengo le informazioni sulla squadra associata
            Squadra squadraCliccata = (Squadra)casellaCliccata.Tag;

            if (squadraCliccata != null && squadraCliccata.Tipo == Squadra.Type.Viking)
            {
                // ci sono tre casistiche 'speciali'

                // se non ho ancora selezionato una squadra
                // allora la seleziono e la evidenzio
                if (SquadraSelezionata == null)
                {
                    SquadraSelezionata = squadraCliccata;
                    EvidenziaMossaValida(squadraCliccata);
                }

                // se seleziono la squadra stessa per la seconda volta (ci riclicco)
                // allora la deseleziono e resetto l'evidenzia
                else if (SquadraSelezionata == squadraCliccata)
                {
                    ResettaEvidenzia();
                    SquadraSelezionata = null;
                }

                // se seleziono una squadra diversa da quella precedentemente selezionata
                // allora deseleziono quella vecchia e poi seleziono la nuova e la evidenzio
                else
                {
                    ResettaEvidenzia();
                    SquadraSelezionata = squadraCliccata;
                    EvidenziaMossaValida(squadraCliccata);
                }
            }
            else
            {
                if (IsMossaValida(casellaCliccata))
                {
                    (int x, int y) = CoordinateCasellaCliccata(casellaCliccata);

                    caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Tag = null;
                    caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Image = null;

                    SquadraSelezionata.Muovi(x, y);

                    // per Invadi
                    if (SquadraSelezionata.ModCombattimento)
                    {
                        Form3 form3  = new Form3(SquadraSelezionata, squadraCliccata);
                        form3.Show();
                        this.Hide();

                        //MessageBox.Show("ciao");

                        // errore GREVE --> serve solo per test
                        SquadraSelezionata.ModCombattimento = false;
                    }

                    casellaCliccata.Tag = SquadraSelezionata;
                    caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Image = CaricaImmagine(SquadraSelezionata);
                }

                ResettaEvidenzia();
                SquadraSelezionata = null;
            }
        }

        private void EvidenziaMossaValida(Squadra s)
        {
            // resetto le zone evidenziate
            ResettaEvidenzia();

            // in questa lista di tuple vado a salvare tutte le mosse valide
            List<(int, int)> mosseValide = s.MossaValida(tabellone);

            for (int i = 0; i < mosseValide.Count; i++)
            {
                // tiro fuori la x e la y
                int newX = mosseValide[i].Item1;
                int newY = mosseValide[i].Item2;

                Squadra squadraInCasella = tabellone.GetSquadra(newX, newY);
                if (squadraInCasella != null && squadraInCasella.Tipo != s.Tipo)
                    caselle[newX, newY].Image = SovrapponiImmagini("yellow.png", CaricaImmagine(squadraInCasella));
                else
                    caselle[newX, newY].Image = CaricaImmagine("yellow.png");

                immaginiMosse.Add(caselle[newX, newY].Image);

                //caselle[newX, newY].Image = CaricaImmagine("yellow.png");
                //immaginiMosse.Add(caselle[newX, newY].Image);
            }
        }

        private Image SovrapponiImmagini(string p, Image immagine)
        {
            Image sfondo = CaricaImmagine(p);  // immagine 'yellow.png'

            // creo immagine vuota delle stesse dimensioni dell'immagine di sfondo
            // eh la base dell'immagine sovrapposta
            Bitmap finale = new Bitmap(sfondo.Width, sfondo.Height);


            Graphics g = Graphics.FromImage(finale);
            g.DrawImage(sfondo, 0, 0, sfondo.Width, sfondo.Height);
            g.DrawImage(immagine, 0, 0, immagine.Width, immagine.Height);

            return finale;
        }

        private void ResettaEvidenzia()
        {
            if (immaginiMosse.Count > 0)
            {
                foreach (PictureBox casella in caselle)
                {
                    if (immaginiMosse.Contains(casella.Image))
                    {
                        if (casella.Tag != null)
                            casella.Image = CaricaImmagine((Squadra)casella.Tag);
                        else
                            casella.Image = null;
                    }
                }
            }

            immaginiMosse.Clear();
        }

        private bool IsMossaValida(PictureBox casella)
        {
            foreach (Image immagineMossa in immaginiMosse)
            {
                if (casella.Image == immagineMossa)
                    return true;
            }
            return false;
        }

        private (int, int) CoordinateCasellaCliccata(PictureBox casella)
        {
            for (int x = 0; x < tabellone.Dimensione; x++)
            {
                for (int y = 0; y < tabellone.Dimensione; y++)
                {
                    if (caselle[x, y] == casella)
                        return (x, y);
                }
            }

            // se la casella non viene trovata --> restituisce dei valori di 'default'
            return (-1, -1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public MessageCustomYesNo CustomMessageBox()
        {
            customMessageBox.Message = "wanna quit?";
            customMessageBox.YesImage = CaricaImmagine("yes.png");
            customMessageBox.NoImage = CaricaImmagine("no.png");
            customMessageBox.closeImage = CaricaImmagine("delete-cross.png");

            return customMessageBox;
        }
    }
}
