using System.Collections.Generic;
using com.ksgames.services.persistenceservice;

namespace com.ksgames.services.store
{
    public class StoreData: IGameState
    {
        public List<StoreItemData> StoreItems;
        public bool HasNewItem;

        public StoreData(List<StoreItemData> storeItems)
        {
            StoreItems = storeItems;
        }
    }
}