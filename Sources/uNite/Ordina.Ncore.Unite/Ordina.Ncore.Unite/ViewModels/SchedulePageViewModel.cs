using Ordina.Ncore.Unite.ViewModels.Base;
using Prism.Navigation;

namespace Ordina.Ncore.Unite.ViewModels
{
    public class SchedulePageViewModel : TabChildViewModelBase
    {
        public SchedulePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "The one and only Schedule page!";
        }
    }
}
