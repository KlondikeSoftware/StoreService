using System;
using System.Collections.Generic;
using System.Linq;
using com.ksgames.rpgcore.abstractions.gameresources;
using com.ksgames.rpgcore.inventory.extscripts.data;
using NUnit.Framework.Internal;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

namespace com.ksgames.services.store
{
    [Serializable]
    public enum StoreItemType
    {
        Rewarded,
        Purchase,
    }
    
    [Serializable]
    public class StoreItemParams
    {
        [Header("Main Settings")]
        public string Name;
        public string Id;
        public StoreItemType ItemType;
        public OSPlatform.ProductType ProductType;
        public int SortingIndex;
        
        [Header("Reward Settings")] 
        public List<IGameResourceData> RewardCurrencies;
        public List<string> RewardItems = new List<string>();
        
        
        [Header("Addition Settings")] 
        public string Meta;
        public List<LocalizedValue> Localization = new List<LocalizedValue>();
        

        // public Lukomor.MVVM.View Prefab;
        
        // public StoreItemParams()
        // {
        //     Name = waveItemSettings.name;
        //     Id = waveItemSettings.name;
        //     Prefab = waveItemSettings.Prefab;
        // }


        public string GetLocalizedName(LocalizationType type, string language)
        {
            var localized = Localization.SingleOrDefault(i => i.Language == language && i.localizationType == type) ??
                            Localization.SingleOrDefault(i => i.Language == "English" && i.localizationType == type);

            return localized == null ? Id : localized.Value;
        }

        public MetaData MetaToList()
        {
            // return Meta.IsEmpty() ? new MetaData() : JsonUtility.FromJson<MetaData>(Meta);
            return new MetaData();
        }
    }
}