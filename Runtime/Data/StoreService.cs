using System;
using System.Linq;
using System.Reactive.Linq;
using com.ksgames.core.architect;
using com.ksgames.services.purchasingservice;
using com.ksgames.services.store.commands;
using Lukomor.Reactive;

namespace com.ksgames.services.store
{
    public class StoreService
    {
        

        private CorePurchasingService _purchasingService;
        private ICommandProcessor _cmd;
        
        public Store _origin { get; set; }
        public ReactiveCollection<StoreItem> ActiveOffers = new ReactiveCollection<StoreItem>();
        public ReactiveProperty<bool> InProgress = new (false);
        
        
        

        public StoreService(Store store,  CorePurchasingService purchasingService, GenericCommandProcessor<StoreData> cmd)
        {
            _origin = store;
            _cmd = cmd;
            _purchasingService = purchasingService;
            _purchasingService.UpdatedProduct.Subscribe(OnProductUpdate);
            _purchasingService.AllProducts.Added.Subscribe(OnProductUpdate);
        }

        private void OnProductUpdate(OfferItem offerItem)
        {
            var command = new CmdStoreUpdateOffer(offerItem);
            _cmd.Process(command);

            UpdateActiveProducts();
        }
        
        private void UpdateActiveProducts()
        {
            var allUnPurchasedProducts = _origin.Offers.ToList().FindAll(x=> x.State.Value != StoreItemState.PURCHASED && x.ItemType == StoreItemType.Purchase).OrderBy(x=>x.OrderNumber).Take(Math.Min(3, _origin.Offers.Count));
            var allRewardedOffers = _origin.Offers.ToList().FindAll(x=> x.ItemType == StoreItemType.Rewarded).Take(1);
            
            var offersList = allUnPurchasedProducts.Concat(allRewardedOffers);
            offersList.OrderBy(x => x.OrderNumber);

            ActiveOffers.Clear();

            foreach (var offer in offersList)
            {
                ActiveOffers.Add(offer);
            }
            
        }

       

        public void BuyOffer(StoreItem offer)
        {
            if (InProgress.Value) return;
            
            var offerCode = offer.ID.Value;
            InProgress.Set(true);
            
            _purchasingService.TryToByOffer(offerCode).Skip(1).Take(1).Subscribe(result =>
            {
                InProgress.Set(false); 
            });
        }

        public StoreItem DefeatOffer()
        {
            return _origin.Offers.ToList().FindAll(x=> x.State.Value != StoreItemState.PURCHASED && x.ItemType == StoreItemType.Purchase).OrderBy(x=>x.OrderNumber).FirstOrDefault();
        }
    }
}