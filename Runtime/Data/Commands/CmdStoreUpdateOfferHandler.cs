using System.Linq;
using com.ksgames.core.architect;
using com.ksgames.core.architect.collections.store;

namespace com.ksgames.services.store.commands
{
    public class CmdStoreUpdateOfferHandler: ICommandHandler<CmdStoreUpdateOffer>
    {
        private Store _store;
        // private HeroService _heroService;HeroService
        // private ResourcesService _resourcesService; 


        public CmdStoreUpdateOfferHandler(Store store/*, HeroInventoryService heroService, ResourcesService resourcesService*/)
        {
            _store = store;
            // _heroService = heroService;
            // _resourcesService = resourcesService;
        }
        
        public bool Handle(CmdStoreUpdateOffer command)
        {
            var storeItem = _store.Offers.FirstOrDefault(x=> x.ID.Value == command.Offer.productId);

            if (storeItem == null) return false;
            
            storeItem.StorePriceText.Value = command.Offer.localizedPriceString;

            if ((storeItem.State.Value is StoreItemState.UNPURCHASED or StoreItemState.PURCHASING) && command.Offer.isPurchased)
            {
                ApplyOffer(storeItem);
            }
            
            storeItem.State.Value = command.Offer.isPurchased? StoreItemState.PURCHASED:StoreItemState.UNPURCHASED;

            return true;
        }
        
        private bool ApplyOffer(StoreItem offer)
        {
            // foreach (var proxyItem in offer.Items)
            // {
            //     if (!proxyItem.IsManaBall)
            //         _heroService.InventoryService.AddItem(proxyItem);
            //     else
            //     {
            //         _heroService.AddMana();
            //     }
            // }
            //     
            // foreach (var resource in offer.Rewards)
            // {
            //     _resourcesService.AddResource(resource.ResourceType, resource.Amount.Value);
            // }
            //
            return true;
        }
    }
}