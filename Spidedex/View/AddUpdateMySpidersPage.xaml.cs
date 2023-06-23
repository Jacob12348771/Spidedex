using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class AddUpdateMySpidersPage : ContentPage
{
    public AddUpdateMySpidersPage(AddUpdateMySpidersPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}