using System.Collections.Generic;
using com.ksgames.services.store.viewmodel;
using Lukomor.MVVM;
using Lukomor.MVVM.Binders;
using UnityEngine;

namespace com.ksgames.services.store.binders
{
    public class PreviewStoreItemVMlToGameObjectList : ObservableCollectionBinder<PurchasePreviewStoreItemViewModel>
    {
        [SerializeField] private View _prefab;
        [SerializeField] private List<StoreItemState> StatsForDispley;
        private readonly Dictionary<PurchasePreviewStoreItemViewModel, View> _createdViews = new();

        protected override void OnItemAdded(PurchasePreviewStoreItemViewModel viewModel)
        {
            if (!enabled) return;
            if (_createdViews.ContainsKey(viewModel))
            {
                return;
            }

            var createdView = Instantiate(_prefab, transform);
            createdView.gameObject.name = "Offer_" + viewModel.Caption;
            _createdViews.Add(viewModel, createdView);
            createdView.Bind(viewModel);
        }

        protected override void OnItemRemoved(PurchasePreviewStoreItemViewModel value)
        {
            if (!enabled) return;
            if (_createdViews.TryGetValue(value, out var view))
            {
                view.Destroy();
                _createdViews.Remove(value);
            }
        }
    }
}