using Spidedex.ViewModel;

namespace Spidedex.View;

public partial class FactSheetsPage : ContentPage
{
	public FactSheetsPage(FactSheetsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}