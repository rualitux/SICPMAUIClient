using ToDoMauiClient2.DataServices;

namespace ToDoMauiClient2.Pages;

public partial class AjustesPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public AjustesPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _dataService.GetAllAjustesAsync();

    }

    async void OnMenuPrincipalClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }

}