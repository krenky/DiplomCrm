using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;
using webapi.Utils;

namespace webapi.Controllers
{
    [Route("api/landing/[controller]")]
    [ApiController]
    public class LandingController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public LandingController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> RegisterCustomerWithOrder(RegisterCustomer registerCustomer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            Customer customer = new Customer();
            RepairOrder repairOrder = new RepairOrder();
            try
            {
                customer = _context.Customer.Add(new Customer()
                {
                    FirstName = registerCustomer.FirstName,
                    LastName = registerCustomer.LastName,
                    Phone = "0",
                    Email = registerCustomer.Email,
                    Birthdate = registerCustomer.Birtdate.Year<1000 ? DateTime.Now : DateTime.Now,
                }).Entity;

                _context.SaveChanges();
                Device device = _context.Device.Add(new Device()
                {
                    Name = registerCustomer.PhoneModel,
                    Manufacturer = registerCustomer.Manufacturer,
                    ModelDevice = "undef",
                    SerialNumber = "undef"
                }).Entity;

                repairOrder = _context.RepairOrders.Add(new RepairOrder()
                {
                    //Customer = customer,
                    CustomerId = customer.Id,
                    Device = device,
                    DeviceId = device.Id,
                    Description = registerCustomer.Comment,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    SalesStagesId = 1,
                    AdvertisingСompanyId = registerCustomer.Code.Id
                }).Entity;
                _context.SaveChanges();

                //await _emailService.SendEmailAsync(customer.Email, "sdf", $"Номер вашей заявки: {repairOrder.Id}");

                return customer;
            }
            catch
            {
                return BadRequest();
            }
            

            
        }

        [HttpPost("registerold")]
        public async Task<ActionResult<Customer>> RegisterOldCustomerWithOrder(RegisterOldCustomer registerCustomer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            Customer customer = _context.Customer.FirstOrDefault(x => x.Email == registerCustomer.Email);
            var listOrder = _context.RepairOrders.Where(x => x.CustomerId == customer.Id);
            RepairOrder repairOrder = new RepairOrder();
            try
            {
                Device device = _context.Device.Add(new Device()
                {
                    Name = registerCustomer.PhoneModel,
                    Manufacturer = registerCustomer.Manufacturer,
                    ModelDevice = "undef",
                    SerialNumber = "undef"
                }).Entity;

                repairOrder = _context.RepairOrders.Add(new RepairOrder()
                {
                    //Customer = customer,
                    CustomerId = customer.Id,
                    Device = device,
                    DeviceId = device.Id,
                    Description = registerCustomer.Comment,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    SalesStagesId = 1,
                    AdvertisingСompanyId = registerCustomer.Code?.Id,
                    LoyaltyDiscount = listOrder.Count() >= 3
                }).Entity;
                _context.SaveChanges();

                //await _emailService.SendEmailAsync(customer.Email, "sdf", $"Номер вашей заявки: {repairOrder.Id}");

                return customer;
            }
            catch
            {
                return BadRequest();
            }



        }

        [HttpGet("getbirthday")]
        public async Task<ActionResult<bool>> GetIsBirthday(string email)
        {
            var customer = _context.Customer.FirstOrDefault(x => x.Email == email);
            if (customer == null)
            {
                return NotFound();
            }
            DateOnly dateOnly = customer.Birthdate.ToDateOnly();
            DateOnly now = DateTime.UtcNow.ToDateOnly();
            if (dateOnly.Day == now.Day && dateOnly.Month == now.Month)
            {
                return true;
            }
            return false;
        }
    }
}
