using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionsList : ContentPage
{
	private readonly CreateTransaction _createTransaction;
	private readonly UpdateTransaction _updateTransaction;
	private readonly ITransactionRepository _transactionRepository;
	public TransactionsList(CreateTransaction createTransaction, UpdateTransaction updateTransaction, ITransactionRepository transactionRepository)
	{
		_createTransaction = createTransaction;
		_updateTransaction = updateTransaction;
		_transactionRepository = transactionRepository;
		InitializeComponent();
		ViewListTransaction.ItemsSource = _transactionRepository.GetAll();
	}
	private void GoToCreateTransaction(Object sender, EventArgs args)
	{
		Navigation.PushModalAsync(_createTransaction);
	}

    private void GoToUpdateTransaction(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_updateTransaction);
    }
}