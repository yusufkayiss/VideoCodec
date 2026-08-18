namespace VideoCodec
{
    // Uygulamanın başlatıcı sınıfı (sadece proje içinde erişilebilir ve bellekte tekil tutulur)
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // WinForms ve arayüz bileşenlerinin (dosya seçici diyalogları vb.) çökmeden çalışmasını sağlayan iş parçacığı modeli.
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Ekran ölçekleme (DPI), varsayılan font ve görsel stilleri başlatır.
            ApplicationConfiguration.Initialize();

            // Ana Form1 penceresini ekrana getirir ve uygulamanın mesaj döngüsünü çalıştırır.
            Application.Run(new Form1());
        }
    }
}