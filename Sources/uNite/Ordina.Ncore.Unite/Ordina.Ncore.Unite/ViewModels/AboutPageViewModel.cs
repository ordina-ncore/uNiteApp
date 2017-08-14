using Ordina.Ncore.Unite.ViewModels.Base;
using Prism.Navigation;

namespace Ordina.Ncore.Unite.ViewModels
{
    public class AboutPageViewModel : TabChildViewModelBase
    {
        public AboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "The one and only About page!";
        }
    }
}
