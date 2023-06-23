using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class MySpidersPage : ContentPage
{
	private MySpidersPageViewModel _viewModel;
    public MySpidersPage(MySpidersPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();
        _viewModel.GetSpidersCommand.Execute(null);
    }
}