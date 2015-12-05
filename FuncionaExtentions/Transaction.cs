using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    interface ITransaction : IDisposable
    {
        void Complete();
    }

    public enum TransactionState
    {
        Processing,
        Abandoned,
        Complete
    }

    class Transaction<T> : ITransaction
    {
        List<Lazy<T[]>> queue = new List<Lazy<T[]>>();
        List<Transaction<T>> children = new List<Transaction<T>>();
        TransactionState State { get;  set; }
        public void Complete()
        {
            throw new NotImplementedException();
        }


        void AddItem(T t)
        {
            var last = children.LastOrDefault(x => x.State == TransactionState.Processing);
            if(last != null)
            {
                last.AddItem(t);
            }
               }
        void BeginTransaction()
        {            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
