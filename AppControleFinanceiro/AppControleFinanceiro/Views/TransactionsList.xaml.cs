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

    private void GoToUpdateTransaction(object sender, EventArgs e)
    {
		App.Current.MainPage = new UpdateTransaction();
    }
}