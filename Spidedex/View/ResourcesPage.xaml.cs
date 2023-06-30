using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class ResourcesPage : ContentPage
{
    public ResourcesPage(ResourcesPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}