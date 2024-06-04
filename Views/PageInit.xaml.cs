namespace PM0220242P.Views;

public partial class PageInit : ContentPage
{
	FileResult photo;
	public PageInit()
	{
		InitializeComponent();
	}

	public String GetImage64()
	{
        String Base64 = String.Empty;

        if (photo != null)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				Stream stream = photo.OpenReadAsync().Result;
				stream.CopyTo(ms);
				byte[] data = ms.ToArray();

				Base64 = Convert.ToBase64String(data);
				return Base64;
			}
		}
		return Base64;
	}

    public byte[] GetImageArray()
    {
		byte[] data = new byte[] {};
        if (photo != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                data = ms.ToArray();

                return data;
            }
        }
        return data;
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

    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
		photo = await MediaPicker.Default.CapturePhotoAsync();

		if (photo != null) 
		{
			string Localizacion = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
		}
    }
}