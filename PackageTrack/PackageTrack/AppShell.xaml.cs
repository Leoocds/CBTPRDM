using PackageTrack.Views;

namespace PackageTrack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        }
    }
}
