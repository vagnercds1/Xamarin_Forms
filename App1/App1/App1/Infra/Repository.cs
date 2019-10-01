using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App1.Infra
{
    public class Repository<T> : IRepository<T> where T : class, IEntityObject, new()
    { 
        public bool Insert(T entity, string nomeBase)
        {
            var affectedItens = DataBaseService.Conexao(nomeBase).Insert(entity);

            return affectedItens == 1;
        }

        public bool InsertList(List<T> entity, string nomeBase)
        {
            var affectedItens = DataBaseService.Conexao(nomeBase).InsertAll(entity);

            return affectedItens == 1;
        }

        public int Save(T entity, string nomeBase)
        {
            var affectedItens = 0;
            try
            {
                if (entity.Id == 0)
                    affectedItens = DataBaseService.Conexao(nomeBase).Insert(entity);
                else
                    affectedItens = DataBaseService.Conexao(nomeBase).Update(entity);
            }
            catch (Exception ex)
            {

            }

            return affectedItens;
        }

        public bool Delete(T entity, string nomeBase)
        {
            int affectedItens = DataBaseService.Conexao(nomeBase).Delete(entity);

            return affectedItens == 1;
        }

        public T Get(int id, string nomeBase)
        {
            return DataBaseService.Conexao(nomeBase).Get<T>(id);
        }

        public T GetWithChildren(string nomeBase, int id, bool recursive = false)
        {
            return DataBaseService.Conexao(nomeBase).GetWithChildren<T>(id, recursive);
        }

        public T Find(Expression<Func<T, bool>> predicate, string nomeBase)
        {
            return DataBaseService.Conexao(nomeBase).Find<T>(predicate);
        }

        public T FindWithChildren(string nomeBase, Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            var element = DataBaseService.Conexao(nomeBase).Find<T>(predicate);
            if (element == null)
                return null;

            DataBaseService.Conexao(nomeBase).GetChildren(element, recursive);

            return element;
        }

        public IEnumerable<T> Collection(string nomeBase, Func<T, bool> predicate = null)
        {
            return predicate == null ? DataBaseService.Conexao(nomeBase).Table<T>() : DataBaseService.Conexao(nomeBase).Table<T>().Where(predicate);
        }

        public IEnumerable<T> Collection(string nomeBase, Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            return DataBaseService.Conexao(nomeBase).GetAllWithChildren(predicate, recursive);
        } 
    }
}
