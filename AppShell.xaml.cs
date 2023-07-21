using ToDoMauiClient2.Models;
using ToDoMauiClient2.Pages;

namespace ToDoMauiClient2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
        Routing.RegisterRoute(nameof(ManageAreasPage), typeof(ManageAreasPage));
        Routing.RegisterRoute(nameof(ManageBienesPage), typeof(ManageBienesPage));
        Routing.RegisterRoute(nameof(ManageBienProcedimientoAltasPage), typeof(ManageBienProcedimientoAltasPage));
        Routing.RegisterRoute(nameof(ProcedimientosPage), typeof(ProcedimientosPage));
        Routing.RegisterRoute(nameof(AreasPage), typeof(AreasPage));
        Routing.RegisterRoute(nameof(BienesPage), typeof(BienesPage));



    }
}
