using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;
using System.Text;

namespace AppControleFinanceiro.Views;

public partial class CreateTransaction : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;

	public CreateTransaction(ITransactionRepository repository)
	{
        _transactionRepository = repository;
		InitializeComponent();
	}

    private void BackToMainPage(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void Criar_Transaction(object sender, EventArgs e)
    {
        if (DataValidate())
        {
            Transaction transacao = new Transaction()
            {
                Name = TransactionName.Text,
                Value = Math.Abs(double.Parse(TransactionValue.Text)),
                DateCriaction = TransactionDate.Date,
                Type = RadioIncome.IsChecked ? Enum.TransactionType.Income : Enum.TransactionType.Expenses
            };
            _transactionRepository.Add(transacao);

            Navigation.PopModalAsync();

            WeakReferenceMessenger.Default.Send<string>("");

        }
    }

    private bool DataValidate()
    {
        bool validacao = true;
        StringBuilder stringBuilder = new StringBuilder();
        if (string.IsNullOrEmpty(TransactionName.Text) || string.IsNullOrWhiteSpace(TransactionName.Text))
        {
            stringBuilder.AppendLine("Verifique o Campo Nome !");
            validacao = false;
        }
        if (string.IsNullOrEmpty(TransactionValue.Text) || string.IsNullOrWhiteSpace(TransactionValue.Text))
        {
            stringBuilder.AppendLine("Verifique o campo Valor !");
            validacao = false;
        }
        if (!double.TryParse(TransactionValue.Text, out var resultado))
        {
            stringBuilder.AppendLine("Verifique se você digitou um Valor Valido!");
            validacao = false;
        }
        if (validacao == false) 
        {
            LabelErro.Text = stringBuilder.ToString();
            LabelErro.IsVisible = true;
        }
        
        return validacao;
    }
}