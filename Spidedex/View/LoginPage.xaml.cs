using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Release resources, unsubscribe from event handlers, clean up UI elements
    }
}

