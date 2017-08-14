using Ordina.Ncore.Unite.Resources;
using Prism.Navigation;
using System;
using System.Reactive.Disposables;

namespace Ordina.Ncore.Unite.ViewModels.Base
{
    public class BaseViewModel : BindableBaseReactive, INavigationAware, IDestructible
    {
        protected CompositeDisposable ViewScopeDisposables { get; } = new CompositeDisposable();
        protected INavigationService _navigationService { get; }

        public BaseViewModel(INavigationService navigationService, Type resources = null)
        {
            _navigationService = navigationService;

            if (resources == null)
            {
                Resources = new LocalizedResources(typeof(AppResource));
            }
            else
            {
                Resources = new LocalizedResources(resources);
            }
        }

        public LocalizedResources Resources { get; }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value); 
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy; 
            set => SetProperty(ref _IsBusy, value, () => OnPropertyChanged(nameof(IsNotBusy))); 
        }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters) => ViewScopeDisposables.Clear();

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        { }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        { }

        public virtual void Destroy()
        { }
    }
}
