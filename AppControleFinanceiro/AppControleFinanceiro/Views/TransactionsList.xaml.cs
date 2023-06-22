using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;

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

    private void TapGestureRecognizer_Tapped_ToTrasactionEdit(object sender, TappedEventArgs e)
    {
		var grid = (Grid)sender;
		var gestureTap = (TapGestureRecognizer)grid.GestureRecognizers[0];
		var transaction = (Transaction) gestureTap.CommandParameter;
        var page = Handler.MauiContext.Services.GetService<UpdateTransaction>();
		page.SetTransactionForEdit(transaction);
        Navigation.PushModalAsync(page);
    }

    private async void TapGestureRecognizer_Tapped_To_Delete_Transaction(object sender, TappedEventArgs e)
    {
		var border = sender as Border;
		if(border == null)
		{
            var imageButton = sender as ImageButton;
            border = imageButton?.Parent as Border;
        }
		if(border != null)
		{
			await Animation_Icone_Delete(border, true);
		}

		bool result = await App.Current.MainPage.DisplayAlert("Excluir", "Você tem certeza que deseja Excluir a Transação ?", "Sim", "Não");
		if (result)
		{
			var transaction = (Transaction) e.Parameter;
			_transactionRepository.Delete(transaction.Id);
			Reload();
		}
		else
		{
			await Animation_Icone_Delete(border, false);
		}
    }
	private async Task Animation_Icone_Delete(Border border, bool deleteAnimation)
	{
        var imgDelete = (ImageButton)border.Content;
        if (deleteAnimation)
		{
			await border.RotateYTo(90, 150);
			imgDelete.Source = "close_red.png";
			await border.RotateYTo(180, 150);
		}
		else
		{
			await border.RotateYTo(90, 150);
            imgDelete.Source = "delete.png";
            await border.RotateYTo(0, 150);
        }
	}
}