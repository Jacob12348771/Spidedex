using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class AddUpdateMySpidersPage : ContentPage
{
    public AddUpdateMySpidersPage(AddUpdateMySpidersPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Prevent error when navigating back to MySpidersPage after adding a spider / editing a spider and not saving.
        var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
        Navigation.RemovePage(previousPage);
    }
}