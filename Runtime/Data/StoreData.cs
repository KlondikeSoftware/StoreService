using System.Collections.Generic;
using com.ksgames.core.abstractions.persistence;
using com.ksgames.core.abstractions.persistence.enums;
using com.ksgames.core.architect.collections.store;

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
        public void UpdateData()
        {
        }
    }
}