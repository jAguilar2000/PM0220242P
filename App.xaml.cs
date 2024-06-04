namespace PM0220242P
{
    public partial class App : Application
    {
        static Controllers.PersonasController? dbpersons;

        public static Controllers.PersonasController DataBase
        {
            get
            {
                if(dbpersons == null)
                {
                    dbpersons = new Controllers.PersonasController();
                }
                return dbpersons;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.PageListPerson());
        }
    }
}
