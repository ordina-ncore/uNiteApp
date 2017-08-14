using Prism;
using Prism.Navigation;
using System;

namespace Ordina.Ncore.Unite.ViewModels.Base
{
    public class TabChildViewModelBase : BaseViewModel, IActiveAware, INavigatingAware, IDestructible
    {
        public event EventHandler IsActiveChanged;

        private bool _IsActive;

        public bool IsActive
        {
            get => _IsActive;
            set => SetProperty(ref _IsActive, value, OnIsActiveChanged);
        }

        public TabChildViewModelBase(INavigationService navigationService) : base(navigationService)
        { }

        public void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, null);
        }

        private void OnIsActiveChanged()
        {
            if (IsActive)
                OnActivate();
            else
                OnDeactivate();

            RaiseIsActiveChanged();
        }

        protected virtual void OnActivate() { }

        protected virtual void OnDeactivate() => ViewScopeDisposables.Clear();
    }
}
