namespace AppControleFinanceiro.Views;

public partial class CreateTransaction : ContentPage
{
	public CreateTransaction()
	{
		InitializeComponent();
	}

    private void BackToMainPage(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}