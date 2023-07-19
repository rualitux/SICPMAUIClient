using ToDoMauiClient2.Pages;

namespace ToDoMauiClient2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
        Routing.RegisterRoute(nameof(ProcedimientosPage), typeof(ProcedimientosPage));

    }
}
