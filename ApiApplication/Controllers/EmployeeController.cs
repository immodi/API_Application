using ApiApplication.Core.Models;
using ApiApplication.Core.Repositories;
using ApiApplication.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.APIs.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeeController(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetAllEmployees()
        {
            var spec = new EmployeeSpecifications();
            var employees = _repository.GetAllWithSpecAsync(spec);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeWithId(int id)
        {
            var spec = new EmployeeSpecifications(id);
            var employees = _repository.GetIdWithSpecAsync(spec);
            return Ok(employees);
        }
    }
}
