﻿using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;


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
                    Address = registerCustomer.Address,
                    Birthdate = registerCustomer.Birtdate
                }).Entity;

                Device device = _context.Device.Add(new Device()
                {
                    Name = registerCustomer.PhoneModel,
                    Manufacturer = "undef",
                    ModelDevice = "undef",
                    SerialNumber = "undef"
                }).Entity;

                repairOrder = _context.RepairOrder.Add(new RepairOrder()
                {
                    //Customer = customer,
                    CustomerId = customer.Id,
                    Device = device,
                    DeviceId = device.Id,
                    Description = registerCustomer.Comment,
                    Created = DateTime.Now
                }).Entity;
                _context.SaveChanges();

                await _emailService.SendEmailAsync("nazaroff.serezha2014@yandex.ru", "sdf", $"Номер вашей заявки: {repairOrder.Id}");

                return customer;
            }
            catch
            {
                return BadRequest();
            }
            

            
        }
    }
}
