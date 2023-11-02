using ApiApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Core.Specifications
{
    public class BaseSepcification<T> : ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrdersBy { get; set; }
        public Expression<Func<T, object>> OrdersByDescending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaganationEnabled { get; set; }

        public BaseSepcification()
        {
            
        }

        public BaseSepcification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddOrderBy(Expression<Func<T, object>> ordersBy)
        {
            OrdersBy = ordersBy;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrdersByDescending = orderByDescending;
        }

        public void ApplyPagination(int skip, int take)
        {
            IsPaganationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
