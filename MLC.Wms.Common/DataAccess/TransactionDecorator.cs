using System.Data;
using System.Diagnostics.Contracts;
using NHibernate;
using NHibernate.Transaction;

namespace MLC.Wms.Common.DataAccess
{
    public class TransactionDecorator : ITransaction
    {
        readonly ITransaction _transaction;

        /// <summary>
        /// Признак того, что вызовы Begin, Commit, Rollback, Dispose не нужно передавать в декорируемый объект
        /// </summary>
        public bool DisableActions { get; set; }

        public TransactionDecorator(ITransaction transaction)
        {
            Contract.Requires(transaction != null);

            _transaction = transaction;
            DisableActions = true;
        }

        public void Begin()
        {
            if (!DisableActions)
                _transaction.Begin();
        }

        public void Begin(IsolationLevel isolationLevel)
        {
            if (!DisableActions)
                _transaction.Begin(isolationLevel);
        }

        public void Commit()
        {
            if (!DisableActions)
                _transaction.Commit();
        }

        public void Rollback()
        {
            if (!DisableActions)
                _transaction.Rollback();
        }

        public void Enlist(IDbCommand command)
        {
            _transaction.Enlist(command);
        }

        public void RegisterSynchronization(ISynchronization synchronization)
        {
            _transaction.RegisterSynchronization(synchronization);
        }

        public bool IsActive
        {
            get { return _transaction.IsActive; }
        }

        public bool WasRolledBack
        {
            get { return _transaction.WasRolledBack; }
        }

        public bool WasCommitted
        {
            get { return _transaction.WasCommitted; }
        }

        public void Dispose()
        {
            if (!DisableActions)
                _transaction.Dispose();
        }
    }
}