using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;


[QueryProperty(nameof(Area), "Area")]

public partial class ManageAreasPage : ContentPage
{
    private readonly IRestDataService _dataService;
    Area _area;
    bool _isNew;

    public Area Area
    {
        get => _area;
        set
        {
            _isNew = IsNew(value);
            _area = value;
            OnPropertyChanged();
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var allEnumerados = await _dataService.GetAllEnumeradosAsync();
        var sedes = allEnumerados.Where(p => p.Padre == 14);
        var dependecias = allEnumerados.Where(p => p.Padre == 15);
        sedePicker.ItemsSource = sedes.ToList();
        dependenciaPicker.ItemsSource = dependecias.ToList();
    }



    public ManageAreasPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService = dataService;
		BindingContext = this;
	}

    bool IsNew(Area area)
    {
        if (area.Id == 0)
        {
            return true;
        }
        return false;
    }
    void CausalSelected()
    {
        //int selectedIndex = causalPicker.SelectedIndex;
        //var causalId = Int32.Parse(causalPicker.Items[selectedIndex].ToString());        
        if (sedePicker.SelectedItem != null)
        {
            dynamic selectedSede = sedePicker.SelectedItem;
            var sedeId = selectedSede.Id;
            _area.SedeId = sedeId;
        }
        if (dependenciaPicker.SelectedItem != null)
        {
            dynamic selectedDependencia = dependenciaPicker.SelectedItem;
            var dependenciaId = selectedDependencia.Id;
            _area.DependenciaId = dependenciaId;
        }           
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            CausalSelected();
            _area.FechaRegistro = DateTime.Now;
            _area.EstadoAreaId = 7;
            Debug.WriteLine("!!! Agregar nuevo procedimiento");
            await _dataService.AddAreaAsync(Area);
        }
        else
        {
            CausalSelected();
            Debug.WriteLine("!!! Actualizar nuevo procedimiento");
            await _dataService.UpdateAreaAsync(Area);


        }
        await Shell.Current.GoToAsync("..");

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteToDoAsync(Area.Id);
        await Shell.Current.GoToAsync("..");
    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync("..");
    }



}