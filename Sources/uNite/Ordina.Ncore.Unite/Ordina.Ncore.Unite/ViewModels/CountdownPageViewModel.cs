using Ordina.Ncore.Unite.Extensions;
using Ordina.Ncore.Unite.ViewModels.Base;
using Prism.Navigation;
using ReactiveUI;
using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using static Ordina.NCore.Unite.Shared.Constants;

namespace Ordina.Ncore.Unite.ViewModels
{
    public class CountdownPageViewModel : TabChildViewModelBase
    {
        private ObservableAsPropertyHelper<TimeSpan> _Counter;

        public TimeSpan Counter => _Counter?.Value ?? TimeSpan.Zero;

        ICommand _OrderTicketsCommand;
        public ICommand OrderTicketsCommand => _OrderTicketsCommand 
            ?? (_OrderTicketsCommand = new Command(_ => OnOrderTicketsCommand()));

        public CountdownPageViewModel(INavigationService navigationService) : base(navigationService)
        { }

        protected override void OnActivate()
        {
            var observable = Observable.Interval(TimeSpan.FromMilliseconds(50))
                .Sample(TimeSpan.FromSeconds(1))
                .Select(_ => DATEOFEVENT - DateTime.Now);

            _Counter = observable.ToProperty(this, vm => vm.Counter, out _Counter, (DATEOFEVENT - DateTime.Now));

            _Counter.DisposeWith(ViewScopeDisposables);
        }

        private void OnOrderTicketsCommand()
        {
            Device.OpenUri(ORDERTICKETSURI);
        }
    }
}
