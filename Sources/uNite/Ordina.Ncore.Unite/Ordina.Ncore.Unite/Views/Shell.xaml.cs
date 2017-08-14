
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ordina.Ncore.Unite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shell : TabbedPage
    {
        public Shell()
        {
            InitializeComponent();
            LoadTabs();
        }

        private void LoadTabs()
        {
            //if()
            Children.Add(new CountdownPage());
            Children.Add(new SchedulePage());
            Children.Add(new AboutPage());
        }
    }
}