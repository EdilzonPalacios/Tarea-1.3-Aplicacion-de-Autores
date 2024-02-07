namespace Tarea_1._3_Aplicacion_de_Autores
{
    public partial class App : Application
    {

        static Controllers.AutorController database;

        public static Controllers.AutorController Database
        { 
            get 
            {
                if (database == null)
                {
                    database = new Controllers.AutorController();
                }
                return database; 
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
