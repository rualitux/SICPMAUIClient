using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;


[QueryProperty(nameof(BienPatrimonial), "BienPatrimonial")]

public partial class ManageBienesPage : ContentPage
{
    private readonly IRestDataService _dataService;
    BienPatrimonial _bienPatrimonial;
    bool _isNew;

    public BienPatrimonial BienPatrimonial
    {
        get => _bienPatrimonial;
        set
        {
            _isNew = IsNew(value);
            _bienPatrimonial = value;
            OnPropertyChanged();
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var allEnumerados = await _dataService.GetAllEnumeradosAsync();
        var allProcedimientos = await _dataService.GetAllToDosAsync();
        var categorias = allEnumerados.Where(p => p.Padre == 11);
        //var procedimientos = allProcedimientos.Where(p => p.ProcedimientoTipoId == 10);
        categoriaPicker.ItemsSource = categorias.ToList();
        procedimientoPicker.ItemsSource = allProcedimientos.ToList();
    }

    public ManageBienesPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService=dataService;
        BindingContext = this;
    }

    void PickerOpciones()
    {       
        if (categoriaPicker.SelectedItem != null)
        {
            dynamic selectedCategoria = categoriaPicker.SelectedItem;
            var categoriaId = selectedCategoria.Id;
            _bienPatrimonial.CategoriaId = categoriaId;
        }
        if (procedimientoPicker.SelectedItem != null)
        {
            dynamic selectedProcedimiento = procedimientoPicker.SelectedItem;
            var procedimientoId = selectedProcedimiento.Id;
            _bienPatrimonial.ProcedimientoId = procedimientoId;
        }        
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            PickerOpciones();
            Debug.WriteLine("!!! Agregar nuevo procedimiento");
            await _dataService.AddBienAsync(BienPatrimonial);
        }
        else
        {
            PickerOpciones();
            Debug.WriteLine("!!! Actualizar nuevo procedimiento");
            await _dataService.UpdateBienAsync(BienPatrimonial);
        }
        await Shell.Current.GoToAsync("..");

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        //await _dataService.DeleteToDoAsync(BienPatrimonial.Id);
        await Shell.Current.GoToAsync("..");
    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync("..");
    }



    bool IsNew(BienPatrimonial bienPatrimonial)
    {
        if (bienPatrimonial.Id == 0)
        {
            return true;
        }
        return false;
    }



}