using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App1.Infra
{
    internal interface IRepository<T> where T : class
    {
        bool Insert(T entity, string nomeBase);
        int Save(T entity, string nomeBase);
        bool Delete(T entity, string nomeBase);

        T Get(int id, string nomeBase);


        T GetWithChildren(string nomeBase,int id, bool recursive = false);
        T Find(Expression<Func<T, bool>> predicate, string nomeBase);
        T FindWithChildren(string nomeBase, Expression<Func<T, bool>> predicate, bool recursive = false);
        IEnumerable<T> Collection(string nomeBase, Func<T, bool> predicate = null);
        IEnumerable<T> Collection(string nomeBase, Expression<Func<T, bool>> predicate = null, bool recursive = false);
    }
}
