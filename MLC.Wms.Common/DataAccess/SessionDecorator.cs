using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Stat;
using NHibernate.Type;

namespace MLC.Wms.Common.DataAccess
{
    public class SessionDecorator : ISession
    {
        private readonly ISession _session;
        
        /// <summary>
        /// Признак того, что вызов Dispose не нужно передавать в декорируемый объект
        /// </summary>
        public bool DoNotDispose { get; set; }

        /// <summary>
        /// Транзакция, управляемая извне (будет возвращаться на BeginTransaction и Transaction_get)
        /// </summary>
        public ITransaction ExternalTransaction { get; set; }

        public SessionDecorator(ISession session)
        {
            Contract.Requires(session != null);

            _session = session;
        }

        public virtual void Dispose()
        {
            if (!DoNotDispose)
                _session.Dispose();
        }

        public virtual void Flush()
        {
            _session.Flush();
        }

        public virtual IDbConnection Disconnect()
        {
            return _session.Disconnect();
        }

        public virtual void Reconnect()
        {
            _session.Reconnect();
        }

        public virtual IDbConnection Close()
        {
            return _session.Close();
        }

        public virtual void CancelQuery()
        {
            _session.CancelQuery();
        }

        public virtual bool IsDirty()
        {
            return _session.IsDirty();
        }

        public virtual bool IsReadOnly(object entityOrProxy)
        {
            return _session.IsReadOnly(entityOrProxy);
        }

        public virtual void SetReadOnly(object entityOrProxy, bool readOnly)
        {
            _session.SetReadOnly(entityOrProxy, readOnly);
        }

        public virtual object GetIdentifier(object obj)
        {
            return _session.GetIdentifier(obj);
        }

        public virtual bool Contains(object obj)
        {
            return _session.Contains(obj);
        }

        public virtual void Evict(object obj)
        {
            _session.Evict(obj);
        }

        public virtual object Load(string entityName, object id, LockMode lockMode)
        {
            return _session.Load(entityName, id, lockMode);
        }

        public virtual T Load<T>(object id, LockMode lockMode)
        {
            return _session.Load<T>(id, lockMode);
        }

        public virtual T Load<T>(object id)
        {
            return _session.Load<T>(id);
        }

        public virtual object Load(string entityName, object id)
        {
            return _session.Load(entityName, id);
        }

        public virtual void Load(object obj, object id)
        {
            _session.Load(obj, id);
        }

        public virtual void Replicate(object obj, ReplicationMode replicationMode)
        {
            _session.Replicate(obj, replicationMode);
        }

        public virtual void Replicate(string entityName, object obj, ReplicationMode replicationMode)
        {
            _session.Replicate(entityName, obj, replicationMode);
        }

        public virtual object Save(object obj)
        {
            return _session.Save(obj);
        }

        public virtual void Save(object obj, object id)
        {
            _session.Save(obj, id);
        }

        public virtual object Save(string entityName, object obj)
        {
            return _session.Save(entityName, obj);
        }

        public virtual void Save(string entityName, object obj, object id)
        {
            _session.Save(entityName, obj, id);
        }

        public virtual void SaveOrUpdate(object obj)
        {
            _session.SaveOrUpdate(obj);
        }

        public virtual void SaveOrUpdate(string entityName, object obj)
        {
            _session.SaveOrUpdate(entityName, obj);
        }

        public virtual void SaveOrUpdate(string entityName, object obj, object id)
        {
            _session.SaveOrUpdate(entityName, obj, id);
        }

        public virtual void Update(object obj)
        {
            _session.Update(obj);
        }

        public virtual void Update(object obj, object id)
        {
            _session.Update(obj, id);
        }

        public virtual void Update(string entityName, object obj)
        {
            _session.Update(entityName, obj);
        }

        public virtual void Update(string entityName, object obj, object id)
        {
            _session.Update(entityName, obj, id);
        }

        public virtual object Merge(object obj)
        {
            return _session.Merge(obj);
        }

        public virtual object Merge(string entityName, object obj)
        {
            return _session.Merge(entityName, obj);
        }

        public virtual T Merge<T>(T entity) where T : class
        {
            return _session.Merge(entity);
        }

        public virtual T Merge<T>(string entityName, T entity) where T : class
        {
            return _session.Merge(entityName, entity);
        }

        public virtual void Persist(object obj)
        {
            _session.Persist(obj);
        }

        public virtual void Persist(string entityName, object obj)
        {
            _session.Persist(entityName, obj);
        }

        public virtual void Delete(object obj)
        {
            _session.Delete(obj);
        }

        public virtual void Delete(string entityName, object obj)
        {
            _session.Delete(entityName, obj);
        }

        public virtual int Delete(string query)
        {
            return _session.Delete(query);
        }

        public virtual int Delete(string query, object value, IType type)
        {
            return _session.Delete(query, value, type);
        }

        public virtual int Delete(string query, object[] values, IType[] types)
        {
            return _session.Delete(query, values, types);
        }

        public virtual void Lock(object obj, LockMode lockMode)
        {
            _session.Lock(obj, lockMode);
        }

        public virtual void Lock(string entityName, object obj, LockMode lockMode)
        {
            _session.Lock(entityName, obj, lockMode);
        }

        public virtual void Refresh(object obj)
        {
            _session.Refresh(obj);
        }

        public virtual void Refresh(object obj, LockMode lockMode)
        {
            _session.Refresh(obj, lockMode);
        }

