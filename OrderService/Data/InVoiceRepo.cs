

using Microsoft.EntityFrameworkCore;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Data
{
    public class InVoiceRepo : IInVoiceRepo
    {
        private readonly AppDbContext _context;

        public InVoiceRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateInVoice(InVoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));
            _context.Add(invoice);
        }

        public IEnumerable<InVoice> GetAllInvoice()
        {
            return _context.InVoices.AsNoTracking().ToList();
        }

        public InVoice GetByName(string name)
        {
            return _context.InVoices.Where(s=>s.CodeInvoice.Contains(name)).FirstOrDefault();    
        }

        public InVoice GetOrderById(int id)
        {
            return _context.InVoices.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
