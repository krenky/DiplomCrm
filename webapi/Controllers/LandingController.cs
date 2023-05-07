using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;


namespace webapi.Controllers
{
    [Route("api/landing/[controller]")]
    [ApiController]
    public class LandingController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LandingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> RegisterCustomerWithOrder(RegisterCustomer registerCustomer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
            }

            Customer customer = _context.Customer.Add(new Customer() 
            { 
                FirstName = registerCustomer.FirstName,
                LastName = registerCustomer.LastName,
                Phone = "0",
                Email = registerCustomer.Email,
                Address = registerCustomer.Address,
                Birthdate = registerCustomer.Birtdate
            }).Entity;
            await _context.SaveChangesAsync();

            Device device = _context.Device.Add(new Device()
            {
                Name = registerCustomer.PhoneModel,
                Manufacturer = "undef",
                ModelDevice = "undef",
                SerialNumber = "undef"
            }).Entity;
            await _context.SaveChangesAsync();

            _context.RepairOrder.Add(new RepairOrder()
            {
                //Customer = customer,
                CustomerId = customer.Id,
                Device = device,
                DeviceId = device.Id,
                Description = registerCustomer.Comment,
                Created = DateTime.Now
            });
            _context.SaveChanges();

            return  customer;
        }
    }
}
