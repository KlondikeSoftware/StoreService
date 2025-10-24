using com.ksgames.core.architect.collections.store;
using com.ksgames.services.store;
using UnityEditor;
using UnityEngine;

namespace Assets.HeroEditor.Common.Scripts.Editor
{
    /// <summary>
    /// Add "Refresh" button to IconCollection script
    /// </summary>
    [CustomEditor(typeof(StoreItemsCollection))]
    public class StoreItemsCollectionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var collection = (StoreItemsCollection) target;

            if (GUILayout.Button("Refresh"))
            {
                collection.Refresh();
            }
        }
    }
}