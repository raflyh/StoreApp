using ShippingService.Models;

namespace ShippingService.Data
{
    public interface IShipping
    {
        bool SaveChange();

        //InVoice
        IEnumerable<InVoice> GetAllInVoices();
        void CreateInVoice(InVoice inVo);
        bool InVoiceExist(int inVoiceId);
        bool ExternalInVoiceExist(int externalInVoiceId);

        //Shipping
        Shipping GetShippingForInVoice(int inVoiceId);
        Shipping GetShipping(int inVoiceId, int shippingId);
        void CreateShipping(int inVoiceId, Shipping shipping);
    }
}
