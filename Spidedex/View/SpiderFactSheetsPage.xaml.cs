using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class SpiderFactSheetsPage : ContentPage
{
	public SpiderFactSheetsPage(SpiderFactSheetsPageViewModel viewModel)
	{
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}