using System.Drawing.Text;

namespace Wargame_vv2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Thread thread = new Thread(Musica);
            //thread.Start();

            //void Musica()
            //{
            //    AudioPlayer.CaricaAudioInLoop("backTest.wav");
            //}

            Application.Run(new Form2());  // ho creato una nuova finestra 'form2.cs' dove faccio la schermata di avvio 
            Application.Run(new Form1());
        }
    }
}