using Ordina.Ncore.Unite.Views;
using Prism.DryIoc;
using Prism.Logging;
using Xamarin.Forms;

namespace Ordina.Ncore.Unite
{
    public partial class App : PrismApplication
    {
        public static new App Current
        {
            get { return Application.Current as App; }
        }

        public new ILoggerFacade Logger
        {
            get { return base.Logger; }
        }

        public App()
        {
            InitializeComponent();
        }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("Shell");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<Shell>();
            Container.RegisterTypeForNavigation<NavigationPage>();
        }
    }
}
