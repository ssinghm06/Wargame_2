using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Media;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Wargame_vv2
{
    public partial class Form1 : Form
    {
        private static Form1 form1;
        public static Form1 Fform1 { get { return form1; } }

        private Tabellone tabellone;
        private PictureBox[,] caselle;
        private List<Squadra> squadre;
        private List<Ostacolo> ostacoli = new List<Ostacolo>();
        private HashSet<Squadra.Type> tipiDiSquadra = new HashSet<Squadra.Type>();

        private Form4 regole = new Form4();
        private Form3 form3;

        private Squadra squadraSelezionata = null;
        private Squadra squadraVinta;
        private Squadra squadraPersa;

        private List<Image> immaginiMosse;

        public MessageCustomYesNo customMessageBox = new MessageCustomYesNo();
        private ResultBox resultBox = new ResultBox();

        private int turno = 0;
        private bool turnoGiocatore = true;
        private bool gioca = false;
        private bool invaso = false;

        private bool win = false;

        private int cont = 3;
        private int minutiTrascorsi = 0;
        private int secondiTrascorsi = 0;

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

            form1 = this;

            // un po di grafica
            button1.BackColor = Color.OldLace;
            button2.BackColor = Color.OldLace;

            button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            button2.FlatAppearance.MouseDownBackColor = button2.BackColor;

            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.BackColor = Color.OldLace;
            pictureBox5.Image = CaricaImmagine("baule_chiuso.png");

            pictureBox1.BackColor = Color.BurlyWood;
            pictureBox2.BackColor = Color.BurlyWood;
            pictureBox3.BackColor = Color.BurlyWood;

            label1.BackColor = Color.BurlyWood;
            label1.ForeColor = Color.DarkSlateGray;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = CaricaImmagine("war.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = CaricaImmagine("flag.png");

            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = CaricaImmagine("pergamena.png");

            label3.Image = CaricaImmagine("sfondoTesto.png");

            tabellone = new Tabellone();
            caselle = new PictureBox[tabellone.Dimensione, tabellone.Dimensione];
            immaginiMosse = new List<Image>();

            GenerazioneSquadre();
            GenerazioneOstacoli();

            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.Image = CaricaImmagine("intro.png");

            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Image = CaricaImmagine("clessidra.png");

            StampaTabellone();
        }

        private void GenerazioneOstacoli()
        {
            int i = 0;
            while (i < 12)  // diminuito numero da 15 a 12 --> 15 erano troppi!
            {
                Ostacolo nuovoOstacolo = Ostacolo.GeneraOstacoloCasuale(tabellone);
                if (nuovoOstacolo != null)
                {
                    ostacoli.Add(nuovoOstacolo);
                    i++;
                }
            }
        }

        public static void CambiaLingua(Form1 form)
        {
            form.CambiaTesto();
        }

        private void CambiaTesto()
        {
            if (gioca)
            {
                if (Form4.Italiano)
                    label2.Text = "turno del vichingo!";
                else
                    label2.Text = "viking's turn!";
            }
            else
            {
                if (Form4.Italiano)
                    label2.Text = "- non disponibile -";
                else
                    label2.Text = "- unavailable -";
            }

            if (Form4.Italiano)
            {
                button1.Text = "gioca";
                button2.Text = "regole";
                label3.Text = "In un mondo sconvolto da un'anomalia temporale, legioni storiche combattono per determinare la goat, mentre un'invasione aliena minaccia l'umanità. Con il destino dell'umanità in bilico, le legioni si uniscono per salvare il mondo.";
            }
            else
            {
                button1.Text = "play";
                button2.Text = "rules";
                label3.Text = "In a world disrupted by a temporal anomaly, historical legions battle to determine the greatest of all time, as an alien invasion threatens humanity. With the fate of mankind hanging in the balance, the legions unite to repel the alien assault and save the world.";
            }
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

        public static Image CaricaImmagine(string p)
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
            timer1.Stop();

            pictureBox6.Enabled = false;

            customMessageBox = CustomMessageBox();

            DialogResult risposta = customMessageBox.ShowDialog();

            if (risposta == DialogResult.Yes)
                Application.Exit();
            else
            {
                pictureBox6.Enabled = true;
                timer1.Start();
            }
        }

        // creo un metodo per gestire il click su una casella
        private async void Casella_Click(object sender, EventArgs e)
        {
            if (gioca)
            {
                if (turno == 0)
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
                        if (IsMossaValida(casellaCliccata) && squadraSelezionata != null)
                        {
                            (int x, int y) = CoordinateCasellaCliccata(casellaCliccata);

                            caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Tag = null;
                            caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Image = null;

                            SquadraSelezionata.Muovi(x, y);
                            AudioPlayer.CaricaAudio("move.wav");
                            AudioPlayer.PlayAudio();
                            turnoGiocatore = false;

                            if (SquadraSelezionata.ModCombattimento)
                            {
                                AudioPlayer.CaricaAudio("invadi.wav");
                                AudioPlayer.PlayAudio();
                                invaso = true;
                                SquadraSelezionata.ModCombattimento = false;

                                form3 = new Form3(SquadraSelezionata, squadraCliccata);
                                form3.Show();
                                this.Hide();
                                regole.Hide();

                                form3.FormClosing += Form3_FormClosing;
                                form3.FormClosed += Form3_FormClosed;
                            }

                            casellaCliccata.Tag = SquadraSelezionata;
                            caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Image = CaricaImmagine(SquadraSelezionata);

                            ResettaEvidenzia();
                            SquadraSelezionata = null;

                            if (turnoGiocatore != true && invaso != true)
                            {
                                for (int i = 0; i < tipiDiSquadra.Count - 1; i++)
                                {
                                    Squadra.Type tipoSquadra = tipiDiSquadra.ElementAt(i + 1);
                                    await Task.Delay(1000);
                                    GestisciTurnoBot(tipoSquadra);
                                }

                                await Task.Delay(1000);
                                label2.ForeColor = Color.MediumBlue;
                                if (Form4.Italiano)
                                    label2.Text = "viking's turn!";
                                else
                                    label2.Text = "turno del vichingo!";
                                turnoGiocatore = true;
                            }
                        }
                    }
                }
            }
        }

        private void Form3_FormClosing(object? sender, FormClosingEventArgs e)
        {
            form3.Regolerpg.Close();
            squadraVinta = form3.Winner();
            squadraPersa = form3.Loser();
        }

        private async void Form3_FormClosed(object? sender, FormClosedEventArgs e)
        {
            turnoGiocatore = true;
            invaso = false;
            this.Show();

            squadre.Remove(squadraPersa);

            if (!squadre.Any(s => s.Tipo == squadraPersa.Tipo))
            {
                // Se sì, rimuove il tipo di squadra dalla lista tipiDiSquadra
                tipiDiSquadra.Remove(squadraPersa.Tipo);
            }

            squadraSelezionata = squadraVinta;
            caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Tag = SquadraSelezionata;
            caselle[SquadraSelezionata.X, SquadraSelezionata.Y].Image = CaricaImmagine(SquadraSelezionata);

            await Task.Delay(1000);

            IsEndGame();
        }

        // algoritmo base bot --> migliorabile
        private void GestisciTurnoBot(Squadra.Type tipoSquadra)
        {
            //turno++;

            //Squadra.Type tipoSquadra;

            //if (turno == 1)
            //{
            //    tipoSquadra = Squadra.Type.Shogun;
            //}
            //else if (turno == 2)
            //{
            //    tipoSquadra = Squadra.Type.Gladiator;
            //}
            //else
            //{
            //    tipoSquadra = Squadra.Type.Knight;
            //}

            //MessageBox.Show(tipoSquadra.ToString());

            List<Squadra> squadreDelTipo = squadre.Where(s => s.Tipo == tipoSquadra).ToList();

            // se non ci sono squadre del tipo --> esci dal metodo
            //if (squadreDelTipo.Count == 0)
            //{
            //    return;
            //}

            if (!squadre.Any(s => s.Tipo == tipoSquadra))
            {
                tipiDiSquadra.Remove(tipoSquadra);
            }

            if (turno <= 3 && squadreDelTipo.Count > 0)
            {
                label2.ForeColor = Color.Red;
                
                if (Form4.Italiano)
                    label2.Text = tipoSquadra.ToString() + "'S TURN!";
                else
                {
                    if (tipoSquadra == Squadra.Type.Gladiator)
                        label2.Text = "turno del gladiatore!";
                    else if (tipoSquadra == Squadra.Type.Knight)
                        label2.Text = "turno del cavaliere!";
                    else
                        label2.Text = "turno del " + tipoSquadra.ToString() + "!";
                }

                // sceglie casualmente una delle squadre
                Random r = new Random();
                Squadra squadraScelta = squadreDelTipo[r.Next(squadreDelTipo.Count)];

                List<(int, int)> mosseValide = squadraScelta.MossaValida(tabellone);
                (int x, int y) mossaScelta = mosseValide[r.Next(mosseValide.Count)];

                Squadra squadraAvversaria = tabellone.GetSquadra(mossaScelta.x, mossaScelta.y);

                immaginiMosse.Add(caselle[mossaScelta.x, mossaScelta.y].Image);

                PictureBox casellaScelta = caselle[mossaScelta.x, mossaScelta.y];

                // INVADI
                if (IsMossaValida(casellaScelta))
                {
                    (int x, int y) = CoordinateCasellaCliccata(casellaScelta);

                    caselle[squadraScelta.X, squadraScelta.Y].Tag = null;
                    caselle[squadraScelta.X, squadraScelta.Y].Image = null;

                    squadraScelta.Muovi(x, y);
                    AudioPlayer.CaricaAudio("move.wav");
                    AudioPlayer.PlayAudio();

                    if (caselle[mossaScelta.x, mossaScelta.y].Tag != null)
                    {
                        AudioPlayer.CaricaAudio("invadi.wav");
                        AudioPlayer.PlayAudio();
                        if (squadraAvversaria.Tipo is Squadra.Type.Viking)
                        {
                            if (squadraScelta.ModCombattimento)
                            {
                                squadraScelta.ModCombattimento = false;

                                form3 = new Form3(squadraAvversaria, squadraScelta);
                                form3.Show();
                                this.Hide();
                                regole.Hide();

                                form3.FormClosing += Form3_FormClosing;
                                form3.FormClosed += Form3_FormClosed;
                                //MessageBox.Show("ciao");
                            }

                            casellaScelta.Tag = squadraScelta;
                            casellaScelta.Image = CaricaImmagine(squadraScelta);
                        }
                        else
                        {
                            int win = r.Next(0, 2);

                            //MessageBox.Show($"{win}");

                            if (win == 0)
                            {
                                squadre.Remove(squadraAvversaria);

                                casellaScelta.Tag = squadraScelta;
                                casellaScelta.Image = CaricaImmagine(squadraScelta);
                            }
                            else
                            {
                                squadre.Remove(squadraScelta);

                                casellaScelta.Tag = squadraAvversaria;
                                casellaScelta.Image = CaricaImmagine(squadraAvversaria);
                            }
                        }
                    }
                    else
                    {
                        casellaScelta.Tag = squadraScelta;
                        casellaScelta.Image = CaricaImmagine(squadraScelta);
                    }
                }
            }

            //if (turno > 2)
            //{
            //    turno = 0;
            //}
        }

        private void IsEndGame()
        {
            if (tipiDiSquadra.Contains(Squadra.Type.Viking) == false)
            {
                timer1.Stop();
                win = false;
                AudioPlayer.CaricaAudio("loss.wav");
                AudioPlayer.PlayAudio();

                resultBox = ResultMessageBox();
                DialogResult risposta = resultBox.ShowDialog();

                if (risposta == DialogResult.Yes)
                {
                    ResetTimer();
                    //restart
                    ResetGame();
                }
                else
                    Application.Exit();
            }

            if (tipiDiSquadra.Count == 1)
            {
                if (tipiDiSquadra.Contains(Squadra.Type.Viking))
                {
                    timer1.Stop();
                    win = true;
                    AudioPlayer.CaricaAudio("win.wav");
                    AudioPlayer.PlayAudio();

                    resultBox = ResultMessageBox();
                    DialogResult risposta = resultBox.ShowDialog();

                    if (risposta == DialogResult.Yes)
                    {
                        ResetTimer();
                        //restart
                        ResetGame();
                    }
                    else
                        Application.Exit();
                }
            }
        }

        private void ResetGame()
        {
            foreach (Squadra s in squadre)
                tabellone.RimuoviSquadra(s.X, s.Y);

            foreach (Ostacolo o in ostacoli)
                tabellone.RimuoviOstacolo(o.X, o.Y); 

            win = false;
            turnoGiocatore = true;
            gioca = false;
            invaso = false;
            squadraSelezionata = null;

            squadre.Clear();
            tipiDiSquadra.Clear();
            immaginiMosse.Clear();
            panel1.Controls.Clear();

            panel1.BackColor = Color.Transparent;

            GenerazioneSquadre();
            GenerazioneOstacoli();
            StampaTabellone();

            AudioPlayer.CaricaAudio("board.wav");
            AudioPlayer.PlayAudio();
        }

        private void GenerazioneSquadre()
        {
            squadre = new List<Squadra>()
            {
                new Squadra(1, 8, Squadra.Type.Viking, tabellone),
                new Squadra(2, 8, Squadra.Type.Viking, tabellone),
                new Squadra(1, 7, Squadra.Type.Viking, tabellone),
                new Squadra(8, 8, Squadra.Type.Shogun, tabellone),
                new Squadra(7, 8, Squadra.Type.Shogun, tabellone),
                new Squadra(8, 7, Squadra.Type.Shogun, tabellone),
                new Squadra(7, 1, Squadra.Type.Gladiator, tabellone),
                new Squadra(8, 1, Squadra.Type.Gladiator, tabellone),
                new Squadra(8, 2, Squadra.Type.Gladiator, tabellone),
                new Squadra(1, 1, Squadra.Type.Knight, tabellone),
                new Squadra(2, 1, Squadra.Type.Knight, tabellone),
                new Squadra(1, 2, Squadra.Type.Knight, tabellone)
                //new Squadra(1, 8, Squadra.Type.Viking, tabellone),
                //new Squadra(2, 8, Squadra.Type.Shogun, tabellone),
            };

            foreach (Squadra s in squadre)
            {
                tabellone.PosizionaSquadra(s.X, s.Y, s);
                tipiDiSquadra.Add(s.Tipo);
            }
        }

        private void EvidenziaMossaValida(Squadra s)
        {
            if (turnoGiocatore)
            {
                // resetto le zone evidenziate
                ResettaEvidenzia();

                // in questa lista di tuple vado a salvare tutte le mosse valide
                List<(int, int)> mosseValide = s.MossaValida(tabellone);

                foreach ((int newX, int newY) in mosseValide)
                {
                    Squadra squadraInCasella = tabellone.GetSquadra(newX, newY);
                    if (squadraInCasella != null && squadraInCasella.Tipo != s.Tipo)
                    {
                        caselle[newX, newY].Image = SovrapponiImmagini("yellow.png", CaricaImmagine(squadraInCasella));
                        immaginiMosse.Add(caselle[newX, newY].Image);
                    }
                    else if (squadraInCasella == null)
                    {
                        caselle[newX, newY].Image = CaricaImmagine("yellow.png");
                        immaginiMosse.Add(caselle[newX, newY].Image);
                    }
                }
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
            if (Form4.Italiano)
                customMessageBox.Message = "wanna quit?";
            else
                customMessageBox.Message = "vuoi abbandonare?";
            customMessageBox.YesImage = CaricaImmagine("yes.png");
            customMessageBox.NoImage = CaricaImmagine("no.png");
            customMessageBox.closeImage = CaricaImmagine("delete-cross.png");

            return customMessageBox;
        }

        public ResultBox ResultMessageBox()
        {
            if (Form4.Italiano)
            {
                if (win)
                    resultBox.Message = "YOU WON!";
                else
                    resultBox.Message = "YOU LOST!";
            }
            else
            {
                if (win)
                    resultBox.Message = "HAI VINTO!";
                else
                    resultBox.Message = "HAI PERSO!";
            }

            resultBox.ReplayImage = CaricaImmagine("replay.png");
            resultBox.ExitImage = CaricaImmagine("exit.png");

            return resultBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsRules();

            AudioPlayer.CaricaAudio("openChest.wav");
            AudioPlayer.PlayAudio();

            pictureBox5.Image = CaricaImmagine("baule_aperto.png");
        }

        private void IsRules()
        {
            regole.TopMost = true;  // così la form4 rimane visibile anche quando interagisco con la form1
            regole.Show();
        }

        //public static SoundPlayer CaricaSuono(string p)
        //{
        //    if (!File.Exists(p))
        //    {
        //        MessageBox.Show("Errore nel caricare il suono", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }

        //    SoundPlayer mySound = new SoundPlayer(p);
        //    return mySound;
        //}

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = CaricaImmagine("baule_aperto.png");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = CaricaImmagine("baule_chiuso.png");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Sienna;

            if (cont == 0)
            {
                AudioPlayer.CaricaAudio("board.wav");
                AudioPlayer.PlayAudio();

                pictureBox6.Enabled = false;
                pictureBox6.Visible = false;

                label2.ForeColor = Color.MediumBlue;
                if (Form4.Italiano)
                {
                    label2.Text = "Viking's turn!";
                    label4.Text = "fight!";
                }
                else
                {
                    label2.Text = "turno del vichingo!";
                    label4.Text = "spacca!";
                }
            }

            if (cont > -1)
            {
                if (cont != 0)
                    label4.Text = cont.ToString();
                cont -= 1;
            }

            else
            {
                gioca = true;
                pictureBox7.Visible = true;

                secondiTrascorsi++;
                if (secondiTrascorsi == 60)
                {
                    minutiTrascorsi++;
                    secondiTrascorsi = 0;
                }

                TimerAggiornato();
            }
        }

        private void ResetTimer()
        {
            minutiTrascorsi = 0;
            secondiTrascorsi = 0;

            TimerAggiornato();

            if (timer1.Enabled)
                timer1.Stop();

            timer1.Start();
        }

        private void TimerAggiornato()
        {
            label4.Text = $"{minutiTrascorsi:D2} : {secondiTrascorsi:D2}";
        }
    }
}
