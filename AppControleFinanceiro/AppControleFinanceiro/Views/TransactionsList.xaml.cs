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
		double despesas = 0;
		double receitas = 0;
		var itens = _transactionRepository.GetAll();
		ViewListTransaction.ItemsSource = itens;
		foreach(var item in itens)
		{
			if (item.Type == Enum.TransactionType.Income)
			{
				receitas += item.Value;
			}
			else
			{
				despesas += item.Value;
			}
		}
		LabelGasto.Text = despesas.ToString("C");
		LabelReceita.Text = receitas.ToString("C");

		LabelSaldo.Text = (receitas - despesas).ToString("C");

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