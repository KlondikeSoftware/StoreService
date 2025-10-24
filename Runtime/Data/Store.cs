using System;
using com.ksgames.core.architect.collections.store;
using Lukomor.Reactive;

namespace com.ksgames.services.store
{
    public class Store
    {
        public ReactiveProperty<bool> HasNewItem = new ReactiveProperty<bool>();
        public ReactiveCollection<StoreItem> Offers= new ReactiveCollection<StoreItem>();

        public Store(StoreData storeData)
        {
            HasNewItem = new ReactiveProperty<bool>(storeData.HasNewItem);
            
            storeData.StoreItems.ForEach( x=> Offers.Add(new StoreItem(x)));
            
            Offers.Removed.Subscribe(x => storeData.StoreItems.Remove(x.Origin));
            
        }
    }
}