using System;
using System.Collections.Generic;
using com.ksgames.rpgcore.abstractions.gameresources;
using com.ksgames.rpgcore.inventory.extscripts.data;

namespace com.ksgames.services.store
{
    [Serializable]
    public enum StoreItemState
    {
        PURCHASED,
        PURCHASING,
        UNPURCHASED,
    }
    
    public class StoreItemData
    {
        public string id;
        public StoreItemState state;
        public StoreItemType StoreItemType { get; set; }
        public List<Item> Items { get; set; }  = new List<Item>();
        public List<IGameResourceData> Resources { get; set; }
        public string Caption { get; set; }
        public int OrderPosition { get; set; }


        public StoreItemData(StoreItemParams settings)
        {
            id = settings.Id;
            Caption = settings.GetLocalizedName(LocalizationType.CAPTION, "English");
            state = StoreItemState.UNPURCHASED;
            StoreItemType = settings.ItemType;
            settings.RewardItems.ForEach(x=>Items.Add(new Item(x)));
            Resources = settings.RewardCurrencies;
            OrderPosition = settings.SortingIndex;
        }

        
    }
}