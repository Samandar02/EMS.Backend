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
    public class ManagmenstsController : ControllerBase
    {
        public AppDbContexts _context = null;
        public ManagmenstsController(AppDbContexts contexts)
        {
            _context = contexts;
        }
        // GET api/Employee
        
        [HttpGet]
        public ActionResult<IEnumerable<Managment>> Get()
        {
            return _context.Managments.ToList();
        }

        // GET api/Employee/5
        
        [HttpGet("{id}")]
        public ActionResult<Managment> Get(int id)
        {
            return _context.Managments.SingleOrDefault(m => m.id == id);
        }
        // POST api/Employee
        [HttpPost]
        public void Post([FromBody] Managment m)
        {
            _context.Managments.Add(m);
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
