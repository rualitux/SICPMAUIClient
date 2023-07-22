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
        await Shell.Current.GoToAsync(nameof(BienesPage));

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        PickerOpciones();
        Debug.WriteLine("!!! Nuevo Bien desde Alta");
        //Postea y recibe del Api el bien posteado
        var bienPosteado = await _dataService.AddBienAsync(BienPatrimonial);
        //crea un bien nuevo a partir de bienPosteado con la información que se desea mantener
        //en la siguiente alta
        var bienNavigation = BienNavigation(bienPosteado);
        
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(BienPatrimonial), bienNavigation }
        };
        await Shell.Current.GoToAsync(nameof(ManageBienesPage), navegationParameter);


    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync(nameof(BienesPage));
    }


    public BienPatrimonial BienNavigation(BienPatrimonial bienPosteado)
    {
        var bienNavigation = new BienPatrimonial();
        if (checkProce.IsChecked)
        {
            bienNavigation.ProcedimientoId = bienPosteado.ProcedimientoId;
        }
        if (checkCategoria.IsChecked)
        {
            bienNavigation.CategoriaId = bienPosteado.CategoriaId;
        }
        if (checkDenominacion.IsChecked)
        {
            bienNavigation.Denominacion = bienPosteado.Denominacion;
        }
        if (checkMarca.IsChecked)
        {
            bienNavigation.Marca = bienPosteado.Marca;
        }
        if (checkModelo.IsChecked)
        {
            bienNavigation.Modelo = bienPosteado.Modelo;
        }
        if (checkSerie.IsChecked)
        {
            bienNavigation.Serie = bienPosteado.Serie;
        }
        if (checkColor.IsChecked)
        {
            bienNavigation.Color = bienPosteado.Color;
        }
        if (checkObservacion.IsChecked)
        {
            bienNavigation.Observacion = bienPosteado.Observacion;
        }
        return bienNavigation;
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