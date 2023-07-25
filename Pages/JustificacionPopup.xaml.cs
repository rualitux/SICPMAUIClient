using CommunityToolkit.Maui.Views;

namespace ToDoMauiClient2.Pages;

public partial class JustificacionPopup : Popup
{
    string justificacion;
	public JustificacionPopup()
	{
		InitializeComponent();
	}

    void OnJustificacionCompleted(object sender, EventArgs e)
    {
        justificacion = ((Entry)sender).Text;
    }
    void OnAgregarClicked(object sender, EventArgs e)
    {
        Close(justificacion);
    }
     void OnVolverClicked(object sender, EventArgs e)
    {
        justificacion = null;
        Close(justificacion);
    }


}