using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;

public partial class AreasPage : ContentPage

{
    private readonly IRestDataService _dataService;

    public AreasPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _dataService.GetAllAreasAsync();

    }

    async void OnAddAreasClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton agregar clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Area), new Area() }
        };
        await Shell.Current.GoToAsync(nameof(ManageAreasPage), navegationParameter);

    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("!!! Item changed clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Area), e.CurrentSelection.FirstOrDefault() as Area}
        };
        await Shell.Current.GoToAsync(nameof(ManageAreasPage), navegationParameter);

    }

}