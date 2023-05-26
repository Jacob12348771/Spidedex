using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}