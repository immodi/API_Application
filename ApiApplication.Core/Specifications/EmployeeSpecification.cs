using ApiApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Core.Specifications
{
    public class EmployeeSpecifications : BaseSepcification<Employee>
    {
        public EmployeeSpecifications()
        {
            Includes.Add(e => e.Department);
        }

        public EmployeeSpecifications(int id):base(e => e.Id == id)
        {
            Includes.Add(e => e.Department);
        }
    }
}
