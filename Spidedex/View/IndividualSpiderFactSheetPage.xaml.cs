using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class IndividualSpiderFactSheetPage : ContentPage
{
    public IndividualSpiderFactSheetPage(IndividualSpiderFactSheetPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}