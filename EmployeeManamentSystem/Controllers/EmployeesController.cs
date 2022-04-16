using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhileLearnAsp.NetCoreApp.Contexts;
using WhileLearnAsp.NetCoreApp.Models;

namespace WhileLearnAsp.NetCoreApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public AppDbContexts _context = null;
        public EmployeesController(AppDbContexts contexts)
        {
            _context = contexts;
        }
        // GET api/Employee
        
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return _context.Employees.ToList();
        }

        // GET api/Employee/5
        
        [HttpGet("{managment_id}")]
        public ActionResult<IEnumerable<Employee>> Get(int managment_id)
        {
            return _context.Employees.Where(emp => emp.Managment_id == managment_id).ToList();
        }
        // POST api/Employee
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
