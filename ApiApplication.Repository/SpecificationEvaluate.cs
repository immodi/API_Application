using ApiApplication.Core.Models;
using ApiApplication.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Repository
{
    public static class SpecificationEvaluate<TEntity> where TEntity : BaseModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            if (specification.OrdersBy is not null)
            {
                query = query.OrderBy(specification.OrdersBy);
            }

            if (specification.OrdersByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrdersByDescending);
            }

            if (specification.IsPaganationEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.Includes.Aggregate(query, (currentQuery, IncludesExp) => currentQuery.Include(IncludesExp));

            return query;
        }
    }
}
