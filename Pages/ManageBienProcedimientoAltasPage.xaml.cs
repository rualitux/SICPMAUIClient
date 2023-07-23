using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;
[QueryProperty(nameof(BienProcedimientoAlta), "BienProcedimientoAlta")]

public partial class ManageBienProcedimientoAltasPage : ContentPage
{
    private readonly IRestDataService _dataService;
    BienProcedimientoAlta _bienProcedimientoAlta;
    bool _isNew;


    public BienProcedimientoAlta BienProcedimientoAlta
    {
        get => _bienProcedimientoAlta;
        set
        {
            _isNew = IsNew(value);
            _bienProcedimientoAlta = value;
            OnPropertyChanged();
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var allEnumerados = await _dataService.GetAllEnumeradosAsync();
        var causales = allEnumerados.Where(p => p.Padre == 13);
        var tipoProcedimientos = allEnumerados.Where(p => p.Padre == 12);
        var categorias = allEnumerados.Where(p => p.Padre == 11);
        //var procedimientos = allProcedimientos.Where(p => p.ProcedimientoTipoId == 10);
        causalPicker.ItemsSource = causales.ToList();
        categoriaPicker.ItemsSource = categorias.ToList();
        procedimientoPicker.ItemsSource = tipoProcedimientos.ToList();
    }

    public ManageBienProcedimientoAltasPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService=dataService;
        BindingContext = this;

    }

    void PickerOpciones()
    {
        //int selectedIndex = causalPicker.SelectedIndex;
        //var causalId = Int32.Parse(causalPicker.Items[selectedIndex].ToString());        
        if (causalPicker.SelectedItem != null)
        {
            dynamic selectedCausal = causalPicker.SelectedItem;
            var causalId = selectedCausal.Id;
            _bienProcedimientoAlta.CausalId = causalId;
        }
        if (procedimientoPicker.SelectedItem != null)
        {
            dynamic selectedProcedimientoTipo = procedimientoPicker.SelectedItem;
            var procedimientoId = selectedProcedimientoTipo.Id;
            _bienProcedimientoAlta.ProcedimientoTipoId = procedimientoId;
        }
        if (categoriaPicker.SelectedItem != null)
        {
            dynamic selectedCategoria = categoriaPicker.SelectedItem;
            var categoriaId = selectedCategoria.Id;
            _bienProcedimientoAlta.CategoriaId = categoriaId;
        }
        _bienProcedimientoAlta.FechaDocumento = fechaDocumentoPicker.Date;
        //Debug.WriteLine(causalId);       
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            PickerOpciones();
            _bienProcedimientoAlta.FechaRegistro = DateTime.Now;
            Debug.WriteLine("!!! Agregar nueva Alta");
            await _dataService.AddBienProcedimientoAlta(BienProcedimientoAlta);
        }
        //else
        //{
        //    PickerOpciones();
        //    Debug.WriteLine("!!! Actualizar nueva Alta (Improbable, me da pereza borrar)");
        //    await _dataService.UpdateToDoAsync(Procedimiento);


        //}
        await Shell.Current.GoToAsync("..");

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        PickerOpciones();
        Debug.WriteLine("!!! Nuevo Inventario desde Alta");
        //Postea y recibe del Api el bien posteado
        var bienProcData = await _dataService.AddBienProcedimientoAlta(BienProcedimientoAlta);
        //crea un bien nuevo a partir de bienPosteado con la información que se desea mantener
        //en la siguiente alta
        var inventarioNavigation = new Inventario()
        {
            BienPatrimonialId = bienProcData.BienId,
            BienPatrimonialString = bienProcData.BienString,
            ProcedimientoId = bienProcData.ProcedimientoId,
            ProcedimientoString = bienProcData.ProcedimientoString
        };
        var navegationParameter = new Dictionary<string, object>
        {
            {nameof(Inventario), inventarioNavigation }
        };
        await Shell.Current.GoToAsync(nameof(ManageInventariosPage), navegationParameter);



    }
    async void ONCancelButtonClicked(object sender, EventArgs e)
    {
        //Como subir un nivel como en cli
        await Shell.Current.GoToAsync("..");
    }









    bool IsNew(BienProcedimientoAlta bienProcedimientoAlta)
    {
        return true;
    }
}