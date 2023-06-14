using AppControleFinanceiro.Repositories;
using AppControleFinanceiro.Views;
using LiteDB;

namespace AppControleFinanceiro;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).RegisterDataBaseAndRepositories().RegisterViews();

		return builder.Build();
	}

	private static MauiAppBuilder RegisterDataBaseAndRepositories(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<LiteDatabase>(opt =>
			{
				return new LiteDatabase($"FileName={AppSettings.PathDataBase};Connection=Shared");
			});
		builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
		return builder;
	}
	private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<CreateTransaction>();
        builder.Services.AddTransient<UpdateTransaction>();
        builder.Services.AddTransient<TransactionsList>();
        return builder;
	}
}
