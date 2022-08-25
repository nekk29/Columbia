﻿using $safesolutionname$.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace $safesolutionname$.Repository.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> IncludeProperties<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            includeProperties.ToList().ForEach(includeProperty =>
            {
                queryable = queryable.Include(includeProperty);
            });

            return queryable;
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return queryable.Where(filter);
        }

        public static IQueryable<TEntity> FilterByKey<TEntity>(this IQueryable<TEntity> queryable, params object[] keyValues)
        {
            if (keyValues == null)
                throw new Exception("Passed primary key values cannot be null");

            if (!keyValues.Any())
                throw new Exception("Passed primary key values cannot be empty");

            var keyProperties = typeof(TEntity).GetProperties().Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (!keyProperties.Any())
                throw new Exception("The entity has no primary key properties specified");

            if (keyValues.Length != keyProperties.Count())
                throw new Exception("Passed primary key values mismatch with primary key properties");

            var propertyKeyValueDictionary = new Dictionary<PropertyInfo, object>();

            for (int i = 0; i < keyProperties.Count(); i++)
                propertyKeyValueDictionary.Add(keyProperties.ToArray()[i], keyValues[i]);

            var accumulatedExpression = default(BinaryExpression);
            var parameterExpression = Expression.Parameter(typeof(TEntity), "entity");

            foreach (var propertyKeyValue in propertyKeyValueDictionary)
            {
                var equalExpression = Expression.Equal(
                    Expression.Property(parameterExpression, propertyKeyValue.Key),
                    Expression.Constant(propertyKeyValue.Value)
                );

                if (accumulatedExpression == null)
                    accumulatedExpression = equalExpression;
                else
                    accumulatedExpression = Expression.And(accumulatedExpression, equalExpression);
            }

            var where = accumulatedExpression != null ?
                Expression.Lambda<Func<TEntity, bool>>(accumulatedExpression, parameterExpression) : null;

            if (where != null)
                queryable = queryable.Where(where);

            return queryable;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            var p = a.Parameters[0];
            var visitor = new SubstExpressionVisitor();

            visitor.subst[b.Parameters[0]] = p;

            var body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));

            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            var p = a.Parameters[0];
            var visitor = new SubstExpressionVisitor();

            visitor.subst[b.Parameters[0]] = p;

            var body = Expression.OrElse(a.Body, visitor.Visit(b.Body));

            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static SortExpression<TEntity> GetSortExpression<TEntity>(string? direction, string? property)
        {
            if (string.IsNullOrEmpty(property)) return null!;

            var expression = GetSortExpression<TEntity>(property);
            if (expression == null) return null!;

            return new SortExpression<TEntity>
            {
                Direction = direction == "asc" ? SortDirection.Asc : SortDirection.Desc,
                Property = expression
            };
        }

        private static Expression<Func<TEntity, object>> GetSortExpression<TEntity>(string property)
        {
            var prop = typeof(TEntity).GetProperties().FirstOrDefault(x => x.Name.ToLower() == property.ToLower());
            if (prop == null) return null!;

            var parameterExpression = Expression.Parameter(typeof(TEntity), "entity");
            var propertyExpression = Expression.Property(parameterExpression, prop);

            return Expression.Lambda<Func<TEntity, object>>(Expression.Convert(propertyExpression, typeof(object)), parameterExpression);
        }
    }

    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = new();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (subst.TryGetValue(node, out Expression? newValue))
                return newValue;

            return node;
        }
    }
}
