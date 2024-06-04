namespace PM0220242P.Views;

public partial class PageListPerson : ContentPage
{
	public PageListPerson()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Views.PageInit page = new PageInit();
        Navigation.PushAsync(page);
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }

    private void listperson_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        listperson.ItemsSource = await App.DataBase.GetListPersons();
    }
}