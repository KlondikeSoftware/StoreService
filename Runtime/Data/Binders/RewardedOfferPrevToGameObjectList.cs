using System.Collections.Generic;
using com.ksgames.services.store.viewmodel;
using Lukomor.MVVM;
using Lukomor.MVVM.Binders;
using UnityEngine;

namespace com.ksgames.services.store.binders
{
    public class RewardedOfferPrevToGameObjectList : ObservableCollectionBinder<RewardedOfferPreviewViewModel>
    {
        [SerializeField] private View _prefab;
        [SerializeField] private List<StoreItemState> StatsForDispley;
        private readonly Dictionary<RewardedOfferPreviewViewModel, View> _createdViews = new();

        protected override void OnItemAdded(RewardedOfferPreviewViewModel viewModel)
        {
            if (!enabled) return;
            if (_createdViews.ContainsKey(viewModel))
            {
                return;
            }

            var createdView = Instantiate(_prefab, transform);
            createdView.gameObject.name = "Offer_" + viewModel.Caption.Value;
            _createdViews.Add(viewModel, createdView);
            createdView.Bind(viewModel);
        }

        protected override void OnItemRemoved(RewardedOfferPreviewViewModel value)
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