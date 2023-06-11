using Microsoft.AspNetCore.Mvc;
using webapi.Interfaсe;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingСompanyController : ControllerBase
    {
        private readonly IAdvertisingСompanyService advertisingСompanyservice;

        public AdvertisingСompanyController(IAdvertisingСompanyService advertisingСompanyservice)
        {
            this.advertisingСompanyservice = advertisingСompanyservice;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertisingСompany>> GetAdvertisingСompany()
        {
            try
            {
                return await advertisingСompanyservice.GetList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<AdvertisingСompany> AddAdvertisingСompany(AdvertisingСompany сompany)
        {
            try
            {
                return await advertisingСompanyservice.Create(сompany);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<AdvertisingСompany> ChangeAdvertisingСompany(int id, AdvertisingСompany сompany )
        {
            try
            {
                return await advertisingСompanyservice.Change(сompany);
            }
            catch
            {
                throw;
            }
        }

    }
}
