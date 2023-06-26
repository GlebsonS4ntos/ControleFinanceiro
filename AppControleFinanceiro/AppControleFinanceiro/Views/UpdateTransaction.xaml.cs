using AppControleFinanceiro.Libraries.Utils.FixBugs;
using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;
using System.Text;

namespace AppControleFinanceiro.Views;

public partial class UpdateTransaction : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;
    private Transaction _transaction;
	public UpdateTransaction(ITransactionRepository repository)
	{
        _transactionRepository = repository;
		InitializeComponent();
	}
    public void SetTransactionForEdit(Transaction t)
    {
        _transaction = t;
        TransactionName.Text = t.Name;
        TransactionDate.Date = t.DateCriaction.Date;
        TransactionValue.Text = t.Value.ToString();
        if(t.Type == Enum.TransactionType.Income){
            RadioIncome.IsChecked = true;
        }
        else
        {
            RadioExpense.IsChecked = true;
        } 

    }
    private void BackToMainPage(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
        FixKeyboardBug.HideKeyboard();
    }
    private void Update_Transaction(object sender, EventArgs e)
    {
        if (DataValidate())
        {
            Transaction transacao = new Transaction()
            {
                Id = _transaction.Id,
                Name = TransactionName.Text,
                Value = Math.Abs(double.Parse(TransactionValue.Text)),
                DateCriaction = TransactionDate.Date,
                Type = RadioIncome.IsChecked ? Enum.TransactionType.Income : Enum.TransactionType.Expenses
            };
            _transactionRepository.Update(transacao);

            Navigation.PopModalAsync();

            WeakReferenceMessenger.Default.Send<string>("");
            FixKeyboardBug.HideKeyboard();
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