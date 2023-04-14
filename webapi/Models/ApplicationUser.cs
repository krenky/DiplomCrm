using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public class ApplicationUser : IdentityUser
    {
    }
    public enum Role
    {
        SystemAdministrator,
        Administrator,
        Operator,
        Manager,
        HeadOfSales,
        MarketingSpecialist,
        HeadOfService,      //руководитель сервиса
        ServiceManger       //сервис-менеджер
    }
}