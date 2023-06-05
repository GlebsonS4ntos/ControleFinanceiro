namespace AppControleFinanceiro.Views;

public partial class UpdateTransaction : ContentPage
{
	public UpdateTransaction()
	{
		InitializeComponent();
	}
    private void BackToMainPage(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}