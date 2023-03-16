using BlogProjectApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Employees.Add(employee);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
             using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var delete = c.Employees.FirstOrDefault(x => x.ID == id);
            if (delete == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(delete);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var update = c.Employees.FirstOrDefault(x => x.ID == employee.ID);
            if (update == null)
            {
                return NotFound();
            }
            else
            {
                update.Name = employee.Name;
                c.Update(update);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
