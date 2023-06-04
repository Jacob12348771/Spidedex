using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class MySpidersPage : ContentPage
{
    public MySpidersPage(MySpidersPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}