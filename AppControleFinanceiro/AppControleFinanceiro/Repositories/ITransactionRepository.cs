using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        void Delete(int id);
        List<Transaction> GetAll();
        void Update(Transaction transaction);
    }
}