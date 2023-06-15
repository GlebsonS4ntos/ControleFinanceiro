using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionsList : ContentPage
{
	private readonly ITransactionRepository _transactionRepository;
	public TransactionsList(ITransactionRepository transactionRepository)
	{
		_transactionRepository = transactionRepository;
		InitializeComponent();
		Reload();
		WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
		{
			Reload();
		});
	}
	private void Reload()
	{
        ViewListTransaction.ItemsSource = _transactionRepository.GetAll();
    }

	private void GoToCreateTransaction(Object sender, EventArgs args)
	{
		var page = Handler.MauiContext.Services.GetService<CreateTransaction>();
		Navigation.PushModalAsync(page);
	}

    private void GoToUpdateTransaction(object sender, EventArgs e)
    {
        var page = Handler.MauiContext.Services.GetService<CreateTransaction>();
        Navigation.PushModalAsync(page);
    }
}