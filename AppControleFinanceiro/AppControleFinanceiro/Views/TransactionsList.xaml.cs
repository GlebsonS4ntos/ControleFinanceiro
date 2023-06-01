namespace AppControleFinanceiro.Views;

public partial class TransactionsList : ContentPage
{
	public TransactionsList()
	{
		InitializeComponent();
	}
	private void GoToCreateTransaction(Object sender, EventArgs args)
	{
		App.Current.MainPage = new CreateTransaction();
	}
}