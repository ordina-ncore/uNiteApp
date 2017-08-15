using Ordina.Ncore.Unite.ViewModels;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ordina.Ncore.Unite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountdownPage : ContentPage
    {
        public CountdownPage()
        {
            InitializeComponent();
        }

        private async void GetTickets_Tapped(object sender, EventArgs e)
        {
            if(sender is View view && BindingContext is CountdownPageViewModel vm)
            {
                view.FadeTo(.25, 100).ContinueWith((t) => view.FadeTo(1, 100));
                await Task.Delay(125); //Just so the user sees the above effect a bit

                vm.OrderTicketsCommand.Execute(null);
            }
        }
    }
}