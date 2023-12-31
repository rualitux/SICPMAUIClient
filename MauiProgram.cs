﻿using CommunityToolkit.Maui;
using ToDoMauiClient2.DataServices;
using ToDoMauiClient2.Pages;

namespace ToDoMauiClient2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		//builder.Services.AddSingleton<IRestDataService, RestDataService>();
		builder.Services.AddHttpClient<IRestDataService, RestDataService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ProcedimientosPage>();
        builder.Services.AddSingleton<AreasPage>();
        builder.Services.AddSingleton<BienesPage>();
        builder.Services.AddSingleton<InventariosPage>();
        builder.Services.AddSingleton<AjustesPage>();
        builder.Services.AddTransient<ManageToDoPage>();
        builder.Services.AddTransient<ManageAreasPage>();
        builder.Services.AddTransient<ManageBienesPage>();
        builder.Services.AddTransient<ManageBienProcedimientoAltasPage>();
        builder.Services.AddTransient<ManageInventariosPage>();
        builder.Services.AddTransient<ManageAjusteBajaPage>();




        return builder.Build();
	}
}
