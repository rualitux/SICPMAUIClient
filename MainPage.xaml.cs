using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;
using ToDoMauiClient2.Pages;

namespace ToDoMauiClient2;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public MainPage(IRestDataService dataService)
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
    async void OnProcedimientosClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton A Procedimientos");        
        await Shell.Current.GoToAsync(nameof(ProcedimientosPage));

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

