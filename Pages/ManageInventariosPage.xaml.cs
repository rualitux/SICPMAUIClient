using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;

[QueryProperty(nameof(Inventario), "Inventario")]

public partial class ManageInventariosPage : ContentPage
{
    private readonly IRestDataService _dataService;
    Inventario _inventario;
    bool _isNew;

    public Inventario Inventario
    {
        get => _inventario;
        set
        {
            _isNew = IsNew(value);
            _inventario = value;
            OnPropertyChanged();
        }
    }

    public ManageInventariosPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if (_isNew)
        {
            if (Inventario.ProcedimientoId == null)
            {
                var allProcedimientos = await _dataService.GetAllToDosAsync();
                procedimientoPicker.IsVisible = true;
                procedimientoPicker.ItemsSource = allProcedimientos.ToList();

            }

            if (Inventario.BienPatrimonialId == null)
            {
                var allBienes = await _dataService.GetAllBienesAsync();
                bienPicker.IsVisible = true;
                bienPicker.ItemsSource = allBienes.ToList();
            }


            if (Inventario.AreaId == null)
            {
                var allAreas = await _dataService.GetAllAreasAsync();
                areaPicker.IsVisible = true;
                areaPicker.ItemsSource = allAreas.ToList();
            }
        }
        var allEnumerados = await _dataService.GetAllEnumeradosAsync();

        var anexos = allEnumerados.Where(p => p.Padre == 17);
        anexoPicker.ItemsSource = anexos.ToList();

        var condiciones = allEnumerados.Where(p => p.Padre == 18);
        condicionPicker.ItemsSource = condiciones.ToList();
    }

    void PickerOpcionesNuevo()
    {
        if (bienPicker.IsVisible && bienPicker.SelectedItem != null)
        {
            dynamic selectedBien = bienPicker.SelectedItem;
            var bienId = selectedBien.Id;
            _inventario.BienPatrimonialId = bienId;
        }
        if (procedimientoPicker.IsVisible && procedimientoPicker.SelectedItem != null)
        {
            dynamic selectedProcedimiento = procedimientoPicker.SelectedItem;
            var procedimientoId = selectedProcedimiento.Id;
            _inventario.ProcedimientoId = procedimientoId;
        }
        if (areaPicker.IsVisible && areaPicker.SelectedItem != null)
        {
            dynamic selectedArea = areaPicker.SelectedItem;
            var areaId = selectedArea.Id;
            _inventario.AreaId = areaId;
        }

    }

    void PickerOpciones()
    {
      
        if (anexoPicker.SelectedItem != null)
        {
            dynamic selectedAnexo = anexoPicker.SelectedItem;
            var anexoId = selectedAnexo.Id;
            _inventario.AnexoTipoId = anexoId;
        }
        if (condicionPicker.SelectedItem != null)
        {
            dynamic selectedCondicion = condicionPicker.SelectedItem;
            var condicionId = selectedCondicion.Id;
            _inventario.EstadoCondicionId = condicionId;
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            PickerOpcionesNuevo();
            PickerOpciones();
            Debug.WriteLine("!!! Agregar nuevo inventario");
            await _dataService.AddInventarioAsync(Inventario);
        }
        else
        {
            PickerOpciones();
            Debug.WriteLine("!!! Actualizar nuevo inventario");
            await _dataService.UpdateInventarioAsync(Inventario);
        }
        await Shell.Current.GoToAsync(nameof(InventariosPage));

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {       
        PickerOpcionesNuevo();
        PickerOpciones();
        Debug.WriteLine("!!! Nuevo Inventario desde Alta");
        //Postea y recibe del Api el bien posteado
        var inventarioPosteado = await _dataService.AddInventarioAsync(Inventario);
        //crea un bien nuevo a partir de bienPosteado con la información que se desea mantener
        //en la siguiente alta
        var inventarioNavigation = InventarioNavigation(inventarioPosteado);

        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Inventario), inventarioNavigation }
        };
        await Shell.Current.GoToAsync(nameof(ManageInventariosPage), navegationParameter);


    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync(nameof(InventariosPage));
    }


    public Inventario InventarioNavigation(Inventario inventarioPosteado)
    {
        var inventarioNavigation = new Inventario();
        if (checkBien.IsChecked)
        {
            inventarioNavigation.BienPatrimonialId = inventarioPosteado.BienPatrimonialId;
            inventarioNavigation.BienPatrimonialString = inventarioPosteado.BienPatrimonialString;

        }
        if (checkArea.IsChecked)
        {
            inventarioNavigation.AreaId = inventarioPosteado.AreaId;
            inventarioNavigation.AreaString = inventarioPosteado.AreaString;

        }
        if (checkProcedimiento.IsChecked)
        {
            inventarioNavigation.ProcedimientoId = inventarioPosteado.ProcedimientoId;
            inventarioNavigation.ProcedimientoString = inventarioPosteado.ProcedimientoString;

        }
        if (checkAnexo.IsChecked)
        {
            inventarioNavigation.AnexoTipoId = inventarioPosteado.AnexoTipoId;
            inventarioNavigation.AnexoTipoString = inventarioPosteado.AnexoTipoString;

        }
        if (checkCondicion.IsChecked)
        {
            inventarioNavigation.EstadoCondicionId = inventarioPosteado.EstadoCondicionId;
            inventarioNavigation.EstadoCondicionString = inventarioPosteado.EstadoCondicionString;

        }
        return inventarioNavigation;
    }

    bool IsNew(Inventario inventario)
    {
        if (inventario.Id == 0)
        {
            return true;
        }
        return false;
    }
}