        public virtual LockMode GetCurrentLockMode(object obj)
        {
            return _session.GetCurrentLockMode(obj);
        }

        public virtual ITransaction BeginTransaction()
        {
            if (ExternalTransaction != null)
                return ExternalTransaction;

            return _session.BeginTransaction();
        }

        public virtual ICriteria CreateCriteria<T>() where T : class
        {
            return _session.CreateCriteria<T>();
        }

        public virtual ICriteria CreateCriteria<T>(string alias) where T : class
        {
            return _session.CreateCriteria<T>(alias);
        }

        public virtual ICriteria CreateCriteria(string entityName)
        {
            return _session.CreateCriteria(entityName);
        }

        public virtual ICriteria CreateCriteria(string entityName, string alias)
        {
            return _session.CreateCriteria(entityName, alias);
        }

        public virtual IQueryOver<T, T> QueryOver<T>() where T : class
        {
            return _session.QueryOver<T>();
        }

        public virtual IQueryOver<T, T> QueryOver<T>(string entityName) where T : class
        {
            return _session.QueryOver<T>(entityName);
        }

        public virtual IQuery CreateQuery(string queryString)
        {
            return _session.CreateQuery(queryString);
        }

        public virtual IQuery CreateFilter(object collection, string queryString)
        {
            return _session.CreateFilter(collection, queryString);
        }

        public virtual IQuery GetNamedQuery(string queryName)
        {
            return _session.GetNamedQuery(queryName);
        }

        public virtual ISQLQuery CreateSQLQuery(string queryString)
        {
            return _session.CreateSQLQuery(queryString);
        }

        public virtual void Clear()
        {
            _session.Clear();
        }

        public virtual object Get(string entityName, object id)
        {
            return _session.Get(entityName, id);
        }

        public virtual T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public virtual T Get<T>(object id, LockMode lockMode)
        {
            return _session.Get<T>(id, lockMode);
        }

        public virtual string GetEntityName(object obj)
        {
            return _session.GetEntityName(obj);
        }

        public virtual IFilter EnableFilter(string filterName)
        {
            return _session.EnableFilter(filterName);
        }

        public virtual IFilter GetEnabledFilter(string filterName)
        {
            return _session.GetEnabledFilter(filterName);
        }

        public virtual void DisableFilter(string filterName)
        {
            _session.DisableFilter(filterName);
        }

        public virtual IMultiQuery CreateMultiQuery()
        {
            return _session.CreateMultiQuery();
        }

        public virtual ISession SetBatchSize(int batchSize)
        {
            return _session.SetBatchSize(batchSize);
        }

        public virtual ISessionImplementor GetSessionImplementation()
        {
            return _session.GetSessionImplementation();
        }

        public virtual IMultiCriteria CreateMultiCriteria()
        {
            return _session.CreateMultiCriteria();
        }

        public virtual ISession GetSession(EntityMode entityMode)
        {
            return _session.GetSession(entityMode);
        }

        public virtual EntityMode ActiveEntityMode
        {
            get { return _session.ActiveEntityMode; }
        }

        public virtual FlushMode FlushMode
        {
            get { return _session.FlushMode; }
            set { _session.FlushMode = value; }
        }

        public virtual CacheMode CacheMode
        {
            get { return _session.CacheMode; }
            set { _session.CacheMode = value; }
        }

        public virtual ISessionFactory SessionFactory
        {
            get { return _session.SessionFactory; }
        }

        public virtual IDbConnection Connection
        {
            get { return _session.Connection; }
        }

        public virtual bool IsOpen
        {
            get { return _session.IsOpen; }
        }

        public virtual bool IsConnected
        {
            get { return _session.IsConnected; }
        }

        public virtual bool DefaultReadOnly
        {
            get { return _session.DefaultReadOnly; }
            set { _session.DefaultReadOnly = value; }
        }

        public virtual ITransaction Transaction
        {
            get
            {
                if (ExternalTransaction != null)
                    return ExternalTransaction;

                return _session.Transaction;
            }
        }

        public virtual ISessionStatistics Statistics
        {
            get { return _session.Statistics; }
        }

        public virtual object Get(Type clazz, object id, LockMode lockMode)
        {
            return _session.Get(clazz, id, lockMode);
        }

        public virtual object Get(Type clazz, object id)
        {
            return _session.Get(clazz, id);
        }

        public virtual IQueryOver<T, T> QueryOver<T>(string entityName, Expression<Func<T>> alias) where T : class
        {
            return _session.QueryOver<T>(entityName, alias);
        }

        public virtual IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class
        {
            return _session.QueryOver(alias);
        }

        public virtual ICriteria CreateCriteria(Type persistentClass, string alias)
        {
            return _session.CreateCriteria(persistentClass, alias);
        }

        public virtual ICriteria CreateCriteria(Type persistentClass)
        {
            return _session.CreateCriteria(persistentClass);
        }

        public virtual ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (ExternalTransaction != null)
                return ExternalTransaction;

            return _session.BeginTransaction(isolationLevel);
        }

        public virtual object Load(Type theType, object id)
        {
            return _session.Load(theType, id);
        }

        public virtual object Load(Type theType, object id, LockMode lockMode)
        {
            return _session.Load(theType, id, lockMode);
        }

        public virtual void Reconnect(IDbConnection connection)
        {
            _session.Reconnect(connection);
        }
    }
}
