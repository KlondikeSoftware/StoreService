using com.ksgames.rpgcore.abstractions.gameresources;
using com.ksgames.rpgcore.inventory.extscripts.data;
using Lukomor.Reactive;
using R3;

namespace com.ksgames.services.store
{
    public class StoreItem
    {

        public StoreItemData Origin { get; set; }
        public StoreItemType ItemType { get; }
        public R3.ReactiveProperty<StoreItemState> State { get; set; }
        public R3.ReactiveProperty<string> ID { get; set; }
        public ReactiveCollection<Item> Items { get; set; }
        public ReactiveCollection<IGameResource> Rewards { get; set; } = new();

        public R3.ReactiveProperty<string> StorePriceText { get; set; } = new("");
        public string Caption { get; set; }
        public int OrderNumber { get; set; }


        public StoreItem(StoreItemData storeItemData)
        {
            Origin = storeItemData;
            ItemType = storeItemData.StoreItemType;
            Caption = storeItemData.Caption;
            State = new R3.ReactiveProperty<StoreItemState>(storeItemData.state);
            ID = new(storeItemData.id);
            State.Subscribe(x => storeItemData.state = x);
            // Items = new ReactiveCollection<Item>(storeItemData.Items);
            OrderNumber = storeItemData.OrderPosition;
            // storeItemData.Resources.ForEach(x =>
            // {
                // Rewards.Add(new Resource(x));
            // });

        }
    }
    
}