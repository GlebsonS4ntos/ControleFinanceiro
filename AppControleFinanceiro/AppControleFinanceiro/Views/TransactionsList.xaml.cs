namespace AppControleFinanceiro.Views;

public partial class TransactionsList : ContentPage
{
	public TransactionsList()
	{
		InitializeComponent();
	}
	private void GoToCreateTransaction(Object sender, EventArgs args)
	{
		Navigation.PushModalAsync(new CreateTransaction());
	}

    private void GoToUpdateTransaction(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new UpdateTransaction());
    }
}