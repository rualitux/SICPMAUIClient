using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;

public partial class ProcedimientosPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public ProcedimientosPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
    }
    async void OnAddToDoClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton agregar clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Procedimiento), new Procedimiento() }
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navegationParameter);

    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("!!! Item changed clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Procedimiento), e.CurrentSelection.FirstOrDefault() as Procedimiento}
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navegationParameter);

    }
}
