using ShippingService.Models;

namespace ShippingService.Data
{
    public class ShippingRepo : IShipping
    {
        private readonly AppDbContext _context;

        public ShippingRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateInVoice(InVoice inVo)
        {
            if (inVo == null)
                throw new ArgumentNullException(nameof(inVo));
            _context.inVoices.Add(inVo);
        }

        public void CreateShipping(int inVoiceId, Shipping shipping)
        {
            if (shipping == null)
                throw new ArgumentNullException(nameof(shipping));

            shipping.InVoiceId = inVoiceId;
            _context.Shippings.Add(shipping);
        }

        public bool ExternalInVoiceExist(int externalInVoiceId)
        {
            return _context.inVoices.Any(p => p.ExternalID == externalInVoiceId);
        }

        public IEnumerable<InVoice> GetAllInVoices()
        {
            return _context.InVoices.ToList();
        }

        public Shipping GetShipping(int inVoiceId, int shippingId)
        {
            return _context.Shippings.Where(c => c.InVoiceId == inVoiceId &&
                c.Id == shippingId).FirstOrDefault();
        }

        public Shipping GetShippingForInVoice(int inVoiceId)
        {
            return _context.Shippings.FirstOrDefault(c => c.InVoiceId == inVoiceId);
        }

        public bool InVoiceExist(int inVoiceId)
        {
            return _context.inVoices.Any(p => p.Id == inVoiceId);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
