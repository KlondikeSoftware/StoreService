using System;
using com.ksgames.rpgcore.abstractions.gameresources;
using com.ksgames.rpgcore.gameresources.viewmodel;
using Lukomor.MVVM;
using Lukomor.Reactive;

namespace com.ksgames.services.store.viewmodel
{
    public class RewardedOfferPreviewViewModel: IViewModel
    {
       
        
        public ReactiveProperty<string> Caption { get; set; }
        // public ReactiveCollection<UIItemViewModel> Items { get; set; } =new ReactiveCollection<UIItemViewModel>();
        // private ReactiveCollection<Item> _items { get; set; }
        public ReactiveCollection<ResourceRewardViewModel> Resources { get; set; } = new ReactiveCollection<ResourceRewardViewModel>();
        // private ReactiveCollection<Resource> _resources { get; set; }

       
        
        // public ButtonViewModel BuyButton { get; set; }
        
        public RewardedOfferPreviewViewModel(StoreItem storeItem,Action<IGameResource> OnShowRewardCallback )
        {
            Caption = new ReactiveProperty<string>(storeItem.Caption);
            // _resources = new ReactiveCollection<Resource>(storeItem.Rewards);
            // _resources.Added.Subscribe(x =>
            // {
                // Resources.Add(new ResourceRewardViewModel(x,OnShowRewardCallback));
            // });
        }
        
        
    }
}