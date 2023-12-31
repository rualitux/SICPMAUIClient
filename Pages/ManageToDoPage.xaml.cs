using Microsoft.Maui.Controls;
using System.Diagnostics;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.Pages;
[QueryProperty(nameof(Procedimiento), "Procedimiento")]
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;
	Procedimiento _procedimiento;
	bool _isNew;


    public Procedimiento Procedimiento
    {
		get => _procedimiento;
		set 
		{
			_isNew = IsNew(value);    
            _procedimiento = value;
			OnPropertyChanged();
		}
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		var allEnumerados = await _dataService.GetAllEnumeradosAsync();
		var causales = allEnumerados.Where(p => p.Padre == 13);
        var tipoProcedimientos = allEnumerados.Where(p => p.Padre == 12);
        causalPicker.ItemsSource = causales.ToList();
        procedimientoPicker.ItemsSource = tipoProcedimientos.ToList();
    }

    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService = dataService;
		BindingContext = this;
    }
	bool IsNew(Procedimiento procedimiento)
	{ 
		if(procedimiento.Id == 0) 
		{
			return true;
		}
		return false;
	}
	void CausalSelected()
	{
		//int selectedIndex = causalPicker.SelectedIndex;
		//var causalId = Int32.Parse(causalPicker.Items[selectedIndex].ToString());        
		if (causalPicker.SelectedItem != null)
		{ 
		dynamic selectedCausal = causalPicker.SelectedItem;
		var causalId = selectedCausal.Id;
        _procedimiento.CausalId = causalId;
        }
		if (procedimientoPicker.SelectedItem != null)
		{
            dynamic selectedProcedimientoTipo = procedimientoPicker.SelectedItem;
            var procedimientoId = selectedProcedimientoTipo.Id;
            _procedimiento.ProcedimientoTipoId = procedimientoId;
        }
        _procedimiento.FechaDocumento = fechaDocumentoPicker.Date;
        //Debug.WriteLine(causalId);       
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		if (_isNew)
		{
			CausalSelected();
			_procedimiento.FechaRegistro = DateTime.Now;
			Debug.WriteLine("!!! Agregar nuevo procedimiento");
			await _dataService.AddToDoAsync(Procedimiento);
		}
		else
		{
            CausalSelected();
            Debug.WriteLine("!!! Actualizar nuevo procedimiento");
            await _dataService.UpdateToDoAsync(Procedimiento);


        }
        await Shell.Current.GoToAsync("..");

    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
        CausalSelected();
        _procedimiento.FechaRegistro = DateTime.Now;
        Debug.WriteLine("!!! Agregar nuevo procedimiento");
        await _dataService.AddToDoAsync(Procedimiento);
		var navegationParameter = new Dictionary<string, object>
		{
			{nameof(BienPatrimonial), new BienPatrimonial(){
			ProcedimientoId = _procedimiento.Id
			} }
        };
        await Shell.Current.GoToAsync(nameof(ManageBienesPage), navegationParameter);

    }
	async void ONCancelButtonClicked(object sender, EventArgs e)
	{
		//Como subir un nivel como en cli
		await Shell.Current.GoToAsync("..");
	}
}