using com.ksgames.core.architect;
using com.ksgames.services.purchasingservice;

namespace com.ksgames.services.store.commands
{
    public class CmdStoreUpdateOffer: ICommand
    {
        public CmdStoreUpdateOffer(OfferItem offer)
        {
            Offer = offer;
        }

        public OfferItem Offer { get; set; }
        
        
    }
}