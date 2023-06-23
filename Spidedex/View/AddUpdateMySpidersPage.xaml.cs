namespace Spidedex.View;

public partial class AddUpdateMySpidersPage : ContentPage
{
    public AddUpdateMySpidersPage(AddUpdateMySpidersPage viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}