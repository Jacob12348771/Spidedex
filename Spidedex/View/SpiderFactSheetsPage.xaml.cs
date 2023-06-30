using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class SpiderFactSheetsPage : ContentPage
{
    private SpiderFactSheetsPageViewModel _viewModel;

    public SpiderFactSheetsPage(SpiderFactSheetsPageViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }
    // To load spider fact sheets when the page is loaded.
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetSpiderFactSheetsCommand.Execute(null);
    }
}