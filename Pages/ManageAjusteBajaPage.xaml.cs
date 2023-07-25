using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;

[QueryProperty(nameof(AjusteBajaVM), "AjusteBajaVM")]

public partial class ManageAjusteBajaPage : ContentPage
{
    private readonly IRestDataService _dataService;
    AjusteBajaVM _ajusteBajaVM;
    int _inventarioCantidadOriginal;

    public AjusteBajaVM AjusteBajaVM
    {
        get => _ajusteBajaVM;
        set
        {
            _ajusteBajaVM = value;
            OnPropertyChanged();
        }
    }

    public ManageAjusteBajaPage(IRestDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
    }

    protected async override void OnAppearing()
    {
        _inventarioCantidadOriginal = AjusteBajaVM.Cantidad.Value;
        base.OnAppearing();
        var allEnumerados = await _dataService.GetAllEnumeradosAsync();
        var causales = allEnumerados.Where(p => p.Padre == 13);
        causalPicker.ItemsSource = causales.ToList();

    }

    void PickerOpciones()
    {
        //int selectedIndex = causalPicker.SelectedIndex;
        //var causalId = Int32.Parse(causalPicker.Items[selectedIndex].ToString());        
        if (causalPicker.SelectedItem != null)
        {
            dynamic selectedCausal = causalPicker.SelectedItem;
            var causalId = selectedCausal.Id;
            _ajusteBajaVM.CausalId = causalId;
        }
        _ajusteBajaVM.FechaDocumento = fechaDocumentoPicker.Date;
        //Debug.WriteLine(causalId);       
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {

        PickerOpciones();
        if (_ajusteBajaVM.CantidadAfectada <= _inventarioCantidadOriginal)
        {
            Debug.WriteLine("!!! Baja realizándose");
            await _dataService.AddAjusteBaja(AjusteBajaVM);
            var toast = Toast.Make("Baja raelizada.");
            await toast.Show();

            await Shell.Current.Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync(nameof(InventariosPage));
        }
        else
        {   var toast = Toast.Make("CANTIDAD PASA EL STOCK");
            await toast.Show();
            _ajusteBajaVM.CantidadAfectada = _inventarioCantidadOriginal;
        }



    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync("..");
    }
}