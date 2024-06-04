namespace PM0220242P.Views;

public partial class PageInit : ContentPage
{
	public PageInit()
	{
		InitializeComponent();
	}

    private async void btnaceptar_Clicked(object sender, EventArgs e)
    {
		var person = new Models.Personas
		{
			Nombres = Nombres.Text,
			Apellidos = Apellidos.Text,
			FechaNac = FechaNac.Date,
			Telefono = Telefono.Text
		};

		if(await App.DataBase.StorePerson(person) > 0)
		{
			await DisplayAlert("Aviso", "Registron ingresado con éxito !!", "OK");
		}

    }
}