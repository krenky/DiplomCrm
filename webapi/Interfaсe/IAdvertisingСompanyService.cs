using webapi.Models;

namespace webapi.Interfaсe
{
    public interface IAdvertisingСompanyService
    {
        Task<AdvertisingСompany> Create(AdvertisingСompany сompany);
        Task<IEnumerable<AdvertisingСompany>> GetList();

        Task<AdvertisingСompany> Change(AdvertisingСompany сompany);
    }
}