using AppControleFinanceiro.Views;

namespace AppControleFinanceiro;

public partial class App : Application
{
	public App(TransactionsList transactionsList)
	{
		InitializeComponent();

		MainPage = new NavigationPage(transactionsList);

    }
}
