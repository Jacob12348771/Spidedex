using Spidedex.Model;

namespace Spidedex;

public partial class App : Application
{
	public static User UserDetails;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
