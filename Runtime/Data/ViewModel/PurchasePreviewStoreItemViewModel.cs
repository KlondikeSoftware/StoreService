using System;
using com.ksgames.core.uitools;
using com.ksgames.rpgcore.gameresources.viewmodel;
using com.ksgames.services.purchasingservice;
using Lukomor.MVVM;
using Lukomor.Reactive;

namespace com.ksgames.services.store.viewmodel
{
    public class PurchasePreviewStoreItemViewModel: IViewModel
    {

        private StoreItem _storeItem;
        // private HeroService _heroService;
        // private ResourcesService _resourcesService;
        private CorePurchasingService _purchasingService;
        // public UIPreviewHeroViewModel Hero { get; set; }
        
        public ReactiveProperty<string> Caption { get; set; }
        public ReactiveCollection<UIItemViewModel> Items { get; set; } =new ReactiveCollection<UIItemViewModel>();
        // private ReactiveCollection<Item> _items { get; set; }
        public ReactiveCollection<ResourceViewModel> Resources { get; set; } = new ReactiveCollection<ResourceViewModel>();
        // public ReactiveCollection<Resource> _resources { get; set; }
        
        public ButtonViewModel BuyButton { get; set; }

        private Action<StoreItem> _onConfirm;
        
        public PurchasePreviewStoreItemViewModel(StoreItem storeItem/*, HeroService heroService, Action<StoreItem> OnBuyCallback*/)
        {
            
            // _onConfirm = OnBuyCallback;
            _storeItem = storeItem;
            
            BuyButton = new ButtonViewModel(OnBuyButtonClick, "OnPurchaseBtnClick");
            BuyButton.Caption.Value = storeItem.StorePriceText.Value;
            // BuyButton.Enable.Value = false;
            Caption = new Lukomor.Reactive.ReactiveProperty<string>(storeItem.Caption);
            // _items = new ReactiveCollection<Item>(storeItem.Items);
            // _items.Added.Subscribe(x =>
            // {
            //     Items.Add(new UIItemViewModel(x));
            // });
            // _resources = new ReactiveCollection<Resource>(storeItem.Rewards);
            // _resources.Added.Subscribe(x =>
            // {
            //     Resources.Add(new ResourceViewModel(x));
            // });
            // Hero =  new UIPreviewHeroViewModel(_items, heroService.Look);
        }

        private void OnBuyButtonClick()
        {
            _onConfirm.Invoke(_storeItem);
         
            
           
        }
        
    }
}