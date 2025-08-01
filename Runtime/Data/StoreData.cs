using System.Collections.Generic;
using com.ksgames.services.persistenceservice;
using Lukomor.Reactive;

namespace com.ksgames.services.store
{
    public class StoreData: IGameData
    {
        public List<StoreItemData> StoreItems;
        public bool HasNewItem;

        public StoreData(List<StoreItemData> storeItems)
        {
            StoreItems = storeItems;
        }

        public GameStateEnum State { get; }
    }
}