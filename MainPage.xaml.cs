using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;
using ToDoMauiClient2.Pages;

namespace ToDoMauiClient2;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
    }

    async void OnProcedimientosClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton A Procedimientos");
        await Shell.Current.GoToAsync(nameof(ProcedimientosPage));

    }

    async void OnAreasClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton A Areas");
        await Shell.Current.GoToAsync(nameof(AreasPage));

    }

    async void OnBienesClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("!!! Boton A Bienes");
        await Shell.Current.GoToAsync(nameof(BienesPage));
    }
}

