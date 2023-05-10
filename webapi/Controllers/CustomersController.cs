using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService customerService;

        public CustomersController(ApplicationDbContext context, ICustomerService service)
        {
            _context = context;
            customerService = service;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            try
            {
                return await customerService.GetCustomers();
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                return await customerService.GetCustomer(id);
            }
            catch(ArgumentException ex)
            {
                NotFound();
                throw ex;
            };
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, Customer customer)
        {
            try
            {
                customer.Id = id;
                return await customerService.ChangeCustomer(customer);
            }
            catch (ArgumentException)
            {
                return BadRequest();
                throw;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
                throw;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try
            {
                Customer addingCustomer = await customerService.AddCustomer(customer);
                return Ok(addingCustomer);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
                
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound(id);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
