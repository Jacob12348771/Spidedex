using Spidedex.View;
using Spidedex.ViewModel;

namespace Spidedex;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(MySpidersPage), typeof(MySpidersPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ResetPasswordPage), typeof(ResetPasswordPage));
        Routing.RegisterRoute(nameof(AddUpdateMySpidersPage), typeof(AddUpdateMySpidersPage));
        Routing.RegisterRoute(nameof(SpiderFactSheetsPage), typeof(SpiderFactSheetsPage));
        Routing.RegisterRoute(nameof(IndividualSpiderFactSheetPage), typeof(IndividualSpiderFactSheetPage));
        Routing.RegisterRoute(nameof(ResourcesPage), typeof(ResourcesPage));
    }
}
