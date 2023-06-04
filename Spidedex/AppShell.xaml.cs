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
	}
}
