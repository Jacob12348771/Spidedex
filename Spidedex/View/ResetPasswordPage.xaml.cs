using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class ResetPasswordPage : ContentPage
{
    public ResetPasswordPage(ResetPasswordPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}

