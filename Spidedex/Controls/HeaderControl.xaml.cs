namespace Spidedex.Controls;

public partial class HeaderControl : StackLayout
{
	public HeaderControl()
	{
		InitializeComponent();

		if (App.UserDetails != null)
		{
			lblEmail.Text = App.UserDetails.Email;
		}
	}
}