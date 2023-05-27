using CommunityToolkit.Mvvm.Input;
using Spidedex.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
