using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class SalesStagesSevice
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerHistoryService _customerHistoryService;

        public SalesStagesSevice(ApplicationDbContext context, ICustomerHistoryService customerHistoryService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _customerHistoryService = customerHistoryService;
        }
        public void AddStage(SalesStages stages)
        {
            _context.SalesStages.Add(stages);
            _context.SaveChanges();
        }
    }
}
