using System.Collections.Generic;
using System.Linq;
using com.ksgames.rpgcore.abstractions.inventory;
using com.ksgames.rpgcore.inventory.extscripts;
using HeroEditor.Common.Data;
using UnityEngine;

namespace com.ksgames.services.store
{
    [CreateAssetMenu(fileName = "StoreItemsCollection", menuName = "IDLER/Store Items Collection")]
    public class StoreItemsCollection : ScriptableObject
    {
        [Header("Main")] 
        public List<IconCollection> IconCollections;
        public List<StoreItemParams> Items;

        public static StoreItemsCollection Active;

        private Dictionary<string, ItemSprite> _itemSprites;
        private Dictionary<string, ItemIcon> _itemIcons;
        
        public void Reset()
        {
            _itemSprites = null;
            _itemIcons = null;
        }
        
        private Dictionary<string, ItemIcon> CacheIcons()
        {
            var dict = new Dictionary<string, ItemIcon>();

            foreach (var icon in IconCollections.SelectMany(i => i.Icons))
            {
                if (!dict.ContainsKey(icon.Id))
                {
                    dict.Add(icon.Id, icon);
                }
            }

            return dict;
        }
        

        public void Refresh()
        {
            UpdateListView();
        }
        
        private void UpdateListView()
        {
            HashSet<string> seenIDs = new HashSet<string>();
            foreach (var item in Items)
            {
                item.Name = $"[{item.ItemType.ToString()}.{item.Id}";
                if (seenIDs.Contains(item.Id))
                {
                    Debug.LogWarning($"Дубликат ID найден: {item.Id} у {item.Name}");
                }
                else
                {
                    seenIDs.Add(item.Id);
                }
            }
            Items = Items.OrderBy(x => x.Name).ToList();
        }
    }
}