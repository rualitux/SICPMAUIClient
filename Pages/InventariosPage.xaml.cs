using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;

public partial class InventariosPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public InventariosPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _dataService.GetAllInventariosAsync();
    }

    async void OnAddInventarioClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton agregar clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Inventario), new Inventario() }
        };
        await Shell.Current.GoToAsync(nameof(ManageInventariosPage), navegationParameter);

    }

    async void OnAddAltaClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton alta clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(BienProcedimientoAlta), new BienProcedimientoAlta() }
        };
        await Shell.Current.GoToAsync(nameof(ManageBienProcedimientoAltasPage), navegationParameter);

    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("!!! Item changed clickeado");
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Inventario), e.CurrentSelection.FirstOrDefault() as Inventario}
        };
        await Shell.Current.GoToAsync(nameof(ManageInventariosPage), navegationParameter);

    }

}