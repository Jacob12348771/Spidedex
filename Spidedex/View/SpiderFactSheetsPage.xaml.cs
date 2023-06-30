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
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetSpiderFactSheetsCommand.Execute(null);
    }
}