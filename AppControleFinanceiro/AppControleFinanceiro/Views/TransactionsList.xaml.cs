namespace AppControleFinanceiro.Views;

public partial class TransactionsList : ContentPage
{
	private readonly CreateTransaction _createTransaction;
	private readonly UpdateTransaction _updateTransaction;
	public TransactionsList(CreateTransaction createTransaction, UpdateTransaction updateTransaction)
	{
		_createTransaction = createTransaction;
		_updateTransaction = updateTransaction;
		InitializeComponent();
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