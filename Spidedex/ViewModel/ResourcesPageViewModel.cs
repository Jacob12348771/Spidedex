using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    public partial class ResourcesPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async void OpenLink(string link)
        {
            try
            {
                Uri uri = new Uri(link);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Oops, something went wrong. Please try again later.", "Ok");
            }
        }
    }
}
