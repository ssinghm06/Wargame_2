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
            //Application.Run(new Form2());  // ho creato una nuova finestra 'form2.cs' dove faccio la schermata di avvio 
            Application.Run(new Form1());
        }
    }
}