using AppControleFinanceiro.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _db;
        private const string collectionName = "transactions";

        public TransactionRepository(LiteDatabase db)
        {
            _db = db;
        }
        public void Add(Transaction transaction)
        {
            var collection = _db.GetCollection<Transaction>(collectionName);
            collection.Insert(transaction);
            collection.EnsureIndex(t => t.DateCriaction);
        }

        public List<Transaction> GetAll()
        {
            return _db.GetCollection<Transaction>(collectionName).Query().OrderByDescending(t => t.DateCriaction).ToList();
        }
        public void Update(Transaction transaction)
        {
            _db.GetCollection<Transaction>(collectionName).Update(transaction);
        }
        public void Delete(int id)
        {
            _db.GetCollection<Transaction>(collectionName).Delete(id);
        }
    }
}
