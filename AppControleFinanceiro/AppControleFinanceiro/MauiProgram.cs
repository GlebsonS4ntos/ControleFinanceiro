using AppControleFinanceiro.Repositories;
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
			}).RegisterDataBaseAndRepositories();

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
}
